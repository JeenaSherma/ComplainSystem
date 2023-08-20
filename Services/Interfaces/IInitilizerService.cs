using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IInitilizerService
    {
        //Task<InitializeDto> GetBranchByMuniciplaityId(InitializeDto initializeDto);
        Task<InitializeDto> Initialize(InitializeDto initializeDto);
    }
}
