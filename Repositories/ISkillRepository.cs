using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface ISkillRepository
    {
        int AddSkill(Skill skill);
        void DeleteSkill(Skill skill);
        List<Skill> GetAllSkills();
        void UpdateSkill(Skill skill);
        Skill GetSkillByID(int ID);
    }
}