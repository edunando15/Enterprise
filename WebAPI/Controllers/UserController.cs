using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Factories;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Models.Requests;
using Esame_Enterprise.Application.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/authentication")]
    public class UserController : ControllerBase
    {

        IUserService userService;

        ITokenService tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(CreateUserRequest request)
        {
            var dto = new UserDto() { Email = request.Email, Name = request.Email, Surname = request.Surname, Password = request.Password };
            if (userService.SignUp(dto)) 
                return Ok(ResponseFactory.WithSuccess(
                    new CreateUserResponse() { Name = dto.Name, Surname = dto.Surname })
                    );
            return BadRequest(ResponseFactory.WithError(
                new CreateUserResponse() { Email = dto.Email })
                );
        }

        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn(CreateTokenRequest request)
        {
            string token = tokenService.CreateToken(request);
            if(token != string.Empty) return Ok(token);
            else return BadRequest();
        }
    }
}
