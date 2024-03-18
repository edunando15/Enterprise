using Model.Context;
using Model.Entities;

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

        public override void Delete(int categoryId)
        {
            var c = Get(categoryId);
            _context.Remove(c);
        }

    }
}
