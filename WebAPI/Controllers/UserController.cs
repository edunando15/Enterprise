using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Factories;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Models.Requests;
using Esame_Enterprise.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/authentication")]
    public class UserController : ControllerBase
    {

        IUserService _userService;

        ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(CreateUserRequest request)
        {
            var dto = new UserDto() { Email = request.Email, Name = request.Name, Surname = request.Surname, Password = request.Password };
            if (_userService.SignUp(dto)) 
                return Ok(ResponseFactory.WithSuccess(
                    new CreateUserResponse() { Name = dto.Name, Surname = dto.Surname, Email = dto.Email, Message = "User created succesfully." })
                    );
            return BadRequest(ResponseFactory.WithError(
                new CreateUserResponse() { Email = dto.Email, Name = dto.Name, Surname = dto.Surname, Message = "Already existing user." })
                );
        }

        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn(CreateTokenRequest request)
        {
            string token = _tokenService.CreateToken(request);
            if(token != string.Empty) return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
            else return BadRequest(ResponseFactory.WithError(new CreateTokenResponse(token)));
        }
    }
}
