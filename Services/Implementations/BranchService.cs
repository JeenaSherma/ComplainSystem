using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Dtos.Pagination;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplaintSystem.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<BranchDto>> GetAllBranches()
        {
            try { 
            var branches = unitOfWork.Repository<Ward>().GetAllIncluding(b => b.Municipality);
            var branchDto = mapper.Map<List<BranchDto>>(branches);
            return branchDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while loading the branches", ex);
            }
        }

  

        public async Task<BranchDto> GetBranchById(int id)
        {
            try
            {
                var branch = unitOfWork.Repository<Ward>().GetAllIncluding(b => b.Municipality).Result.Where(b => b.Id == id);
                var branchDto = mapper.Map<BranchDto>(branch);
                return branchDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while loading the branch by ID", ex);
            }

        }

       public async Task<List<BranchDto>> GetBranchByMunicipalityId(int MunicipalityId)
        {
            try
            {
             var branches = await unitOfWork.Repository<Ward>().GetAllIncluding(x=>x.Municipality);
                var filterefBranches = branches.Where(x=>x.MunicipalityId == MunicipalityId).ToList();
                var branchDto = mapper.Map<List<BranchDto>>(filterefBranches);
                return branchDto;
            }
            catch(Exception ex)
            {
                throw new Exception("Errror occured while getting branches");
            }   
        }

        public async Task<BranchDto> SaveBranch(BranchDto BranchDto)
        {
            try
            {
                var branch = mapper.Map<Ward>(BranchDto);
                await unitOfWork.Repository<Ward>().Add(branch);
                await unitOfWork.SaveChangesAsync();
                return mapper.Map<BranchDto>(branch);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the branch.", ex);
            }
        }
        
      
        public async Task<BranchDto> UpdateBranch(int BranchId, BranchDto BranchDto)
        {
            try
            {
                var branch = await unitOfWork.Repository<Ward>().GetById(BranchId) ?? throw new Exception("Branch not found");
                mapper.Map(BranchDto, branch);
                await unitOfWork.SaveChangesAsync();
                return mapper.Map<BranchDto>(branch);
            }
            catch (Exception ex)
            {
                throw new Exception("Branch cannot be updated", ex);
            }
        }
        public async Task<int> DeleteBranchById(int BranchId)
        {
            try
            {
                var branch = await unitOfWork.Repository<Ward>().GetById(BranchId) ?? throw new Exception("category not found");
                unitOfWork.Repository<Ward>().Delete(branch);
                return await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete Category", ex);
            }
        }

    }
}
