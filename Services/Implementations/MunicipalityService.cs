using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;

namespace ComplaintSystem.Services.Implementations
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public MunicipalityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<List<MunicipalityDto>> GetAllMunicipality()
        {
            try
            {
                var municipality = await uow.Repository<Municipality>().GetAll();
                var municipalityDto = _mapper.Map<List<MunicipalityDto>>(municipality);

                return municipalityDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occurred while getting the departments", ex);
            }
            
        }

        public async Task<MunicipalityDto> GetMunicipalityById(int id)
        {
            try
            {
                var municipality = await uow.Repository<Municipality>().GetById(id);
                var municipalityDto = _mapper.Map<MunicipalityDto>(municipality);
                return municipalityDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while getting the department", ex);
            }
        }

        public async Task<MunicipalityDto> SaveMunicipality(MunicipalityDto municipalityDto)
        {
            try
            {
                var municipality = _mapper.Map<Municipality>(municipalityDto);
                await uow.Repository<Municipality>().Add(municipality);
                await uow.SaveChangesAsync();
                return _mapper.Map<MunicipalityDto>(municipality);
            }
            catch(Exception ex)
            {
                throw new Exception("An error occured while saving data in database", ex);
            }
        }

        public async Task<MunicipalityDto> UpdateMunicipality(int MunicipalityId, MunicipalityDto municipalityDto)
        {
            try
            {
                var municipality = await uow.Repository<Municipality>().GetById(MunicipalityId) ?? throw new Exception("Department not found");
                _mapper.Map(municipalityDto, municipality);
                await uow.SaveChangesAsync();
                return _mapper.Map<MunicipalityDto>(municipality);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the About Us.", ex);
            }
        }
        public async Task<int> DeleteMunicipality(int MunicipalityId)
        {
            try
            {
                var municipality = await uow.Repository<Municipality>().GetById(MunicipalityId) ?? throw new Exception("Municipality not found");
                uow.Repository<Municipality>().Delete(municipality);
                return await uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while deleting department", ex);
            }
        }

    }
}
