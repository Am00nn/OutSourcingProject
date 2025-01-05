using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IProjectServieces _projectService;

        public RequestController(IRequestService requestService, IProjectServieces projectservice)
        {
            _requestService = requestService;
            _projectService = projectservice;
        }

        [Authorize(Roles = "Client")]
        [HttpPost("SubmitRequest")]
        public async Task<IActionResult> SubmitRequest([FromBody] ProjectRequestInputDto projectInputDto)
        {
            // Extract ClientID from Token
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            if (string.IsNullOrEmpty(clientId))
                return Unauthorized("Invalid token. ClientID not found.");

          //  requestDto.ClientID = int.Parse(clientId); // Assign ClientID from token

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

           // _projectService.AddProject();
            await _requestService.SubmitRequestAsync(int.Parse(clientId), projectInputDto);
            _projectService.AddProject(int.Parse(clientId), projectInputDto);
            return Ok("Request submitted successfully.");
        }

        [Authorize(Roles = "Admin")]
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
