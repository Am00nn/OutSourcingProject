using System.Security.Claims;
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

        //Adds skill to self
        [HttpPost("Add skill to me{skillID}")]
        public IActionResult AddSkillToMe( int skillID, int proficiency)
        {
            try
            {
                var developerID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                return Ok(_developerSkillService.AddDeveloperSkill(skillID, developerID, proficiency));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add Skill to Developer {developerID},{skillID}")]
        public IActionResult AddSkillToDeveloper( int developerID, int skillID, int proficiency)
        {
            try
            {
                return Ok(_developerSkillService.AddDeveloperSkill( skillID, developerID, proficiency));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Remove skill from dev {skillID}, {devID}")]
        public IActionResult RemoveSkillFromDev(int skillID, int devID)
        {
            try
            {
                var result = _developerSkillService.DeleteDeveloperSkill(skillID, devID);

                if (result == 0) return Ok("Skill removed from developer successfully");
                else if (result == 1) return BadRequest("<!>This developer skill relationship does not exist<!>");
                else return Ok("<!>An error occured while trying to execute this request<!>");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin, Client")]
        [HttpGet("Get Developer Skill {DevID}")]
        public IActionResult GetDevSkills( int DevID)
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
        [HttpGet("Get Developers By Skill {SkillID}")]
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
