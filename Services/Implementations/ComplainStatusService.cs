using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Implementations;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;

namespace ComplaintSystem.Services.Implementations
{
    public class ComplainStatusService : IComplainStatusService
    {
        
            private readonly IUnitOfWork uow;
            private readonly IMapper _mapper;
        private readonly IEmailSenderService _emailSenderService;

        public ComplainStatusService(IUnitOfWork unitOfWork, IMapper mapper, IEmailSenderService emailSenderService)
            {
                uow = unitOfWork;
                this._mapper = mapper;
            this._emailSenderService = emailSenderService;
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
        public async Task<ComplainStatusDto> UpdateComplainStatus(int complainId, int newStatusId)
        {

            try
            {
                var complain = uow.Repository<Complain>().GetAllIncluding(c => c.ComplainerInfo).Result.Where(c => c.Id == complainId).FirstOrDefault();
                if (complain == null)
                {
                    throw new Exception("Complain not found");
                }

                var complainStatus = await uow.Repository<ComplainStatus>().GetById(newStatusId);
                if (complainStatus == null)
                {
                    throw new Exception("Invalid status ID");
                }

                complain.ComplainStatusId = newStatusId;
                await uow.SaveChangesAsync();

                if (newStatusId == 5 || newStatusId == 6)
                {
                    ComplainerInfo complainerInfo = complain.ComplainerInfo;
                    if (complainerInfo != null)
                    {
                        string userName = complainerInfo.Name;
                        string email = complainerInfo.Email;
                        string message = newStatusId == 5 ? "Dear " + userName + ", Your complain status is halted" : "Dear " + userName + ",  Your complain status is completed.";

                        EmailSenderService emailSenderService = new EmailSenderService();
                        emailSenderService.SendEmail(email, userName, message);
                    }
                }

                var updatedComplainStatusDto = _mapper.Map<ComplainStatusDto>(complainStatus);
                return updatedComplainStatusDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating complain status", ex);
            }
        }
    }

}
