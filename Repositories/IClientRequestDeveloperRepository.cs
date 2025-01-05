using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IClientRequestDeveloperRepository
    {
        Task AddRequestAsync(ClientRequestDeveloper request);
        Task<IEnumerable<ClientRequestDeveloper>> GetPendingRequestsAsync();
        Task<ClientRequestDeveloper> GetRequestByIdAsync(int requestId);
        Task UpdateRequestAsync(ClientRequestDeveloper request);
    }
}