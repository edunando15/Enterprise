using Esame_Enterprise.Application.Models.Dto;

namespace Esame_Enterprise.Application.Abstractions.Services
{
    public interface IUserService
    {

        public bool SignUp(UserDto user);

        public bool LogIn(string email, string password);

    }
}
