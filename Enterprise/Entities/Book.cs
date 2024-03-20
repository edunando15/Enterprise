namespace Model.Entities
{
    public class Book
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Publisher { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
