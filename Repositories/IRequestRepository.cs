using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IRequestRepository
    {
        void AddDeveloperRequest(ClientRequestDeveloper request);
        void AddTeamRequest(ClientRequestTeam request);
        IEnumerable<ClientRequestDeveloper> GetDeveloperRequests();
        dynamic GetRequestById(int requestId);
        IEnumerable<ClientRequestTeam> GetTeamRequests();
    }
}