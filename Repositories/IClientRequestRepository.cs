using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IClientRequestRepository
    {
        void AddDeveloperRequest(ClientRequestDeveloper request);
        void AddTeamRequest(ClientRequestTeam request);
        ClientRequestDeveloper GetDeveloperRequestById(int requestId);
        IEnumerable<ClientRequestDeveloper> GetDeveloperRequestsByClientId(int clientId);
        ClientRequestTeam GetTeamRequestById(int requestId);
        IEnumerable<ClientRequestTeam> GetTeamRequestsByClientId(int clientId);
        void UpdateDeveloperRequest(ClientRequestDeveloper request);
        void UpdateTeamRequest(ClientRequestTeam request);
    }
}