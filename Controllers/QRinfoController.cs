using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Implementations;
using ComplaintSystem.Services.Interfaces;
using ComplaintSystem.Services.QRGeneration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace ComplaintSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QRinfoController : ControllerBase
    {
        private readonly IQRInfoService _qRInfoService;
        private readonly IQrCodeService _qrCodeService;

        public QRinfoController(IQRInfoService qRInfoService, IQrCodeService qrCodeService)
        {
            this._qRInfoService = qRInfoService;
            this._qrCodeService = qrCodeService;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<QRinfoDto>>>> GetAllQRinfos()
        {
            var qrInfos = await _qRInfoService.GetAllQRInfo();
            if (qrInfos == null)
            {
                return NotFound(new ResponseModel<List<QRinfoDto>>(false, data: null, "No qr found"));
            }
            return Ok(new ResponseModel<List<QRinfoDto>>(true, qrInfos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<QRinfoDto>>> GetQrById(int id)
        {
            var qrInfo = await _qRInfoService.GetQRInfobyId(id);
            if(qrInfo == null)
            {
                return NotFound(new ResponseModel<QRinfoDto>(false, data: null, "No qr found"));
            }
            return Ok(new ResponseModel<QRinfoDto> (true, qrInfo));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<QRinfoDto>>> GenerateQrCode(QRinfoDto qRinfoDto)
        {
            try
            {
                string qrCodeText = qRinfoDto.QRCodeText;
                int pixelSize = 50;
                byte[] qrCodeBytes = _qrCodeService.GenerateQRCode(qrCodeText, pixelSize);

                // Save the QR code image to the database
                qRinfoDto.QRImagePath = "qr_code.png";
                await _qRInfoService.SaveQRInfo(qRinfoDto);
                
                return File(qrCodeBytes, "image/png", "qr_code.png");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<QRinfoDto>(false, null!, ex.Message));
            }
        }

       [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseModel<QRinfoDto>>> UpdateQRInfo(int id, QRinfoDto qRinfoDto)
        {
            if(id != qRinfoDto.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(new ResponseModel<QRinfoDto>(true, await _qRInfoService.UpdateQRInfo(id, qRinfoDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")] 
        public async Task<ActionResult<ResponseModel<QRinfoDto>>> DeleteQrInfo(int id)
        {
            try
            {
                await _qRInfoService.DeleteQRInfo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<List<DepartmentDto>>(false, null!, ex.Message));
            }
        }
        


    }
}
