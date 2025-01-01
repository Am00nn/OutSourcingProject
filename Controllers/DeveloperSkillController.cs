using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.Services;

namespace OutsourcingSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Admin")]
    public class DeveloperSkillController : ControllerBase
    {
        private readonly IDeveloperSkillService _developerSkillService;

        public DeveloperSkillController(IDeveloperSkillService developerSkillService)
        {
            _developerSkillService = developerSkillService;
        }


        [HttpPost("Add Skill to Developer")]
        public IActionResult AddSkillToDeveloper( int developerID, int skillID)
        {
            try
            {
                return Ok(_developerSkillService.AddDeveloperSkill(developerID, skillID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Remove skill from dev")]
        public IActionResult RemoveSkillFromDev(int TeamID, int devID)
        {
            try
            {
                return Ok(_developerSkillService.DeleteDeveloperSkill(TeamID, devID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin, Client")]
        [HttpGet("Get Developer Skill {int DevID}")]
        public IActionResult GetDevSkills(int DevID)
        {
            try
            {
                return Ok(_developerSkillService.GetSkillByDevID(DevID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin, Client")]
        [HttpGet("Get Developers By Skill {int SkillID}")]
        public IActionResult GetDevsBySkill(int SkillID)
        {
            try
            {
                return Ok(_developerSkillService.GetDevelopersBySkill(SkillID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
