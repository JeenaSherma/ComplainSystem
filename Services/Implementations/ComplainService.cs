using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using System.Linq.Expressions;

namespace ComplaintSystem.Services.Implementations
{
    public class ComplainService : IComplainService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ComplainService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<List<ComplainDto>> GetAllComplains()
        {
            try
            {
                var companies = await _uow.Repository<Complain>().GetAll();
                var companiesDto = _mapper.Map<List<ComplainDto>>(companies);
                return companiesDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Complains", ex);
            }

        }

        public async Task<ComplainDto> GetComplainById(int ComplainId)
        {
            try
            {
                var complain = await _uow.Repository<Complain>().GetById(ComplainId);
                var camplainDto = _mapper.Map<ComplainDto>(complain);
                return camplainDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting complain", ex);
            }
        }

        public async Task<ComplainDto> SaveComplain(ComplainDto complainDto)
        {
            try
            {
                var complain = _mapper.Map<Complain>(complainDto);
                await _uow.Repository<Complain>().Add(complain);
                await _uow.SaveChangesAsync();
                return _mapper.Map<ComplainDto>(complain);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while saving complain", ex);
            }

        }
        public async Task<int> DeleteComplain(int ComplainId)
        {
            try
            {
                var complain = await _uow.Repository<Complain>().GetById(ComplainId) ?? throw new Exception("Complain not found");
                _uow.Repository<Complain>().Delete(complain);
                return await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while deleting complain",ex);
            }
        }
    }
}
