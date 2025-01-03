using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Services;

namespace OutsourcingSystem.Controllers
{
    
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Admin")]

    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        [HttpPost("Add Team")]
        public IActionResult AddTeam(TeamInDTO team) //Taking in the only values that a user is allowed to input 
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return Ok(_teamService.AddTeam(userId, team));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("Update Team")]
        public IActionResult UpdateTeam(int TeamID, TeamUpdateDTO team) //Taking the ID of the old team and the new values of the team 
        {
            try
            {
                var Role = User.FindFirst(ClaimTypes.Role)?.Value;
                if (Role == "Admin")
                {
                   var AdminID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                    int result = _teamService.UpdateTeam(TeamID, AdminID, team);

                    if (result == 0) { return Ok("Updated!"); }
                    else { return BadRequest("<!>Inputted team ID is invalid<!>"); }
                }
                else { return Unauthorized("<!>This function can only be executed by an Admin<!>"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Soft Delete")] //Allows the admin to deactivate a team without deleting it completely
        public IActionResult SoftDelete(int TeamID)
        {
            try
            {
                int result = _teamService.DeleteTeam(TeamID);

                if (result == 0) { return Ok("Deactivated!"); }
                else if (result == 1) { return BadRequest("<!>Invalid team ID<!>"); }
                else return BadRequest("<!>Error occurred when deleting<!>");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Reactivate Team")] //Allows the admin to Reactivate a team after it has been soft deleting it completely
        public IActionResult ReactivateTeam(int TeamID)
        {
            try
            {
                int result = _teamService.ReactivateTeam(TeamID);

                if (result == 0) { return Ok("Reactivated!"); }
                else if (result == 1) { return BadRequest("<!>Invalid team ID<!>"); }
                else return BadRequest("<!>Error occurred when reactivating<!>");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpGet("Get Teams")] //Gets all teams allowing for filtering using non compulsury inputs 
        public IActionResult GetSkills(bool? active, int? completedProjects, int? rating, int? hourlyRate, int Page = 0, int PageSize = 100) 
        {
            try
            {
                return Ok(_teamService.GetAllTeams(Page, PageSize, active, completedProjects, rating, hourlyRate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
