using Esame_Enterprise.Application.Models.Dto;

namespace Esame_Enterprise.Application.Abstractions.Services
{
    public interface IUserService
    {

        public bool SignUp(UserDto user);

        public UserDto? LogIn(string email, string password);

        public abstract UserDto? GetUser(string email);

    }
}
