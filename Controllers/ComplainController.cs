using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        private readonly IComplainService _complainService;

        public ComplainController(IComplainService complainService)
        {
            this._complainService = complainService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ComplainDto>>>> GetAllComplains()
        {
            var complains = await _complainService.GetAllComplains();
            if (complains == null)
            {
                return NotFound(new ResponseModel<List<ComplainDto>>(false, data: null, "No Complains were found"));
            }
            return Ok(new ResponseModel<List<ComplainDto>>(true, complains));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<ComplainDto>>> GetComplainById(int id)
        {
            var complain = await _complainService.GetComplainById(id);
            if (complain == null)
            {
                return NotFound(new ResponseModel<ComplainDto>(false, data: null, "No complain was found"));
            }
            return Ok(new ResponseModel<ComplainDto>(true, complain));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ComplainDto>>> SaveComplain(ComplainDto complainDto)
        {
            try
            {
                return Ok(new ResponseModel<ComplainDto>(true, await _complainService.SaveComplain(complainDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<DepartmentDto>(false, null!, ex.Message));

            }
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<ResponseModel<ComplainDto>>> DeleteComplain(int id)
        {
            try
            {
                await _complainService.DeleteComplain(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseModel<List<ComplainDto>>(false, null!, ex.Message));
            }
        }
    }
}
