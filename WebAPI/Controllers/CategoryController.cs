using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Models.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/category")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {

        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpPost]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory(CreateCategoryRequest category)
        {
            if (_categoryService.AddCategory(new CategoryDto(category))) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(DeleteCategoryRequest request)
        {
            if (_categoryService.DeleteCategory(request.Id)) return Ok();
            return BadRequest();
        }

    }
}
