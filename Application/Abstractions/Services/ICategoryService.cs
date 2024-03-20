using Esame_Enterprise.Application.Models.Dto;

namespace Esame_Enterprise.Application.Abstractions.Services
{
    public interface ICategoryService
    {

        List<CategoryDto> GetCategories();

        bool AddCategory(CategoryDto category);

        bool DeleteCategory(int categoryId);

    }
}
