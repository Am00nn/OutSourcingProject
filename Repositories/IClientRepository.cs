using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        IEnumerable<Client> GetByIndustry(string industry);
        IEnumerable<Client> GetByRating(decimal rating);
        void SoftDelete(Client client);
        void Update(Client client);
    }
}