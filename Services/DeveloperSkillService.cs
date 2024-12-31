using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    public class DeveloperSkillService : IDeveloperSkillService
    {
        private readonly IDeveloperSkillRepository _DeveloperSkillRepository;
        public DeveloperSkillService(IDeveloperSkillRepository developerSkillRepository)
        {
            _DeveloperSkillRepository = developerSkillRepository;
        }

        //Adds developer skill using input from user 
        public string AddDeveloperSkill(int skillID, int developerID)
        {
            //mapping input to developerSkill 
            var devSkill = new DeveloperSkill
            {
                DeveloperID = developerID,
                SkillID = skillID,
            };

            return _DeveloperSkillRepository.AddDeveloperSkill(devSkill);
        }

        //Deleting developer skill [returns 0 no errors or 1 error occured]
        public int DeleteDeveloperSkill(int skillID, int DeveloperID)
        {
            try
            {
                _DeveloperSkillRepository.DeleteDeveloperSkill(DeveloperID, skillID);
                return 0; //no errors
            }
            catch { return 1; } //error occured 
        }

        public List<DeveloperSkill> GetAllDeveloperSkills(int Page, int PageSize, int? developerID, int? skillID)
        {
            var devSkills = _DeveloperSkillRepository.GetAllDeveloperSkills();

            // Filters by if developerID if provided 
            if (developerID.HasValue)
            {
                devSkills = devSkills.Where(t => t.DeveloperID == developerID).ToList();
            }

            // Filters by skillID at if provided 
            if (skillID.HasValue)
            {
                devSkills = devSkills.Where(t => t.SkillID == skillID).ToList();
            }

            // Paginating results and returning 
            int number = PageSize * Page;
            return devSkills.OrderBy(t => t.DeveloperID).Skip(number).Take(PageSize).ToList();
        }

        public List<DeveloperSkill> GetSkillByDevID(int DevID)
        {
            return _DeveloperSkillRepository.GetAllSkillsForDev(DevID);
        }

        public bool CheckDevHasSkill(int devID, int skillID)
        {
            var skillFound = _DeveloperSkillRepository.CheckDevHasSkill(devID, skillID);
            return skillFound == true ? true : false;
        }
    }
}
