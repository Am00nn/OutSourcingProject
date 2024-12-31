using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IDeveloperSkillRepository
    {
        string AddDeveloperSkill(DeveloperSkill developerSkill);
        bool CheckDevHasSkill(int devID, int skillID);
        void DeleteDeveloperSkill(int DevID, int SkillID);
        List<DeveloperSkill> GetAllDeveloperSkills();
        List<DeveloperSkill> GetAllSkillsForDev(int devID);
        List<DeveloperSkill> GetDevelopersBySkillID(int SkillID);
        List<DeveloperSkill> GetSkillsByDeveloperID(int DevID);
    }
}