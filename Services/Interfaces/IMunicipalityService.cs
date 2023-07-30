using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IMunicipalityService
    {
        Task<List<MunicipalityDto>> GetAllMunicipality();
        Task<MunicipalityDto> GetMunicipalityById(int id);
        Task<MunicipalityDto> SaveMunicipality(MunicipalityDto municipalityDto);
        Task<MunicipalityDto> UpdateMunicipality(int MunicipalityId, MunicipalityDto municipalityDto);
        Task<int> DeleteMunicipality(int MunicipalityId);
    }
}
