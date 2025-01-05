using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IDeveloperSkillService
    {
        List<DeveloperSkill> GetSkillByDevID(int DevID);
        string AddDeveloperSkill(int skillID, int developerID, int proficiency);
        bool CheckDevHasSkill(int devID, int skillID);
        int DeleteDeveloperSkill(int skillID, int DeveloperID);
        List<DeveloperSkill> GetAllDeveloperSkills(int Page, int PageSize, int? developerID, int? skillID);
        List<DeveloperSkill> GetDevelopersBySkill(int skillID);
    }
}