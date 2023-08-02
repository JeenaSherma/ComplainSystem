using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;

namespace ComplaintSystem.Services.Implementations
{
    public class ComplainerInfoService : IComplainerInfoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ComplainerInfoService(IUnitOfWork uow, IMapper mapper) 
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public async Task<List<ComplainerInfoDto>> GetAllComplainerInfo()
        {
            try
            {        
            var complainerInfos = await _uow.Repository<ComplainerInfo>().GetAll();
            var complainerInfosDto = _mapper.Map<List<ComplainerInfoDto>>(complainerInfos);
              
             return complainerInfosDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all the complainerInfo",ex);
            }
        }

        public async Task<ComplainerInfoDto> GetComplainerInfoById(int ComplainerInfoId)
        {
            try
            {
                var complainerInfo = await _uow.Repository<ComplainerInfo>().GetById(ComplainerInfoId);
                var complainerInfoDto = _mapper.Map<ComplainerInfoDto>(complainerInfo);
                return complainerInfoDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting complainerinfo", ex);
            }
        }

        public async Task<ComplainerInfoDto> SaveComplainerInfo(ComplainerInfoDto complainerInfoDto)
        {
            try
            {
               var complainerInfo=  _mapper.Map<ComplainerInfo>(complainerInfoDto);
                await _uow.Repository<ComplainerInfo>().Add(complainerInfo);
                await _uow.SaveChangesAsync();
                var ResponseComplainerInfo = _uow.Repository<ComplainerInfo>().GetAllIncluding(x => x.Complain).Result.First(x => x.Id== complainerInfo.Id);
                return _mapper.Map<ComplainerInfoDto>(ResponseComplainerInfo);
            }
            catch(Exception ex)
            {
                throw new Exception("Error while saving Complainer Info",ex);
            }
        }
        public async Task<int> DeleteComplainerInfo(int ComplaierInfoId)
        {
            try
            {
                var complainerInfo = await _uow.Repository<ComplainerInfo>().GetById(ComplaierInfoId) ?? throw new Exception("No complainer Info Found");
                _uow.Repository<ComplainerInfo>().Delete(complainerInfo);
                return await _uow.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Error while deleting the complainer Info", e);
            }
        }
    }
}
