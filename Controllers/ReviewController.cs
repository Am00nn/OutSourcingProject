using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Services;

namespace OutsourcingSystem.Controllers
{
    [Authorize(Roles = "Client")]
    [ApiController]
    [Route("api/[Controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IJointService _jointService;

        public ReviewController(IJointService jointService)
        {
            _jointService = jointService;
        }


        [HttpPost("Add Developer Review")]
        public IActionResult AddDevReview(ClientReviewInDTO input) //Taking in the only values that a user is allowed to input 
        {
            try
            {
                int DevID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return Ok(_jointService.AddReviewDeveloper(DevID, input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("Add Team Review")]
        public IActionResult AddTeamReview(ClientReviewInDTO input) //Taking in the only values that a user is allowed to input 
        {
            try
            {
                int ClientID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return Ok(_jointService.AddReviewTeam(ClientID, input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("Update Team Review")]
        public IActionResult UpdateTeamReview(ClientReviewInDTO input)         
        {
            try
            {
                int ClientID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                int result = _jointService.UpdateReviewTeam(ClientID, input);

                if (result == 0) { return Ok("Updated!"); }
                else { return BadRequest("<!>Inputted team ID is invalid<!>"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Update Developer Review")]
        public IActionResult UpdateDeveloperReview(ClientReviewInDTO input)
        {
            try
            {
                int DevID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                int result = _jointService.UpdateReviewDeveloper(DevID, input);

                if (result == 0) { return Ok("Updated!"); }
                else { return BadRequest("<!>Inputted developer ID is invalid<!>"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Delete Team Review")]
        public IActionResult DeleteTeamReview(ClientReviewInDTO input)
        {
            try
            {
                int ClientID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                return Ok(_jointService.DeleteTeamReview(ClientID, input.ID));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete Developer Review")]
        public IActionResult DeleteDeveloperReview(ClientReviewInDTO input)
        {
            try
            {
                int DevID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                return Ok(_jointService.DeleteDeveloperReview(DevID, input.ID));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get Team Reviews")] //Gets all reviews allowing for filtering 
        public IActionResult GetTeamReviews(int? Rating, int? TeamID, int Page = 0, int PageSize = 100) //Allows the user to input 
        {
            try
            {
                return Ok(_jointService.GetTeamReviews(Page, PageSize, Rating , TeamID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get Developer Reviews")] //Gets all reviews allowing for filtering 
        public IActionResult GetDeveloperReviews(int? Rating, int? DevID, int Page = 0, int PageSize = 100) //Allows the user to input 
        {
            try
            {
                return Ok(_jointService.GetDeveloperReviews(Page, PageSize, Rating, DevID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
