using System.IO;

namespace HealthSphere.Server
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpClientFactory _clientFactory;

        public AuthenticationMiddleware(RequestDelegate next, IHttpClientFactory clientFactory)
        {
            _next = next;
            _clientFactory = clientFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Bypass authentication for signup and signin
            if (context.Request.Path.Equals("/api/Gateway/signIn") ||
                context.Request.Path.Equals("/api/Gateway/signUp"))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("No authorization token provided.");
                return;
            }

            var client = _clientFactory.CreateClient("AuthServiceClient");
            var response = await client.GetAsync($"/validate?token={token}"); // Assuming your auth service has a "/validate" endpoint

            if (response.IsSuccessStatusCode)
            {
                // Token is valid, proceed with the request
                await _next(context);
            }
            else
            {
                // Token is invalid, return unauthorized
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid token.");
            }
        }
    }

}
