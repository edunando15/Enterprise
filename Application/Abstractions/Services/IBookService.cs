using Esame_Enterprise.Application.Models.Dto;

namespace Esame_Enterprise.Application.Abstractions.Services
{
    public interface IBookService
    {
        bool AddBook(BookDto book);

        void ModifyBook(BookDto book);

        bool DeleteBook(int bookId);

        IEnumerable<BookDto> GetBooks(int from, int num, string orderBy, out int totalCount, string name, string author, string publisher, DateTime? publicationDate, string? category); 

    }
}
