
using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartment();
        Task<DepartmentDto> GetDepartmentById(int id);
        Task<DepartmentDto> SaveDepartment(DepartmentDto departmentDto);
        Task<DepartmentDto> UpdateDepartment(int DepartmentID , DepartmentDto departmentDto);
        Task<int> DeleteDepartment(int DepartmentID);
    }
}
