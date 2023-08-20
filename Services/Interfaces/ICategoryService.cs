using ComplaintSystem.Dtos;
using ComplaintSystem.Dtos.Pagination;

namespace ComplaintSystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<PagedListDto<CategoryDto>> GetAllCategoriesUsingPagination(PagingParams pagingParams);
        Task<CategoryDto> GetCategoryById(int id);
        Task<CategoryDto> SaveCategory(CategoryDto categoryDto);
        Task<CategoryDto> UpdateCategory(int CategoryId, CategoryDto categoryDto);
        Task<int> DeleteCategoryById(int CategoryId);
        Task<List<CategoryDto>> GetCategoryByDepartmentId(int DepartmentId);

    }
}
