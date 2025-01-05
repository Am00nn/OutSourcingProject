using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;
using OutsourcingSystem.Services;

namespace OutsourcingSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Admin")]
    public class TeamMemberController: ControllerBase
    {
        private readonly IJointService _jointService;

        public TeamMemberController(IJointService jointService)
        {
            _jointService = jointService;
        }


        [HttpPost("Add TeamMember to Team")]
        public IActionResult AddTeamMemberToTeam(int teamID, int developerID) 
        {
            try
            {
                return Ok(_jointService.AddTeamMemberToTeam(developerID, teamID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Remove team member from team")] 
        public IActionResult RemTMfromTeamDelete(int TeamID, int devID)
        {
            try
            {
                return Ok(_jointService.RemoveTeamMemberFromTeam(devID, TeamID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin, Client")]
        [HttpGet("Get TeamMembers in Team {TeamID}")] 
        public IActionResult GetMembers(int TeamID)
        {
            try
            {
                return Ok(_jointService.GetTeamMemberByTeamID(TeamID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
