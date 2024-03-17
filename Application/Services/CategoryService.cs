using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Model.Repositories;
using Model.Entities;

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
            repository.Insert(category.ToEntity());
            repository.Save();
            return true;
        }

        public bool DeleteCategory(CategoryDto category)
        {
            var c = category.ToEntity();
            if(!bookCategoryRepository.IsDeleatable(c)) return false;
            repository.Delete(c);
            repository.Save();
            return true;
        }

        public List<CategoryDto> GetCategories()
        {
            return repository.GetCategories().Select(c => new CategoryDto() { Id = c.Id, Name = c.Name }).ToList();
        }

        public CategoryDto? GetCategory(string name)
        {
            var c =  repository.GetCategory(name);
            return c != null ? new CategoryDto() { Id = c.Id, Name = c.Name } : null;
        }

    }
}
