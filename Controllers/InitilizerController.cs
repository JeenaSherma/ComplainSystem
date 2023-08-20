using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Implementations;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitilizerController : ControllerBase
    {
        private readonly IInitilizerService initilizerService;

        public InitilizerController(IInitilizerService initilizerService)
        {
            this.initilizerService = initilizerService;
        }

        //[HttpPost]
        //public async Task<ActionResult<ResponseModel<InitializeDto>>> SaveWardDetails(InitializeDto initializeDto)
        //{
        //    try
        //    {
        //        return Ok(new ResponseModel<InitializeDto>(true, await initilizerService.GetBranchByMuniciplaityId(initializeDto)));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<CategoryDto>(false, null!, ex.Message));
        //    }
        //}
        [HttpPost]
        public async Task<ActionResult<ResponseModel<InitializeDto>>> Initalize(InitializeDto initializeDto)
        {
            try
            {
                return Ok(new ResponseModel<InitializeDto>(true, await initilizerService.Initialize(initializeDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<CategoryDto>(false, null!, ex.Message));
            }
        }
    }
}
