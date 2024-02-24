using HealthSphere.SharedKernel.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealthSphere.AuthenticationService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return Ok("token");
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> SignUp([FromBody] UserCredentialsDto userCredentialsDto)
        {
            // todo
            return Ok("token");
        }
    }
}
