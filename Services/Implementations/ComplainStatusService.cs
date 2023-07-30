using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;

namespace ComplaintSystem.Services.Implementations
{
    public class ComplainStatusService : IComplainStatusService
    {
        
            private readonly IUnitOfWork uow;
            private readonly IMapper _mapper;

            public ComplainStatusService(IUnitOfWork unitOfWork, IMapper mapper)
            {
                uow = unitOfWork;
                this._mapper = mapper;
            }

            public async Task<List<ComplainStatusDto>> GetAllComplainStatus()
            {
                try
                {
                    var ComplainStatuss = await uow.Repository<ComplainStatus>().GetAll();
                    var ComplainStatusDtos = _mapper.Map<List<ComplainStatusDto>>(ComplainStatuss);
                    return ComplainStatusDtos;
                }
                catch (Exception ex)
                {
                    throw new Exception("An Error occurred while getting the ComplainStatuss", ex);
                }
            }


            public async Task<ComplainStatusDto> GetComplainStatusById(int id)
            {
                try
                {
                    var ComplainStatus = await uow.Repository<ComplainStatus>().GetById(id);
                    var ComplainStatusDto = _mapper.Map<ComplainStatusDto>(ComplainStatus);
                    return ComplainStatusDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("An Error occured while getting the ComplainStatus", ex);
                }
            }

            public async Task<ComplainStatusDto> SaveComplainStatus(ComplainStatusDto ComplainStatusDto)
            {
                try
                {
                    var ComplainStatus = _mapper.Map<ComplainStatus>(ComplainStatusDto);
                    await uow.Repository<ComplainStatus>().Add(ComplainStatus);
                    await uow.SaveChangesAsync();
                    return _mapper.Map<ComplainStatusDto>(ComplainStatus);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occured while saving data in database", ex);
                }
            }

            public async Task<ComplainStatusDto> UpdateComplainStatus(int ComplainStatusID, ComplainStatusDto ComplainStatusDto)
            {
                try
                {
                    var ComplainStatus = await uow.Repository<ComplainStatus>().GetById(ComplainStatusID) ?? throw new Exception("ComplainStatus not found");
                    _mapper.Map(ComplainStatusDto, ComplainStatus);
                    await uow.SaveChangesAsync();
                    return _mapper.Map<ComplainStatusDto>(ComplainStatus);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while updating the ComplainStatus.", ex);
                }

            }
            public async Task<int> DeleteComplainStatus(int ComplainStatusID)
            {
                try
                {
                    var ComplainStatus = await uow.Repository<ComplainStatus>().GetById(ComplainStatusID) ?? throw new Exception("ComplainStatus not found");
                    uow.Repository<ComplainStatus>().Delete(ComplainStatus);
                    return await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occured while deleting ComplainStatus", ex);
                }
            }

        }
    }
