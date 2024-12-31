using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Services;

namespace OutsourcingSystem.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

     
        /// Submit a new request.
     
        [HttpPost("submit")]
        public IActionResult SubmitRequest([FromBody] RequestDTO requestDto, [FromQuery] string smtpUsername, [FromQuery] string smtpPassword)
        {
            if (requestDto == null)
                return BadRequest("Request data cannot be null.");

            try
            {
                _requestService.SubmitRequest(requestDto, smtpUsername, smtpPassword);
                return Ok("Request submitted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while submitting the request: {ex.Message}");
            }
        }

      
        /// Process a request (approve or reject).
   
        [HttpPut("process/{requestId}")]
        public IActionResult ProcessRequest(int requestId, [FromQuery] string status, [FromQuery] string smtpUsername, [FromQuery] string smtpPassword)
        {
            if (string.IsNullOrEmpty(status))
                return BadRequest("Status cannot be null or empty.");

            if (status != "Approved" && status != "Rejected")
                return BadRequest("Invalid status. Only 'Approved' or 'Rejected' are allowed.");

            try
            {
                _requestService.ProcessRequest(requestId, status, smtpUsername, smtpPassword);
                return Ok($"Request {status.ToLower()} successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        
        /// Get all requests by a specific client.
     
        [HttpGet("client/{clientId}")]
        public IActionResult GetRequestsByClient(int clientId)
        {
            try
            {
                var requests = _requestService.GetRequestsByClient(clientId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving requests: {ex.Message}");
            }
        }
    }
}
