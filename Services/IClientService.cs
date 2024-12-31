using OutsourcingSystem.DTOs;

namespace OutsourcingSystem.Services
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients(string name, string industry, decimal? rating, int pageNumber, int pageSize);
        ClientDTO GetClientById(int id);
        IEnumerable<ClientDTO> GetClientsByIndustry(string industry);
        IEnumerable<ClientDTO> GetClientsByRating(decimal rating);
        public void RegisterClient(UserInputDto client);
        void SoftDeleteClient(int id);
        void UpdateClient(int id, ClientDTO updatedClientDto);
    }
}