using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Implementations;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainerInfoController : ControllerBase
    {
        private readonly IComplainerInfoService _complainerInfoService;

        public ComplainerInfoController(IComplainerInfoService complainerInfoService)
        {
            this._complainerInfoService = complainerInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ComplainerInfoDto>>>> GetAllComplainerInfos()
        {
            var complainerInfos = await _complainerInfoService.GetAllComplainerInfo();
            if(complainerInfos == null)
            {
                return NotFound(new ResponseModel<List<ComplainerInfoDto>>(false, data:null, "No complainerInfo found"));
            }
            return Ok(new ResponseModel<List<ComplainerInfoDto>>(true, complainerInfos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComplainerInfoDto>> GetComplainerInfoById(int id)
        {
            var complainerInfo = await _complainerInfoService.GetComplainerInfoById(id);
            if(complainerInfo == null)
            {
                return NotFound(new ResponseModel<ComplainerInfoDto> (false, data:null, "No complainer information found."));
            }
            return Ok(new ResponseModel<ComplainerInfoDto>(true, complainerInfo));
        }

        [HttpPost]
        public async Task<ActionResult<ComplainerInfoDto>> SaveComplainerInfo(ComplainerInfoDto complainerInfoDto)
        {
            try
            {
                return Ok(new ResponseModel<ComplainerInfoDto>(true, await _complainerInfoService.SaveComplainerInfo(complainerInfoDto)));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<DepartmentDto>(false, null!, ex.Message));
            }
        }
        [HttpDelete("{id}")]
         public async Task<ActionResult<ComplainerInfoDto>> DeleteComplainerInfo(int id)
        {
            try
            {
                await _complainerInfoService.DeleteComplainerInfo(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseModel<List<DepartmentDto>>(false, null!, ex.Message));
            }
        }
    }
}
