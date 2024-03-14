namespace Esame_Enterprise.Application.Models.Dto
{
    public class BookDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Publisher { get; set; }

        public ICollection<BookCategoryDto> BookCategories { get; set; }

    }
}
