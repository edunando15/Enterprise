using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Model.Repositories;

namespace Esame_Enterprise.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly CategoryRepository repository;

        private readonly BookCategoryRepository bookCategoryRepository;

        public CategoryService(CategoryRepository repository, BookCategoryRepository bookCategoryRepository)
        {
            this.repository = repository;
            this.bookCategoryRepository = bookCategoryRepository;
        }

        public bool AddCategory(CategoryDto category)
        {
            if (repository.GetCategory(category.Name) != null) return false;
            try
            {
                repository.Insert(category.ToEntity());
                repository.Save();
            }
            catch (Exception) { return false; }
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            if (repository.Get(categoryId) == null) return false;
            if(!bookCategoryRepository.IsDeleatable(categoryId)) return false;
            try
            {
                repository.Delete(categoryId);
                repository.Save();
            }
            catch(Exception) { return false; }
            return true;
        }

        public List<CategoryDto> GetCategories()
        {
            return repository.GetCategories().Select(c => new CategoryDto() { Id = c.Id, Name = c.Name }).ToList();
        }

    }
}
