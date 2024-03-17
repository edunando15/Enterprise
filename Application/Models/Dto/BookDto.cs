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

        public ICollection<BookCategoryDto> BookCategories { get; set; }

        public Book ToEntity()
        {
            return new Book()
            {
                Id = this.Id,
                Name = this.Name,
                Author = this.Author,
                Publisher = this.Publisher,
                PublicationDate = this.PublicationDate,
                BookCategories = this.BookCategories.Select(bc => bc.ToEntity()).ToList()  
            };
        }

    }
}
