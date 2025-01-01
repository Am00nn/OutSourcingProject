using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IRequestRepository
    {
        void AddDeveloperRequest(ClientRequestDeveloper request);
        void AddTeamRequest(ClientRequestTeam request);
        bool DeveloperExists(int developerId);
        string GetClientEmail(int clientId);
        ClientRequestDeveloper GetDeveloperRequest(int requestId);
        ClientRequestTeam GetTeamRequest(int requestId);
        void SaveChanges();
        bool TeamExists(int teamId);
    }
}