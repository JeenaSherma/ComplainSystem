using AutoMapper;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Services.Interfaces;

namespace ComplaintSystem.Services.Implementations
{
   
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetAllDepartment()
        {
            try
            {
                var departments = await uow.Repository<Department>().GetAll();
                var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);
               
                return departmentDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occurred while getting the departments", ex);
            }
        }


        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            try
            {
                var department = await uow.Repository<Department>().GetById(id);
                var departmentDto = _mapper.Map<DepartmentDto>(department);
                return departmentDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while getting the department", ex);
            }
        }

        public async Task<DepartmentDto> SaveDepartment(DepartmentDto departmentDto)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentDto);
                await uow.Repository<Department>().Add(department);
                await uow.SaveChangesAsync();
                var responseDepartment = uow.Repository<Department>().GetAllIncluding(x => x.Municipality).Result.First(x => x.Id == department.Id);
                return _mapper.Map<DepartmentDto>(responseDepartment);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while saving data in database", ex);
            }
        }

        public async Task<DepartmentDto> UpdateDepartment(int DepartmentID, DepartmentDto departmentDto)
        {
            try
            {
                var department = await uow.Repository<Department>().GetById(DepartmentID) ?? throw new Exception("Department not found");
                _mapper.Map(departmentDto, department);
                await uow.SaveChangesAsync();
                return _mapper.Map<DepartmentDto>(department);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the department.", ex);  
            }

        }
        public async Task<int> DeleteDepartment(int DepartmentID)
        {
            try
            {
                var department = await uow.Repository<Department>().GetById(DepartmentID) ?? throw new Exception("Department not found");
                uow.Repository<Department>().Delete(department);
                return await uow.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occured while deleting department", ex);
            }
        }

    }
}
