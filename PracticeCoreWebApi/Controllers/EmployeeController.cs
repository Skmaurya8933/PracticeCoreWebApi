using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreWebApi.Model;
using PracticeCoreWebApi.Repo;
using System.Net;

namespace PracticeCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDetailRepository _employeeDetailRepository;   
        public EmployeeController(IEmployeeDetailRepository employeeDetailRepository)
        {
            _employeeDetailRepository= employeeDetailRepository;
        }
        [Authorize]
        [HttpPost("AddEmployeeDetail")]
        public async Task<ActionResult<CommonResponseStatus>> AddEmployeeDetail(EmployeeDetail employeeDetail)
        {
            try
            {
                CommonResponseStatus responseStatus = await _employeeDetailRepository.AddEmployeeDetail(employeeDetail);
                if (responseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<CommonResponseStatus> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {
                    var loAPIResponseObj = new APIResultItem<CommonResponseStatus> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Add Data");
            }
        }
        [Authorize]
        [HttpGet("GetAllEmployeeDetail")]
        public async Task<ActionResult<EmployeeDetailResponseModel>> GetAllEmployeeDetail()
        {
            try
            {
                EmployeeDetailResponseModel responseStatus = await _employeeDetailRepository.GetAllEmployeeDetail();
                if (responseStatus.CommonResponseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<EmployeeDetailResponseModel> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {
                    var loAPIResponseObj = new APIResultItem<EmployeeDetailResponseModel> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Get Data");
            }
        }
        [Authorize]
        [HttpPost("UpdateEmployeeDetail")]
        public async Task<ActionResult<CommonResponseStatus>> UpdateEmployeeDetail(EmployeeDetail employeeDetail)
        {
            try
            {
                CommonResponseStatus responseStatus = await _employeeDetailRepository.UpdateEmployeeDetail(employeeDetail);
                if (responseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<CommonResponseStatus> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {
                    var loAPIResponseObj = new APIResultItem<CommonResponseStatus> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating Data");
            }
        }
        [Authorize]
        [HttpGet("DeleteEmployeeDetail")]
        public async Task<ActionResult<CommonResponseStatus>> DeleteEmployeeDetail(int id)
        {
            try
            {
                CommonResponseStatus responseStatus = await _employeeDetailRepository.DeleteEmployeeDetail(id);
                if (responseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<CommonResponseStatus> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {
                    var loAPIResponseObj = new APIResultItem<CommonResponseStatus> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Deleting Data");
            }
        }
    }
}
