using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Options;
using Model.Repositories;

namespace Esame_Enterprise.Application.Services
{
    public class UserService : IUserService
    {

        private readonly UserRepository repository;

        private readonly JwtAuthenticationOption jwtOptions;

        public UserService(UserRepository repository, JwtAuthenticationOption jwtOptions)
        {
            this.repository = repository;
            this.jwtOptions = jwtOptions;
        }

        public bool LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool SignUp(UserDto user)
        {
            if (repository.UserExists(user.Email)) return false;
            repository.Insert(user.ToEntity());
            repository.Save();
            return true;
        }
    }
}
