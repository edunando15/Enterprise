using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Options;
using Microsoft.Extensions.Options;
using Model.Repositories;

namespace Esame_Enterprise.Application.Services
{
    public class UserService : IUserService
    {

        private readonly UserRepository _repository;

        private readonly JwtAuthenticationOption _jwtOption;

        public UserService(UserRepository repository, IOptions<JwtAuthenticationOption> jwtOptions)
        {
            this._repository = repository;
            this._jwtOption = jwtOptions.Value;
        }

        public UserDto? LogIn(string email, string password)
        {
            var user = _repository.GetUser(email, password);
            if(user != null) return new UserDto() { Email = user.Email, Name = user.Name, Surname = user.Surname, Password = user.Password };
            return null;
        }

        public bool SignUp(UserDto user)
        {
            if (_repository.UserExists(user.Email)) return false;
            _repository.Insert(user.ToEntity());
            _repository.Save();
            return true;
        }

        public UserDto? GetUser(string email)
        {
            var user = _repository.GetUser(email);
            if(user != null) return new UserDto() { Name = user.Name, Surname = user.Surname, Email = user.Email, Password = user.Password };
            else return null;
        }

    }
}
