using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Implementations;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService) 
        {
            this.branchService = branchService;
        }

       // [HttpGet]
        //public async Task<ActionResult> GetAllBranches(int municipalityId)
        //{
        //    var branches = await branchService.GenerateBranchesForMunicipality(municipalityId);
        //    if (branches == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok();
        //}

    }
}
