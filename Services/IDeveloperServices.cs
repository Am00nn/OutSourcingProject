using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IDeveloperServices
    {
        IEnumerable<filtrationDeveloperdto> GetAlldeveloper(string name, string speclization, decimal? rating, bool? availiabilty, int pageNumber = 1, int pageSize = 10);
        IEnumerable<filtrationDeveloperdto> GetByAvailability(bool av);
         IEnumerable<filtrationDeveloperdto> Getrate(decimal rating);
        IEnumerable<filtrationDeveloperdto> GetName(string name);
        IEnumerable<filtrationDeveloperdto> GetSpecilization(string spec);
        void RegisterDeveloper(UserDeveloperInputDto input);
        void SoftDeleteClient(int id);
        void UpdateDeveloper(int id, UpdateDeveInput updateDeveloper);
        Developer GetById(int id);
        IEnumerable<Developer> GetAll();
    }
}