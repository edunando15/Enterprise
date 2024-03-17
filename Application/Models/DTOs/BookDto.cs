using Esame_Enterprise.Application.Abstractions.Models.Dto;
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
