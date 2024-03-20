using Model.Context;
using Model.Entities;
namespace Model.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {

        public BookRepository(LibraryContext context) : base(context) { }

        public override Book? Get(int id)
        {
            return _context.Books.Find(id);
        }

        public List<Book> GetBooks(int from, int num, string orderBy, out int totalCount, string name, string author, string publisher, DateTime? publicationDate, Category category)
        {
            var books = _context.Books.AsQueryable();
            totalCount = books.Count();
            OrderSet(books, orderBy);
            if (!string.IsNullOrWhiteSpace(author)) books = books.Where(b => b.Author.Contains(author));
            if (!string.IsNullOrWhiteSpace(publisher)) books = books.Where(b => b.Publisher.Contains(publisher));
            if (!string.IsNullOrWhiteSpace(name)) books = books.Where(b => b.Name.Contains(name));
            if (publicationDate != null) books = books.Where(b => b.PublicationDate.Equals(publicationDate));
            if (category != null) books = books.Where(b => b.BookCategories.Any(bc => bc.Category.Id == category.Id));
            return books
                .Skip(from)
                .Take(num)
                .ToList();
        }

        public override void Delete(int id)
        {
            var e = Get(id);
            if(e != null) _context.Remove(e);
        }

        private IQueryable<Book> OrderSet(IQueryable<Book> books, string filter)
        {
            switch (filter)
            {
                case (nameof(Book.Author)): books = books.OrderBy(b => b.Author); break;
                case (nameof(Book.Publisher)): books = books.OrderBy(b => b.Publisher); break;
                case (nameof(Book.PublicationDate)): books = books.OrderBy(b => b.PublicationDate); break;
                case (nameof(Book.BookCategories)): books = books.OrderBy(b => b.BookCategories.OrderBy(bc => bc.Category.Name)); break;
                default: books = books.OrderBy(b => b.Id); break;
            }
            return books;
        }

    }
}
