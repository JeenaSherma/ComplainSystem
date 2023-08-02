using ComplaintSystem.Model;

namespace ComplaintSystem.Repository.Interfaces
{
    public interface IQrRepository
    {
        Task<QRinfo> GetQRinfoByMunicipalityId(int municipalityId);
    }
}
