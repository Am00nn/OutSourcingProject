using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
    [Authorize(Roles = "Developer")]
    [ApiController]
    [Route("api/[Controller]")]
    public class FeedBackOnClientController : ControllerBase
    {
        private readonly IJointService _jointService;

        public FeedBackOnClientController(IJointService joint)
        {
            _jointService = joint;
        }


        [HttpPost("Add Feedback on client")]
        public IActionResult AddFeedback(FeedBackOnClientDTO input) //Taking in the only values that a user is allowed to input 
        {
            try
            {
                int DevID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                string role = User.FindFirst(ClaimTypes.Role)?.Value;
                return Ok(_jointService.FeedbackValidation(DevID, input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("Update feedback")]
        public IActionResult Feedback(FeedBackOnClientDTO input)
        {
            try
            {
                int DevID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                int result = _jointService.UpdateFeebackOnClient(DevID, input);

                if (result == 0) { return Ok("Updated!"); }
                else { return BadRequest("<!>Inputted team ID is invalid<!>"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete Feedback {ClientID}")]
        public IActionResult DeleteFeedback(int ClientID)
        {
            try
            {
                int DevID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                return Ok(_jointService.DeleteFeedbackOnClient(ClientID, DevID));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get Client Feedbacks")] //Gets all feedbacks allowing for filtering 
        public IActionResult GetAllFeedbackOnClient(int? Rating, int? ClientID, int Page = 0, int PageSize = 100) //Allows the user to input 
        {
            try
            {
                return Ok(_jointService.GetClientFeedback(Page, PageSize, Rating, ClientID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
