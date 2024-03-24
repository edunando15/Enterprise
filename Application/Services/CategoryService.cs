using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Model.Repositories;

namespace Esame_Enterprise.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly CategoryRepository _categoryRepository;

        private readonly BookCategoryRepository _bookCategoryRepository;

        public CategoryService(CategoryRepository repository, BookCategoryRepository bookCategoryRepository)
        {
            this._categoryRepository = repository;
            this._bookCategoryRepository = bookCategoryRepository;
        }

        public CategoryDto? AddCategory(CategoryDto category)
        {
            if (_categoryRepository.GetCategory(category.Name) != null) return null;
            var realCategory = category.ToEntity();
            try
            {
                _categoryRepository.Insert(realCategory);
                _categoryRepository.Save();
            }
            catch (Exception) { return null; }
            return new CategoryDto(realCategory);
        }

        public bool DeleteCategory(int categoryId)
        {
            if (_categoryRepository.Get(categoryId) == null) return false;
            if(!_bookCategoryRepository.IsDeleatable(categoryId)) return false;
            try
            {
                _categoryRepository.Delete(categoryId);
                _categoryRepository.Save();
            }
            catch(Exception) { return false; }
            return true;
        }

        public List<CategoryDto> GetCategories()
        {
            return _categoryRepository.GetCategories().Select(c => new CategoryDto() { Id = c.Id, Name = c.Name }).ToList();
        }

    }
}
