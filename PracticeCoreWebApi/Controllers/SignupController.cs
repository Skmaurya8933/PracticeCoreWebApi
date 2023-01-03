using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreWebApi.Model;
using PracticeCoreWebApi.Repo;
using System.Net;

namespace PracticeCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupRepository _signupRepository;
        public SignupController(ISignupRepository signupRepository)
        {
            _signupRepository = signupRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<CommonResponseStatus>> Register(SignupDetail signupDetail)
        {
            try
            {
                CommonResponseStatus responseStatus = await _signupRepository.Register(signupDetail);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Register");
            }
        }
        [HttpPost("Login")]
        
        public async Task<ActionResult<Login>> Login(LogInRequest ResLogin)
        {
            try
            {
                Login responseStatus = await _signupRepository.Login(ResLogin);
                if (responseStatus.CommonResponseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<Login> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {
                    var loAPIResponseObj = new APIResultItem<Login> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Login");
            }
        }

    }
}
