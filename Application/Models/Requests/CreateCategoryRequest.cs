using Model.Entities;

namespace Esame_Enterprise.Application.Models.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        public Category ToEntity()
        {
            var category = new Category
            {
                Name = Name,
                BookCategories = BookCategories
            };
            return category;
        }

    }

}
