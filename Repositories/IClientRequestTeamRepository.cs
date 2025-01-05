using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IClientRequestTeamRepository
    {
        Task AddRequestAsync(ClientRequestTeam request);
        Task<IEnumerable<ClientRequestTeam>> GetPendingRequestsAsync();
        Task<ClientRequestTeam> GetRequestByIdAsync(int requestId);
        Task UpdateRequestAsync(ClientRequestTeam request);
    }
}