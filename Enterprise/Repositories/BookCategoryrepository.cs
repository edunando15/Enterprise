﻿using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class BookCategoryRepository : GenericRepository<BookCategory>
    {
        public BookCategoryRepository(LibraryContext context) : base(context)
        {
        }

        public List<BookCategory> GetBookCategories(int bookId)
        {
            return _context.BookCategories.Where(bc => bc.BookId == bookId).ToList();
        }

    }
}
