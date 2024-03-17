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

        public List<Book> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) _context.Books.ToList();
            return _context.Books.Where(b => b.Name.Contains(name)).ToList();
        }

        public List<Book> GetByAuthor(string author)
        {
            if(string.IsNullOrWhiteSpace(author)) return _context.Books.ToList();
            return _context.Books.Where(b => b.Author.Contains(author)).ToList();
        }

        public List<Book> GetByPublisher(string publisher)
        {
            if(string.IsNullOrWhiteSpace(publisher)) return _context.Books.ToList();
            return _context.Books.Where(b => b.Publisher.Contains(publisher)).ToList();
        }

        public List<Book> GetByPublicationDate(DateTime? date)
        {
            if (date == null) return _context.Books.ToList();
            return _context.Books.Where(b => b.PublicationDate.Equals(date)).ToList();
        }

        public List<Book> GetByCategory(string category)
        {
            if(string.IsNullOrWhiteSpace(category)) return _context.Books.ToList();
            return _context.Books.Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(category))).ToList();
        }

        public List<Book> GetBooks(int from, int num, string orderBy, string filter, string value, out int totalCount, string author, string publisher, DateTime? publicationDate, Category category)
        {
            var books = _context.Books.AsQueryable();
            totalCount = books.Count();
            FilterSet(books, filter, value);
            OrderSet(books, orderBy);
            if (!string.IsNullOrWhiteSpace(author)) books = books.Where(b => b.Author.Contains(author));
            if (!string.IsNullOrWhiteSpace(publisher)) books = books.Where(b => b.Publisher.Contains(publisher));
            if (publicationDate != null) books = books.Where(b => b.PublicationDate.Equals(publicationDate));
            if (category != null) books = books.Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(category.Name)));
            return books
                .Skip(from)
                .Take(num)
                .ToList();
        }

        /// <summary>
        /// Filters a set according to the given parameters.
        /// </summary>
        /// <param name="books">The set to filter.</param>
        /// <param name="filter">The type of filter.</param>
        /// <param name="value">The value of the filter.</param>
        /// <returns>The set filtered according to the parameters.</returns>
        private IQueryable<Book> FilterSet(IQueryable<Book> books, string filter, string value)
        {
            if(!string.IsNullOrWhiteSpace(value))
            {
                switch (filter)
                {
                    case (nameof(Book.Author)): books = books.Where(b => b.Author.Contains(value)); break;
                    case (nameof(Book.Publisher)): books = books.Where(b => b.Publisher.Contains(value)); break;
                    case (nameof(Book.BookCategories)): books = books.Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(value))); break;
                    case (nameof(Book.PublicationDate)):
                        try
                        {
                            books = books.Where(b => b.PublicationDate.Equals(DateTime.Parse(value))); break;
                        }
                        catch(Exception ex) { break; }
                    default: break;
                }
            }
            return books;
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
