using Esame_Enterprise.Application.Models.Dto;

namespace Esame_Enterprise.Application.Abstractions.Services
{
    public interface IBookService
    {
        bool AddBook(BookDto book);

        void ModifyBook(BookDto book);

        bool DeleteBook(BookDto book);

        IEnumerable<BookDto> GetBooks(int from, int num, string orderBy, out int totalCount, string author, string publisher, DateTime? publicationDate, CategoryDto category); 

    }
}
