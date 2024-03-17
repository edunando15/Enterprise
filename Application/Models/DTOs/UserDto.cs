using Esame_Enterprise.Application.Abstractions.Models.Dto;
using Model.Entities;

namespace Esame_Enterprise.Application.Models.Dto
{
    public class UserDto : GenericDto<User>
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public User ToEntity()
        {
            return new User()
            {
                Id = this.Id,
                Email = this.Email,
                Name = this.Name,
                Surname = this.Surname,
                Password = this.Password
            };
        }
    }
}
