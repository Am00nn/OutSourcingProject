using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface ISkillService
    {
        int AddSkill(string name, string description);
        int DeleteSkill(int SkillID);
        List<Skill> GetAllSkills(int Page, int PageSize, bool? active, DateTime? createdAt);
        int UpdateSkill(int skillID, string name, string description);
        int ReactivateSkill(int SkillID);
    }
}