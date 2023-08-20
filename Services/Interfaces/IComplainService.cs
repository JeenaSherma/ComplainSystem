using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IComplainService
    {
        Task<List<ComplainDto>> GetAllComplains();
        Task<ComplainDetailsDto> GetComplainById(int ComplainId);
        //Task<ComplainDto> SaveComplain(ComplainDto complainDto);
        Task<ComplainAndComplainInfoDto> SaveComplainandComplainInfo(ComplainAndComplainInfoDto complainAndComplainInfoDto);
        Task<int> DeleteComplain(int ComplainId);
        Task<List<ComplainDetailsDto>> GetAllComplainDetails();
        Task<ComplainDetailsDto> GetComplainDetailsAndStatusByToken(string tokenValue);
        Task<List<ComplainDetailsDto>> GetComplainDetailsByCategoryId(int categoryId);
        Task<List<ComplainDetailsDto>> GetComplainDetailsByBranchId(int branchId);

    }
}
