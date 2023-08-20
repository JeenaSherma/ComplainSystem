using AutoMapper;
using ComplaintSystem.DbContext;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Implementations;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using System.Linq.Expressions;

namespace ComplaintSystem.Services.Implementations
{
    public class ComplainService : IComplainService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEmailSenderService emailSenderService;

        public ComplainService(IUnitOfWork uow, IMapper mapper, ITokenService tokenService, IEmailSenderService emailSenderService)
        {
            this._uow = uow;
            this._mapper = mapper;
            this._tokenService = tokenService;
            this.emailSenderService = emailSenderService;
        }
        public async Task<List<ComplainDto>> GetAllComplains()
        {
            try
            {
                var companies = await _uow.Repository<Complain>().GetAllIncluding(x => x.Token);
                var companiesDto = _mapper.Map<List<ComplainDto>>(companies);
                return companiesDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Complains", ex);
            }

        }
        public async Task<List<ComplainDetailsDto>> GetAllComplainDetails()
        {
            try
            {
                var complainDetails = await _uow.Repository<Complain>().GetAllIncluding(c => c.ComplainerInfo, c => c.ComplainStatus, c => c.Category);
                var complainDetailsDto = _mapper.Map<List<ComplainDetailsDto>>(complainDetails);
                return complainDetailsDto;
            }
            catch (Exception ex)
            {
                throw new Exception("error loading list of complains", ex);
            }
        }
        public async Task<List<ComplainDetailsDto>> GetComplainDetailsByBranchId(int branchId)
        {
            try
            {
                var complains = await _uow.Repository<Complain>().GetAllIncluding(c => c.ComplainerInfo, c => c.ComplainStatus, c => c.Category);
                var fileterdComplains = complains.Where(c=>c.Id == branchId).ToList();
                var complainDetailsDto = _mapper.Map<List<ComplainDetailsDto>>(complains);
                return complainDetailsDto;
            }
            catch (Exception ex) 
            {
                throw new Exception("error loading list of complains", ex);
            }
        }
        public async Task<ComplainDetailsDto> GetComplainById(int ComplainId)
        {
            try
            {
                var complain =await _uow.Repository<Complain>().GetAllIncluding(c => c.ComplainerInfo, c => c.ComplainStatus, c => c.Category);
                
                var filteredComplain = complain.SingleOrDefault(c => c.Id == ComplainId);

                if (filteredComplain != null)
                {
                    var complainDto = _mapper.Map<ComplainDetailsDto>(filteredComplain);
                    return complainDto;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting complain", ex);
            }
        }
        public async Task<ComplainDetailsDto> GetComplainDetailsAndStatusByToken(string tokenValue)
        {
            try
            {
                Token token = await _uow.Repository<Token>().FirstOrDefaultAsync(t => t.TokenValue == tokenValue);
                if (token == null)
                {
                    throw new Exception("Token not found in the database.");
                }
                var complainID = token.ComplainId;
                var complain = _uow.Repository<Complain>().GetAllIncluding(c => c.ComplainerInfo, c => c.ComplainStatus, c => c.Category).Result.FirstOrDefault(c => c.Id == complainID);

                var complainDto = _mapper.Map<ComplainDetailsDto>(complain);
                return complainDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting data", ex);
            }
        }
        public async Task<List<ComplainDetailsDto>> GetComplainDetailsByCategoryId(int categoryId)
        {
            try
            {
                var complain = _uow.Repository<Complain>().GetAllIncluding(c => c.ComplainerInfo, c => c.ComplainStatus, c => c.Category).Result.Where(c=>c.CategoryId == categoryId);
                var complainDto = _mapper.Map<List<ComplainDetailsDto>>(complain);
                return complainDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting data", ex);
            }
        }

        public async Task<ComplainAndComplainInfoDto> SaveComplainandComplainInfo(ComplainAndComplainInfoDto complainAndComplainInfoDto)
        {
            try
            {
                ComplainStatus pendingComplainStatus = await _uow.Repository<ComplainStatus>()
                    .FirstOrDefaultAsync(cs => cs.Status == "Pending");
                complainAndComplainInfoDto.ComplainStatusId = pendingComplainStatus.Id;

                var complain = _mapper.Map<Complain>(complainAndComplainInfoDto);
                await _uow.Repository<Complain>().Add(complain);
                await _uow.SaveChangesAsync();

                var complainId = complain.Id;
                var complainInfo = _mapper.Map<ComplainerInfo>(complainAndComplainInfoDto);
                complainInfo.ComplainId = complainId;
                await _uow.Repository<ComplainerInfo>().Add(complainInfo);
                await _uow.SaveChangesAsync();

                int tokenComplainId = complain.Id;
                var token = await _tokenService.GenerateAndSaveTokenForComplaint(tokenComplainId);

                var responseComplain = _uow.Repository<Complain>()  
                    .GetAllIncluding(x => x.Token)
                    .Result
                    .First(x => x.Id == complain.Id);

                //Send Email if Email field is not null else return the data
                if(complainAndComplainInfoDto.Email != null) { 
                string userName =complainAndComplainInfoDto.Name;
                string Email = complainAndComplainInfoDto.Email;
                string message = "Dear " + userName+ ", Your complain status is pending";

                 EmailSenderService emailSenderService = new EmailSenderService();
                emailSenderService.SendEmail(Email, userName, message);
                }
                return _mapper.Map<ComplainAndComplainInfoDto>(responseComplain);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving complain", ex);
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
