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

        public override Book? Get(int id)
        {
            return _context.Books.Find(id);
        }

        // TODO contains ecc

    }
}
