using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(LibraryContext context) : base(context) { }

        public User? GetUser(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public User? GetUser(string email, string password)
        {
            return _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public bool UserExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }


    }
}
