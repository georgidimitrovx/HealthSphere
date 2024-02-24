using HealthSphere.SharedKernel.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HealthSphere.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public GatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("{*url}")]
        [HttpGet("{*url}")]
        public async Task<IActionResult> HandleRequest(string url)
        {
            // Identify service endpoint
            var serviceType = Helpers.GetServiceFromUrl(url);
            if(serviceType == Helpers.ServiceTypes.Unidentified)
                return NotFound();

            var serviceEndpoint = Helpers.GetServiceEndpoint(serviceType, true);
            var targetUrl = $"{serviceEndpoint}{url}";

            // Identify method
            var methodType = Request.Method.ToUpper() switch
            {
                "POST" => HttpMethod.Post,
                "GET" => HttpMethod.Get,
                // Add other methods as needed
                _ => throw new InvalidOperationException("HTTP method not supported")
            };

            // Copy the request headers to the new request
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(targetUrl),
                Method = methodType,
            };

            // Forward the payload if the method supports a body
            if (methodType == HttpMethod.Post)
            {
                var body = await new StreamReader(Request.Body).ReadToEndAsync();
                requestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            // Forward the request to the target service
            var response = await _httpClient.SendAsync(requestMessage);

            // Read the response content and return it
            var content = await response.Content.ReadAsStringAsync();

            return new ContentResult
            {
                Content = content,
                ContentType = response.Content.Headers.ContentType!.ToString(),
                StatusCode = (int)response.StatusCode
            };
        }
    }
}
