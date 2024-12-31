using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IDeveloperSkillService
    {
        string AddDeveloperSkill(int skillID, int developerID);
        bool CheckDevHasSkill(int devID, int skillID);
        int DeleteDeveloperSkill(int skillID, int DeveloperID);
        List<DeveloperSkill> GetAllDeveloperSkills(int Page, int PageSize, int? developerID, int? skillID);
        List<DeveloperSkill> GetSkillByDevID(int DevID);
    }
}