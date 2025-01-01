using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IDeveloperRepositry
    {
        void Add(Developer developer);
        Developer GetById(int id);
        public void Update(Developer dev);
        public IEnumerable<Developer> GetUnapproveddeveloper();
    }
}