using AutoMapper;
using Azure;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static QRCoder.PayloadGenerator.ShadowSocksConfig;
using System.Runtime.Intrinsics.X86;

namespace ComplaintSystem.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.uow = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            try
            {
                var categories = await uow.Repository<Category>().GetAllIncluding(x=>x.Department);
                var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
                //foreach (var category in categoriesDto)
                //{
                //    var departmentName = await uow.Repository<Department>().GetById(category.DepartmentId);
                //    category.DepartmentName = departmentName.DepartmentName;
                //}

                return categoriesDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occurred while getting the categories", ex);
            }
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            try
            {
                var category = await uow.Repository<Category>().GetById(id);
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return categoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while getting the Category", ex);
            }
        }

        public async Task<List<CategoryDto>> GetCategoryByDepartmentId(int DepartmentId)
        {
            try
            {
                var categories = await uow.Repository<Category>().GetAllIncluding(c => c.Department);

                var filteredCategories = categories.Where(c => c.DepartmentId == DepartmentId).ToList();

                var categoriesDto = _mapper.Map<List<CategoryDto>>(filteredCategories);

                return categoriesDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occurred while getting the categories", ex);
            }
        }










        public async Task<CategoryDto> SaveCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                await uow.Repository<Category>().Add(category);
                await uow.SaveChangesAsync();

                var responseCategory = uow.Repository<Category>().GetAllIncluding(x => x.Department).Result.First(x => x.Id == category.Id);

                return _mapper.Map<CategoryDto>(responseCategory);
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while saving category", ex);
            }
        }

        public async Task<CategoryDto> UpdateCategory(int CategoryId, CategoryDto categoryDto)
        {
            try
            {
                var category = await uow.Repository<Department>().GetById(CategoryId) ?? throw new Exception("Category not found");
                _mapper.Map(categoryDto, category);
                await uow.SaveChangesAsync();
                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Category cannot be updated", ex);
            }
        }
        public async Task<int> DeleteCategoryById(int CategoryId)
        {
            try
            {
                var category = await uow.Repository<Category>().GetById(CategoryId) ?? throw new Exception("category not found");
                uow.Repository<Category>().Delete(category);
                return await uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete Category", ex);
            }
        }

    }
}
