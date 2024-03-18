using Esame_Enterprise.Application.Abstractions.Models.Dto;
using Esame_Enterprise.Application.Models.Requests;
using Model.Entities;

namespace Esame_Enterprise.Application.Models.Dto
{
    public class BookDto : GenericDto<Book>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Publisher { get; set; }

        public ICollection<CategoryDto> Categories { get; set; }

        public BookDto() { }

        public BookDto(ActionBookRequest book)
        {
            Name = book.Name;
            Author = book.Author;
            PublicationDate = book.PublicationDate;
            Publisher = book.Publisher;
            Categories = new List<CategoryDto>();
            foreach (var category in book.Categories)
            {
                Categories.Add(new CategoryDto() {Name = category});
            }
        }

        public Book ToEntity()
        {
            Book result = new Book()
            {
                Id = this.Id,
                Name = this.Name,
                Author = this.Author,
                Publisher = this.Publisher,
                PublicationDate = this.PublicationDate,
                BookCategories = BuildBookCategories()  
            };
            foreach(var bc in result.BookCategories) { bc.Book = result; }
            return result;
        }

        private ICollection<BookCategory> BuildBookCategories()
        {
            var result = new List<BookCategory>();
            foreach (var category in Categories)
            {
                result.Add(new BookCategory() { BookId = this.Id, CategoryId = category.Id });
            }
            return result;
        }

    }
}
