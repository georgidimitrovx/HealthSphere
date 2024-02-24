using HealthSphere.SharedKernel.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealthSphere.AuthenticationService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        //private readonly IUserService _userService;

        //public AuthenticationController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> SignIn([FromBody] UserCredentialsDto userCredentialsDto)
        {
            // todo
            var response = "{\"token\": \"sampleToken1\"}";
            return Ok(response);
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> SignUp([FromBody] UserCredentialsDto userCredentialsDto)
        {
            var response = "{\"token\": \"sampleToken2\"}";
            return Ok(response);
        }
    }
}
