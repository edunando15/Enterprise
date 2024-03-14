using Model.Entities;

namespace Esame_Enterprise.Application.Models.Requests

{
    public class CreateUserRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public User ToEntity()
        {
            var user = new User
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                Password = Password
            };
            return user;
        }

    }

}
