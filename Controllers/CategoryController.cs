using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<CategoryDto>>>> GetAllCategories() 
        {
            var categories = await  _categoryService.GetAllCategories();
            if (categories == null)
            {
               return NotFound(new ResponseModel<List<CategoryDto>>(false,data: null ,"No Categories found"));
            }
            return Ok(new ResponseModel<List<CategoryDto>>(true, categories));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<CategoryDto>>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(new ResponseModel<CategoryDto>(false, data: null, "No category found"));
            }

            return Ok(new ResponseModel<CategoryDto>(true, category));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<CategoryDto>>> SaveCategory(CategoryDto categoryDto)
        {
            try
            {
                return Ok(new ResponseModel<CategoryDto>(true, await _categoryService.SaveCategory(categoryDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<CategoryDto>(false, null!, ex.Message));
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseModel<CategoryDto>>> UpdateCategory(int CategoryId, CategoryDto categoryDto)
        {
            if(CategoryId != categoryDto.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(new ResponseModel<CategoryDto>(true, await _categoryService.UpdateCategory(CategoryId, categoryDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<CategoryDto>>> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<List<CategoryDto>>( false, null , ex.Message));
            }
        }

    }
}
