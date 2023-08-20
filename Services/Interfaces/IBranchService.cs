using ComplaintSystem.Dtos.Pagination;
using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IBranchService
    {
        Task<List<BranchDto>> GetAllBranches();
       
        Task<BranchDto> GetBranchById(int id);
        Task<BranchDto> SaveBranch(BranchDto BranchDto);
        Task<BranchDto> UpdateBranch(int BranchId, BranchDto BranchDto);
        Task<int> DeleteBranchById(int BranchId);
        Task<List<BranchDto>> GetBranchByMunicipalityId(int MunicipalityId);
    }
}
