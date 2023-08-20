using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IComplainStatusService
    {
        Task<List<ComplainStatusDto>> GetAllComplainStatus();
        Task<ComplainStatusDto> GetComplainStatusById(int id);
        Task<ComplainStatusDto> SaveComplainStatus(ComplainStatusDto ComplainStatusDto);
        Task<int> DeleteComplainStatus(int ComplainStatusID);
        Task<ComplainStatusDto> UpdateComplainStatus(int ComplainId, int newStatusId);
    }
}
