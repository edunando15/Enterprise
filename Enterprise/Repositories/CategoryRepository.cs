using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {

        public CategoryRepository(MyDbContext context) : base(context) { }

        

    }
}
