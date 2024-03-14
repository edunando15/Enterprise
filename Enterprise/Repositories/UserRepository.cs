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
        public UserRepository(LibraryContext context) : base(context)
        {
        }
    }
}
