using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IQRInfoService
    {
        Task<List<QRinfoDto>> GetAllQRInfo();
        Task<QRinfoDto> GetQRInfobyId(int QRId);
        Task<QRinfoDto> SaveQRInfo(QRinfoDto QRInfoDto);
        Task<QRinfoDto> UpdateQRInfo(int QRId, QRinfoDto QRInfoDto);
        Task <int>DeleteQRInfo(int QRId);
    }
}
