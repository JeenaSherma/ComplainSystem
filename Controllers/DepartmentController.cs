using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ComplaintSystem.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]
          public async Task<ActionResult<ResponseModel<List<DepartmentDto>>>> GetDepartment()
        {
            var department = await _departmentService.GetAllDepartment();
            if (department == null)
            {
                return NotFound(new ResponseModel<List<DepartmentDto>>(false, data: null!, "No departments found."));

            }
            return Ok(new ResponseModel<List<DepartmentDto>>(true, department));
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<DepartmentDto>>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound(new ResponseModel<DepartmentDto>(false, data: null, "No Department Found"));
            }
            return Ok(new ResponseModel<DepartmentDto>(true, department));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<DepartmentDto>>> SaveDepartment(DepartmentDto departmentDto)
        {
            try
            {
                return Ok(new ResponseModel<DepartmentDto>(true, await _departmentService.SaveDepartment(departmentDto)));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<DepartmentDto>(false, null! , ex.Message));
            }
        }
        [HttpPatch("{id}")]
        public async Task <IActionResult> PutDepartment(int id,  DepartmentDto departmentDto)
        {
            if (id != departmentDto.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(new ResponseModel<DepartmentDto>(true, await _departmentService.UpdateDepartment(id, departmentDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _departmentService.DeleteDepartment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<List<DepartmentDto>>(false, null!, ex.Message));
            }
        }

    }

}
