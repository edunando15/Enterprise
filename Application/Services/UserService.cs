using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Options;
using Microsoft.Extensions.Options;
using Model.Repositories;

namespace Esame_Enterprise.Application.Services
{
    public class UserService : IUserService
    {

        private readonly UserRepository repository;

        private readonly JwtAuthenticationOption jwtOptions;

        public UserService(UserRepository repository, IOptions<JwtAuthenticationOption> jwtOptions)
        {
            this.repository = repository;
            this.jwtOptions = jwtOptions.Value;
        }

        public UserDto? LogIn(string email, string password)
        {
            var user = repository.GetUser(email, password);
            if(user != null) return new UserDto() { Email = user.Email, Name = user.Name, Surname = user.Surname, Password = user.Password };
            return null;
        }

        public bool SignUp(UserDto user)
        {
            if (repository.UserExists(user.Email)) return false;
            repository.Insert(user.ToEntity());
            repository.Save();
            return true;
        }

        public UserDto? GetUser(string email)
        {
            var user = repository.GetUser(email);
            if(user != null) return new UserDto() { Name = user.Name, Surname = user.Surname, Email = user.Email, Password = user.Password };
            else return null;
        }

    }
}
