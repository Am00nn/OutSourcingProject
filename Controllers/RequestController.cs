using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.Models;
using OutsourcingSystem.Services;

namespace OutsourcingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("SubmitRequest")]
        public IActionResult SubmitRequest([FromBody] SubmitRequestModel requestModel)
        {
            try
            {
                var result = _requestService.SubmitRequest(User, requestModel);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ProcessRequest")]
        public IActionResult ProcessRequest(int requestId, string requestType, bool isAccepted)
        {
            try
            {
                var result = _requestService.ProcessRequest(requestId, requestType, isAccepted);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
