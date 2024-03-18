using Model.Entities;

namespace Esame_Enterprise.Application.Models.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;

        public Category ToEntity()
        {
            var category = new Category
            {
                Name = Name,
                BookCategories = new List<BookCategory>()
            };
            return category;
        }

    }

}
