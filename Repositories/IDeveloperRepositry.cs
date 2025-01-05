using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IDeveloperRepositry
    {
        void Add(Developer developer);
        bool Delete(Developer deve);
        IEnumerable<Developer> Getavailibilty(bool availibilty);
        Developer GetById(int id);
      //  IEnumerable<Developer> GetBySkill(int skillid);
       IEnumerable<Developer> getrate(decimal rate);
        IEnumerable<Developer> GetNameDeveloper(string name);
        IEnumerable<Developer> GetSpec(string spe);
        Developer GetUserById(int userId);
        void Update(Developer dev);
        IEnumerable<Developer> GetAll();
    }
}