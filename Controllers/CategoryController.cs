using ComplaintSystem.Dtos;
using ComplaintSystem.Dtos.Pagination;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUrlHelper _urlHelper;
       
        public CategoryController(ICategoryService categoryService, IUrlHelper urlHelper)
        {
            this._categoryService = categoryService;
            this._urlHelper = urlHelper;
            
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


        //[HttpGet("Pagination", Name = "GetAllCategoriesByPagination")]
        // public async Task<ActionResult<PagedResponse<CategoryDto>>> GetAllCategoriesByPagination([FromQuery] PagingParams pagingParams)
        // {
        //     try
        //     {
        //         var pagedCategoriesDto = await _categoryService.GetAllCategoriesUsingPagination(pagingParams);

        //         var outputModel = new OutputModel<CategoryDto>
        //         {
        //             Paging = pagedCategoriesDto.GetHeader(),
        //             Items = pagedCategoriesDto.List
        //         };


        //         var pagedListDto = new PagedListDto<CategoryDto>(outputModel.Items, outputModel.Paging.PageNumber, outputModel.Paging.PageSize);

        //         var links = PaginationHelper.GetLinks(pagedCategoriesDto, _urlHelper, "GetAllCategoriesByPagination");

        //         var response = new PagedResponse<CategoryDto>(pagedListDto, links);

        //         return Ok(response);
        //     }
        //     catch (Exception ex)
        //     {
        //         var errorResponse = new ResponseModel<PagedListDto<CategoryDto>>(false, null, $"An error occurred: {ex.Message}");
        //         return StatusCode(500, errorResponse);
        //     }
        // }

        //[HttpGet("Pagination", Name = "GetAllCategories")]
        //public async Task<IActionResult> GetAllC([FromQuery] PagingParams pagingParams)
        //{


        //    var pagedCategoriesDto = await _categoryService.GetAllCategoriesUsingPagination(pagingParams);


        //    Response.Headers.Add("X-Pagination", pagedCategoriesDto.GetHeader().ToJson());

        //    var outputModel = new OutputModel<CategoryDto>
        //    {
        //        Paging = pagedCategoriesDto.GetHeader(),
        //        Links = PaginationHelper.GetLinks(pagedCategoriesDto, _urlHelper, "GetAllCategories"),

        //        Items = pagedCategoriesDto.List,
        //    };
        //    return Ok(outputModel);

        //}
        [HttpGet("Pagination", Name = "GetAllCategories")]
        public async Task<ActionResult<ResponseModel<OutputModel<CategoryDto>>>> GetAllC([FromQuery] PagingParams pagingParams)
        {
            try
            {
                var pagedCategoriesDto = await _categoryService.GetAllCategoriesUsingPagination(pagingParams);

                var outputModel = new OutputModel<CategoryDto>
                {
                    Paging = pagedCategoriesDto.GetHeader(),
                    Links = PaginationHelper.GetLinks(pagedCategoriesDto, _urlHelper, "GetAllCategories"),
                    Items = pagedCategoriesDto.List,
                };

                var responseModel = new ResponseModel<OutputModel<CategoryDto>>(true, outputModel);

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseModel<OutputModel<CategoryDto>>(false, null, $"An error occurred: {ex.Message}");
                return StatusCode(500, errorResponse);
            }
        }



        [HttpGet("GetByDepartmentId")]
        public async Task<ActionResult<ResponseModel<List<CategoryDto>>>> GetAllCategoriesByDepartmentId(int DepartmentId) 
        {
            var categories = await  _categoryService.GetCategoryByDepartmentId(DepartmentId);
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
