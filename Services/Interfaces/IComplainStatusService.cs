using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IComplainStatusService
    {
        Task<List<ComplainStatusDto>> GetAllComplainStatus();
        Task<ComplainStatusDto> GetComplainStatusById(int id);
        Task<ComplainStatusDto> SaveComplainStatus(ComplainStatusDto ComplainStatusDto);
        Task<ComplainStatusDto> UpdateComplainStatus(int ComplainStatusID, ComplainStatusDto ComplainStatusDto);
        Task<int> DeleteComplainStatus(int ComplainStatusID);
    }
}
