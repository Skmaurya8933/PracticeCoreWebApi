using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreWebApi.Model;
using PracticeCoreWebApi.Repo;
using PracticeCoreWebApi.Services;
using System.Net;

namespace PracticeCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepository _superHeroRepository;
        private readonly ITokenService _tokenService;

        public SuperHeroController(ISuperHeroRepository superHeroRepository, ITokenService tokenService)
        {
            _superHeroRepository=superHeroRepository;
            _tokenService = tokenService;
        }

        [HttpGet("GetAllSuperHeroDetail")]
        public async Task<ActionResult<SuperHeroResponseModel>> GetAllSuperHeroDetail()
        {
            try
            {
                SuperHeroResponseModel responseStatus = await _superHeroRepository.GetAllSuperHeroDetail();
                if (responseStatus.CommonResponseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<SuperHeroResponseModel> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {                            
                    var loAPIResponseObj = new APIResultItem<SuperHeroResponseModel> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Adding Data");
            }

        }

        [HttpGet("GetSuperHeroById")]
        public async Task<ActionResult<SuperHeroResponseModel>> GetSuperHeroById(int id)
        {
            try
            {
                SuperHeroResponseModel responseStatus = await _superHeroRepository.GetSuperHeroById(id);
                if (responseStatus.CommonResponseStatus.Status)
                {
                    var returnResponseStatus = new APIResultItem<SuperHeroResponseModel> { Data = responseStatus, HttpStatusCode = HttpStatusCode.OK, ErrorGUID = null };
                    return Ok(returnResponseStatus);
                }
                else
                {
                    var loAPIResponseObj = new APIResultItem<SuperHeroResponseModel> { Data = responseStatus, HttpStatusCode = HttpStatusCode.BadRequest, ErrorGUID = null };
                    return BadRequest(loAPIResponseObj);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Adding Data");
            }
        }

        [HttpPost("AddSuperHeroDetail")]      
        public async Task<ActionResult<CommonResponseStatus>> AddSuperHeroDetail(SuperHero superHero)
        {
           
            try   
            {
               CommonResponseStatus responseStatus =  await _superHeroRepository.AddSuperHeroDetail(superHero);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Adding Data");
            }
        }

        [HttpPost("UpdateSuperHeroDetail")]
        public async Task<ActionResult<CommonResponseStatus>> UpdateSuperHeroDetail(SuperHero superHero)
        {
            try
            {
                CommonResponseStatus responseStatus = await _superHeroRepository.UpdateSuperHeroDetail(superHero);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Adding Data");
            }
        }

        [HttpGet("DeleteSuperHero")]
        public async Task<ActionResult<CommonResponseStatus>> DeleteSuperHero(int id)
        {
            try
            {
                CommonResponseStatus responseStatus = await _superHeroRepository.DeleteSuperHero(id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Adding Data");
            }
        }

    }
}
