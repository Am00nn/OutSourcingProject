using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IDeveloperRepositry
    {
        void Add(Developer developer);
        Developer GetById(int id);
        void Update(Developer dev);
       // IEnumerable<Developer> GetUnapproveddeveloper();
    }
}