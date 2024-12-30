using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
    [Authorize (Roles = "Admin")]
    [ApiController]
    [Route("api/[Controller]")]
    public class SkillController : ControllerBase 
    {
        
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }


        [HttpPost("Add Skill")]
        public IActionResult AddSkill(string Name, string Description) //Taking in the only values that a user is allowed to input 
        {
            try
            {
                return Ok(_skillService.AddSkill(Name, Description));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("Update Skill")]
        public IActionResult UpdateSkill(int SkillID, string NewName, string NewDescription) //Taking the ID of the old skill and the new values of the skill 
        {
            try
            {
                int result = _skillService.UpdateSkill(SkillID, NewName, NewDescription);

                if (result == 0) { return Ok("Updated!"); }
                else { return BadRequest("<!>Inputted skill ID is invalid<!>"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Soft Delete")] //Allows the admin to deactivate a skill without deleting it completely
        public IActionResult SoftDelete(int SkillID)
        {
            try
            {
                int result = _skillService.DeleteSkill(SkillID);

                if (result == 0) { return Ok("Deactivated!"); }
                else if (result == 1) { return BadRequest("<!>Invalid skill ID<!>"); }
                else return BadRequest("<!>Error occurred when deleting<!>");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get Skills")] //Gets all skills allowing for filtering using if the account is active and when it was created as non compulsury inputs 
        public IActionResult GetSkills( bool? active, DateTime? createdAt, int Page = 0, int PageSize =100) //Allows the user to input 
        {
            try
            {
                return Ok(_skillService.GetAllSkills(Page, PageSize, active, createdAt));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
