using HealthSphere.SharedKernel.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealthSphere.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        public GatewayController()
        {
        }

        //////////////////////////////////////////////////
        /// AuthenticationService

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> SignIn([FromBody] UserCredentialsDto userCredentialsDto)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(
                Helpers.GetServiceEndpoint(Helpers.Services.Authentication, true) +
                "signIn", userCredentialsDto);

            if (response.IsSuccessStatusCode)
            {
                // If auth is successful, return the token or auth result to the client
                var token = await response.Content.ReadAsStringAsync();
                return Ok(token);
            }
            else
            {
                // Handle failed authentication
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> SignUp([FromBody] UserCredentialsDto userCredentialsDto)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(
                Helpers.GetServiceEndpoint(Helpers.Services.Authentication, true) +
                "signUp", userCredentialsDto);

            if (response.IsSuccessStatusCode)
            {
                // If auth is successful, return the token or auth result to the client
                var token = await response.Content.ReadAsStringAsync();
                return Ok(token);
            }
            else
            {
                // Handle failed authentication
                return Unauthorized();
            }
        }

        //////////////////////////////////////////////////
        /// Other service
    }
}
