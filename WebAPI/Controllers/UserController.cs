using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/authentication")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {

        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(UserDto userDto)
        {
            if (userService.SignUp(userDto)) return Ok();
            return BadRequest();
        }

        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn(string email, string password)
        {
            if(userService.LogIn(email, password)) return Ok();
            else return BadRequest();
        }
    }
}
