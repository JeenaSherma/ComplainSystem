using AutoMapper;
using ComplaintSystem.DbContext;
using ComplaintSystem.Dtos;
using ComplaintSystem.Dtos.Identity;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Implementations;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ComplaintSystem.Services.Implementations
{
    public class InitilizerService : IInitilizerService

    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InitilizerService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
      
        public async Task<InitializeDto> Initialize(InitializeDto initilizerDto)
        {
            try
            {
                var municipality = await unitOfWork.Repository<Municipality>().GetById(initilizerDto.MunicipalityId);
                var branchType = await unitOfWork.Repository<BranchType>().GetAll();
                #region Creating Municipality Branch

                Branch municipalityBranch = new()
                {
                    BranchNameInEnglish = municipality.MunicipalityNameInEnglish,
                    BranchNameInNepali = municipality.MunicipalityNameInNepali,
                    Municipality = municipality,
                    BranchType = branchType.First(x=>x.Type == "Municipality"),
                    Address =  initilizerDto.Address,
                    Email = initilizerDto.Email,
                    OfficialWebsite = initilizerDto.OfficialWebsite,
                    PhoneNumber= initilizerDto.PhoneNumber
                };
                await unitOfWork.Repository<Branch>().Add(municipalityBranch);

                await unitOfWork.SaveChangesAsync();
                #endregion

                #region Create Municipal Admin
                var municipalityAdmin = new ApplicationUser
                {
                    UserName = "MunicipalityAdmin",
                    Email = "MunicipalityAdmin@admin.com",
                    BranchId = municipalityBranch.Id
                };

                var result = _userManager.CreateAsync(municipalityAdmin, "Admin@123").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(municipalityAdmin, "MunicipalityAdmin").GetAwaiter().GetResult();
                    await unitOfWork.SaveChangesAsync();
                }
                #endregion

                #region Creating Ward branches

                for (int i = 1; i < (initilizerDto.NumberOfWards); i++)
                {
                    Branch wardBranch = new()
                    {
                        BranchNameInEnglish = municipality.MunicipalityNameInEnglish + " Ward " + i,
                        BranchNameInNepali = municipality.MunicipalityNameInNepali + " Nepali ma ward " + i,
                        BranchType = branchType.First(x => x.Type == "Ward"),
                        //Address = "Get From Initializer",
                        //Email = "Get From Initializer",
                        //OfficialWebsite = "Get From Initializer",
                        //PhoneNumber = "Get From Initializer",
                        //WardNo = i,
                    };
                    await unitOfWork.Repository<Branch>().Add(wardBranch);

                    var wardAdmin = new ApplicationUser
                    {
                        UserName = "wardAdmin"+i,
                        Email = "ward"+i+"@admin.com",
                        BranchId = wardBranch.Id
                    };

                    result = _userManager.CreateAsync(wardAdmin, "Admin@123").Result;
                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(municipalityAdmin, "WardAdmin").GetAwaiter().GetResult();
                        await unitOfWork.SaveChangesAsync();
                    }
                }
                #endregion

                return initilizerDto;

            }
            catch (Exception ex)
            {

                throw new Exception("Error loading data", ex);
            }

        }
    }
}
