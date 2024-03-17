using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {

        public CategoryRepository(LibraryContext context) : base(context) { }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category? GetCategory(string categoryName)
        {
            return _context.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
        }   

        public List<Category> GetCategoriesByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return _context.Categories.ToList();
            return _context.Categories.Where(c => c.Name.Contains(name)).ToList();
        }

    }
}
