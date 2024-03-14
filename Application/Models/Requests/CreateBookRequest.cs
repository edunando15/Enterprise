using Model.Entities;

namespace Esame_Enterprise.Application.Models.Requests
{
    public class CreateBookRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        public Book ToEntity()
        {
            var book = new Book
            {
                Name = Name,
                Author = Author,
                PublicationDate = PublicationDate,
                Publisher = Publisher,
                BookCategories = BookCategories
            };
            return book;
        }

    }

}
