using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Services.Implementations;
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

        [HttpGet("ComplainDetails")]
        public async Task<ActionResult<ResponseModel<List<ComplainDto>>>> GetAllComplainsDetails()
        {
            var complainDetails = await _complainService.GetAllComplainDetails();
            if (complainDetails == null)
            {
                return NotFound(new ResponseModel<List<ComplainDto>>(false, data: null, "No Complains were found"));
            }
            return Ok(new ResponseModel<List<ComplainDetailsDto>>(true, complainDetails));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<ComplainDetailsDto>>> GetComplainById(int id)
        {
            var complain = await _complainService.GetComplainById(id);
            if (complain == null)
            {
                return NotFound(new ResponseModel<ComplainDetailsDto>(false, data: null, "No complain was found"));
            }
            return Ok(new ResponseModel<ComplainDetailsDto>(true, complain));
        }
        [HttpGet("CategoryId")]
        public async Task<ActionResult<ResponseModel<List<ComplainDetailsDto>>>> GetComplainByCategoryId(int categoryId)
        {
            var complains = await _complainService.GetComplainDetailsByCategoryId(categoryId);
            if(complains == null)
            {
                return NotFound(new ResponseModel<List<ComplainDetailsDto>>(false, data: null, "No complains was found for this category."));
            }
            return Ok(new ResponseModel<List<ComplainDetailsDto>>(true, complains));
        }
        
        [HttpPost("ReviewToken")]
        public async Task<ActionResult<ResponseModel<ComplainDetailsDto>>> GetComplainDetailsByToken(string token)
        {
            try
            {
                var complainDetails = await _complainService.GetComplainDetailsAndStatusByToken(token);
                if (complainDetails == null)
                {
                    return NotFound(new ResponseModel<ComplainDetailsDto>(false, data: null, "No complain Information found"));
                }
                return Ok(new ResponseModel<ComplainDetailsDto>(true, complainDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ComplainDetailsDto>>> SaveComplain(ComplainAndComplainInfoDto complainAndComplainInfoDto)
        {
            try
            {
                return Ok(new ResponseModel<ComplainAndComplainInfoDto>(true, await _complainService.SaveComplainandComplainInfo(complainAndComplainInfoDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ComplainAndComplainInfoDto>(false, null!, ex.Message));

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
