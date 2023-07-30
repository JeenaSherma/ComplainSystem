using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainStatusController : ControllerBase
    {
        
       
        private readonly IComplainStatusService _complainStatusService;

        public ComplainStatusController(IComplainStatusService complainStatusService)
        {
            this._complainStatusService = complainStatusService;
        }
           

        [HttpGet]
          public async Task<ActionResult<ResponseModel<List<ComplainStatusDto>>>> GetcomplainStatus()
        {
            var complainStatus = await _complainStatusService.GetAllComplainStatus(); 
            if (complainStatus == null)
            {
                return NotFound(new ResponseModel<List<ComplainStatusDto>>(false, data: null!, "No complainStatuss found."));

            }
            return Ok(new ResponseModel<List<ComplainStatusDto>>(true, complainStatus));
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<ComplainStatusDto>>> GetcomplainStatusById(int id)
        {
            var complainStatus = await _complainStatusService.GetComplainStatusById(id);
            if (complainStatus == null)
            {
                return NotFound(new ResponseModel<ComplainStatusDto>(false, data: null, "No complainStatus Found"));
            }
            return Ok(new ResponseModel<ComplainStatusDto>(true, complainStatus));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ComplainStatusDto>>> SavecomplainStatus(ComplainStatusDto ComplainStatusDto)
        {
            try
            {
                return Ok(new ResponseModel<ComplainStatusDto>(true, await _complainStatusService.SaveComplainStatus(ComplainStatusDto)));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ComplainStatusDto>(false, null! , ex.Message));
            }
        }
        [HttpPatch("{id}")]
        public async Task <IActionResult> PutcomplainStatus(int id,  ComplainStatusDto ComplainStatusDto)
        {
            if (id != ComplainStatusDto.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(new ResponseModel<ComplainStatusDto>(true, await _complainStatusService.UpdateComplainStatus(id, ComplainStatusDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletecomplainStatus(int id)
        {
            try
            {
                await _complainStatusService.DeleteComplainStatus(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<List<ComplainStatusDto>>(false, null!, ex.Message));
            }
        }
    }
}
