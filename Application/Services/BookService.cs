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
            if (!GetCategories(book.Categories)) return false; // Aggiungi solo libri con categorie gia' esistenti.
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

        public IEnumerable<BookDto> GetBooks(int from, int num, string orderBy, out int totalCount, string author, string publisher, DateTime? publicationDate, CategoryDto category)
        {
            var res = bookRepository.GetBooks(from, num, orderBy, out totalCount, author, publisher, publicationDate, category != null ? category.ToEntity() : null);
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
                    Publisher = book.Publisher
                });
            }
            return res;
        }

        public void ModifyBook(BookDto book)
        {
            bookRepository.Modify(book.ToEntity());
            bookRepository.Save();
        }

        private bool GetCategories(ICollection<CategoryDto> categories)
        {
            foreach (var category in categories)
            {
                var cat = categoryRepository.GetCategory(category.Name);
                if (cat != null) category.Id = cat.Id;
                else return false;
            }
            return true;
        }

    }
}
