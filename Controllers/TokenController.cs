using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Implementations;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController( ITokenService tokenService )
        {
            this._tokenService = tokenService;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<TokenDto>>>> GetToken()
        {
            var tokens = await _tokenService.GetAllTokens();
            if (tokens == null)
            {
                return NotFound(new ResponseModel<List<TokenDto>>(false, data: null!, "No tokens found."));

            }
            return Ok(new ResponseModel<List<TokenDto>>(true, tokens));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<TokenDto>>> GetTokenById(int id)
        {
            var token = await _tokenService.GetTokenById(id);
            if (token == null)
            {
                return NotFound(new ResponseModel<TokenDto>(false, data: null!, "No Token Found"));
            }
            return Ok(new ResponseModel<TokenDto>(true,token));
        }

        //[HttpPost]
        //public async Task<ActionResult<ResponseModel<TokenDto>>> SaveToken(int complainId)
        //{
        //    try
        //    {
        //        var TokenDto = await _tokenService.SaveToken(complainId);
        //        return Ok(new ResponseModel<TokenDto>(true, TokenDto));

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<TokenDto>(false, null!, ex.Message));
        //    }
        //}
           
            //[HttpPatch("{id}")]
            //public async Task<IActionResult> UpdateToken(int id, TokenDto TokenDto)
            //{
            //    if (id != TokenDto.Id)
            //    {
            //        return BadRequest();
            //    }
            //    try
            //    {
            //        return Ok(new ResponseModel<TokenDto>(true, await _tokenService.UpdateToken(id, TokenDto)));
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }
            //}

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteToken(int id)
            {
                try
                {
                    await _tokenService.DeleteToken(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(new ResponseModel<List<TokenDto>>(false, null!, ex.Message));
                }
            }

        }
    }

