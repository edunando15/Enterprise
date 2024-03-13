using Microsoft.EntityFrameworkCore;
using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {

        public BookRepository(MyDbContext context) : base(context) { }

        public override async Task<Book?> Get(object id)
        {
            return await _context.Books.FindAsync(id);
        }

    }
}
