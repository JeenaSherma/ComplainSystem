using ComplaintSystem.Dtos;
using ComplaintSystem.Model;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IComplainerInfoService
    {
        Task<List<ComplainerInfoDto>> GetAllComplainerInfo();   
        Task<ComplainerInfoDto> GetComplainerInfoById(int ComplainerInfoId);
        Task<ComplainerInfoDto> SaveComplainerInfo(ComplainerInfoDto complainerInfoDto);
        Task<int> DeleteComplainerInfo(int ComplaierInfoId);
    }
}
