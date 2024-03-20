using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Model.Repositories;
using Model.Entities;

namespace Esame_Enterprise.Application.Services
{
    public class BookService : IBookService
    {

        private readonly BookRepository bookRepository;

        private readonly BookCategoryRepository bookCategoryRepository;

        private readonly CategoryRepository categoryRepository;

        public BookService(BookRepository bookRepository, BookCategoryRepository bookCategoryRepository, CategoryRepository categoryRepository)
        {
            this.bookRepository = bookRepository;
            this.bookCategoryRepository = bookCategoryRepository;
            this.categoryRepository = categoryRepository;
        }

        public bool AddBook(BookDto book)
        {
            if (!SetCategoriesId(book.Categories)) return false; // Aggiungi solo libri con categorie gia' esistenti.
            var realBook = book.ToEntity();
            bookRepository.Insert(realBook);
            foreach (var bc in realBook.BookCategories)
            {
                bookCategoryRepository.Insert(bc);
            }
            bookRepository.Save();
            bookCategoryRepository.Save();
            return true;
        }

        public bool DeleteBook(int Id)
        {
            if (bookRepository.Get(Id) == null) return false;
            bookRepository.Delete(Id);
            bookRepository.Save();
            return true;
        }

        public IEnumerable<BookDto> GetBooks(int from, int num, string orderBy, out int totalCount, string? name, string? author, string? publisher, DateTime? publicationDate, string? category)
        {
            Category? cat;
            if (string.IsNullOrEmpty(category)) cat = null;
            else cat = categoryRepository.GetCategory(category);
            var res = bookRepository.GetBooks(from, num, orderBy, out totalCount, name, author, publisher, publicationDate, cat);
            return GetDtos(res);
        }

        private IEnumerable<BookDto> GetDtos(List<Book> books)
        {
            var res = new List<BookDto>();
            foreach (var book in books)
            {
                res.Add(new BookDto()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate,
                    Publisher = book.Publisher,
                    Categories = getCategories(bookCategoryRepository.GetBookCategoriesByBook(book.Id))
                });
            }
            return res;
        }

        private ICollection<CategoryDto> getCategories(List<BookCategory> bookCategories)
        {
            var res = new List<CategoryDto>();
            foreach (var bookCategory in bookCategories)
            {
                res.Add(new CategoryDto() { Id = bookCategory.CategoryId });
            }
            SetCategoriesName(res);
            return res;
        }

        public void ModifyBook(BookDto book)
        {
            if (!SetCategoriesId(book.Categories)) return; // Modifico solo libri con categorie gia' esistenti.
            var newCategories = book.Categories.ToList();
            var realBook = book.ToEntity();
            bookRepository.Modify(realBook);
            if(newCategories.Count > 0)
            {
                var bookCategories = bookCategoryRepository.GetBookCategoriesByBook(realBook.Id);
                foreach (var bookCategory in bookCategories)
                {
                    bookCategoryRepository.DeleteBookCategoryByBookId(realBook.Id);
                }
                foreach (var category in newCategories)
                {
                    bookCategoryRepository.Insert(new BookCategory() { BookId = realBook.Id, CategoryId = category.Id});
                }
                bookCategoryRepository.Save();
            }
            bookRepository.Save();
        }

        private bool SetCategoriesId(ICollection<CategoryDto> categories)
        {
            foreach (var category in categories)
            {
                var cat = categoryRepository.GetCategory(category.Name);
                if (cat != null) category.Id = cat.Id;
                else return false;
            }
            return true;
        }

        private void SetCategoriesName(ICollection<CategoryDto> categories)
        {
            foreach (var category in categories)
            {
                var cat = categoryRepository.Get(category.Id);
                if (cat != null) category.Name = cat.Name;
            }
        }

    }
}
