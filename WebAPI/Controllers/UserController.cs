using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {

        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult SignUp(UserDto userDto)
        {
            if (userService.SignUp(userDto)) return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
            var response = userService.LogIn(email, password);
            if (response) return Ok(response);
            return BadRequest();
        }
    }
}
