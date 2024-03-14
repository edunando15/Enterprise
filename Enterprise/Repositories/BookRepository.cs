using Microsoft.EntityFrameworkCore;
using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Books.Where(b => b.Name == name).ToList();
        }

        public List<Book> GetByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author == author).ToList();
        }

        public List<Book> GetByPublisher(string publisher)
        {
            return _context.Books.Where(b => b.Publisher == publisher).ToList();
        }

        public List<Book> GetByPublicationDate(DateTime date)
        {
            return _context.Books.Where(b => b.PublicationDate.Equals(date)).ToList();
        }

        public List<Book> GetByCategory(Category category)
        {
            
            return new List<Book>();
        }

    }
}
