using Model.Context;
using Model.Entities;
using Application;
using Esame_Enterprise.Application.Models.Dto;
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

        public List<Book> GetBooks(int from, int num, string orderBy, out int totalCount, string author, string publisher, DateTime? publicationDate, CategoryDto category)
        {
            var books = _context.Books.AsQueryable();
            totalCount = books.Count();
            if (!string.IsNullOrWhiteSpace(author)) books = books.Where(b => b.Author.Contains(author));
            if (!string.IsNullOrWhiteSpace(publisher)) books = books.Where(b => b.Publisher.Contains(publisher));
            if (publicationDate != null) books = books.Where(b => b.PublicationDate.Equals(publicationDate));
            if (category != null) books = books.Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(category.Name)));
            return books
                .Skip(from)
                .Take(num)
                .ToList();
        }


        private IQueryable<Book> orderSet(IQueryable<Book> books, string filter)
        {
            switch (filter)
            {
                case (nameof(BookDto.Author)): books = books.OrderBy(b => b.Author); break;
                case (nameof(BookDto.Publisher)): books = books.OrderBy(b => b.Publisher); break;
                case (nameof(BookDto.PublicationDate)): books = books.OrderBy(b => b.PublicationDate); break;
                case (nameof(BookDto.BookCategories)): books = books.OrderBy(b => b.BookCategories.OrderBy(bc => bc.Category.Name)); break;
                default: books = books.OrderBy(b => b.Id); break;
            }
            return books;
        }


    }
}
