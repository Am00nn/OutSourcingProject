using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("SubmitRequest")]
        public async Task<IActionResult> SubmitRequest([FromBody] RequestDto requestDto)
        {
            // Extract ClientID from Token
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            if (string.IsNullOrEmpty(clientId))
                return Unauthorized("Invalid token. ClientID not found.");

          //  requestDto.ClientID = int.Parse(clientId); // Assign ClientID from token

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            await _requestService.SubmitRequestAsync(requestDto, int.Parse(clientId));
            return Ok("Request submitted successfully.");
        }

        [HttpPost("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] ProcessRequestDto processRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            await _requestService.ProcessRequestAsync(
                processRequestDto.RequestId,
                processRequestDto.IsAccepted,
                processRequestDto.RequestType
            );

            return Ok("Request processed successfully.");
        }
    }

}
