using Model.Context;
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

        public List<BookCategory> GetBookCategoriesByBook(int bookId)
        {
            return _context.BookCategories.Where(bc => bc.BookId == bookId).ToList();
        }

        public List<BookCategory> GetBookCategoriesByCategory(int categoryId)
        {
            return _context.BookCategories.Where(bc => bc.CategoryId == categoryId).ToList();
        }


        public bool IsDeleatable(Category category)
        {
            var c = _context.Categories.Find(category);
            return !_context.BookCategories.Any(bc => bc.CategoryId == c.Id);
        }

        public bool DeleteBookCategory(Category category)
        {
            if (!IsDeleatable(category)) return false;
            var bookCategoriesToDelete = _context.BookCategories.Where(bc => bc.CategoryId == category.Id);
            _context.BookCategories.RemoveRange(bookCategoriesToDelete);
            return true;
        }

        public void DeleteBookCategory(Book book)
        {
            var delete = _context.BookCategories.Where(bc => bc.BookId == book.Id);
            _context.BookCategories.RemoveRange(delete)
        }

    }
}
