using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Model.Repositories;
using Model.Entities;

namespace Esame_Enterprise.Application.Services
{
    public class BookService : IBookService
    {

        private readonly BookRepository repository;

        private readonly BookCategoryRepository bookCategoryRepository;

        public BookService(BookRepository repository, BookCategoryRepository bookCategoryRepository)
        {
            this.repository = repository;
            this.bookCategoryRepository = bookCategoryRepository;
        }



        public bool AddBook(BookDto book)
        {
            if(repository.Get(book.Id) != null) return false;
            repository.Insert(book.ToEntity());
            repository.Save();
            return true;
        }

        public bool DeleteBook(BookDto book)
        {
            if (repository.Get(book.ToEntity()) == null) return false;
            repository.Delete(book.ToEntity());
            repository.Save();
            return true;
        }

        public IEnumerable<BookDto> GetBooks(int from, int amount, out int totalAmount)
        {
            throw new NotImplementedException();
        }

        public void ModifyBook(BookDto book)
        {
            repository.Modify(book.ToEntity());
            repository.Save();
        }
    }
}
