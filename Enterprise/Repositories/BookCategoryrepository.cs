﻿using Model.Context;
using Model.Entities;

namespace Model.Repositories
{
    public class BookCategoryRepository : GenericRepository<BookCategory>
    {
        public BookCategoryRepository(LibraryContext context) : base(context)
        {
        }

        public List<BookCategory> GetBookCategoriesByBook(int bookId)
        {
            return _context.BookCategories.Where(bc => bc.BookId == bookId).ToList();
        }

        public List<BookCategory> GetBookCategoriesByCategory(int categoryId)
        {
            var r = _context.BookCategories.Where(bc => bc.CategoryId == categoryId).ToList();
            return r;
        }


        public bool IsDeleatable(int categoryId)
        {
            //var c = _context.Categories.Find(categoryId);
            //if(c == null) return false;
            return !_context.BookCategories.Any(bc => bc.CategoryId == categoryId);
        }

        public bool DeleteBookCategory(int categoryId)
        {
            var c = _context.Categories.Find(categoryId);
            if (c == null) return false;
            if (!IsDeleatable(categoryId)) return false;
            var bookCategoriesToDelete = _context.BookCategories.Where(bc => bc.CategoryId == categoryId);
            _context.BookCategories.RemoveRange(bookCategoriesToDelete);
            return true;
        }

        public void DeleteBookCategoryByBookId(int bookId)
        {
            var delete = _context.BookCategories.Where(bc => bc.BookId == bookId);
            _context.BookCategories.RemoveRange(delete);
        }

        public override bool Exists(int categoryId)
        {
            return _context.BookCategories.Any(bc => bc.CategoryId == categoryId);
        }

    }
}
