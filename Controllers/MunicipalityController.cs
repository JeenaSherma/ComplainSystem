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
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService) 
        {
            this._municipalityService = municipalityService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<MunicipalityDto>>>> GetAllMunicipality()
        {
            var municipality = await _municipalityService.GetAllMunicipality();
            if(municipality == null)
            {
                return NotFound(new ResponseModel<List<MunicipalityDto>>(false,data:null, "No Address Titles found."));
            }
            return Ok(new ResponseModel<List<MunicipalityDto>>(true, municipality));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<MunicipalityDto>>> GetMunicipalityById(int id)
        {
            var municipality = await _municipalityService.GetMunicipalityById(id);
            if(municipality == null)
            {
                return NotFound(new ResponseModel<MunicipalityDto>(false, data: null, "No Municipality Found"));
            }
            return Ok(new ResponseModel<MunicipalityDto>(true, municipality));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<MunicipalityDto>>> SaveMunicipality(MunicipalityDto municipalityDto)
        {
            try
            {
                return Ok(new ResponseModel<MunicipalityDto>(true, await _municipalityService.SaveMunicipality(municipalityDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<MunicipalityDto>(false, null!, ex.Message));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PutMunicipality(int id, MunicipalityDto municipalityDto)
        {
            if (id != municipalityDto.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(new ResponseModel<MunicipalityDto>(true, await _municipalityService.UpdateMunicipality(id, municipalityDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteMunicipality(int id)
        {
            try
            {
                await _municipalityService.DeleteMunicipality(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<List<MunicipalityDto>>(false, null!, ex.Message));
            }
        }

    }
}
