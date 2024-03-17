using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_Enterprise.Web.Controllers
{
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
    }
}
