using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddDeveloperRequest(ClientRequestDeveloper request)
        {
            _context.ClientRequestDeveloper.Add(request);
        }

        public void AddTeamRequest(ClientRequestTeam request)
        {
            _context.ClientRequestTeam.Add(request);
        }

        public ClientRequestDeveloper GetDeveloperRequest(int requestId)
        {
            return _context.ClientRequestDeveloper.FirstOrDefault(r => r.RequestID == requestId);
        }

        public ClientRequestTeam GetTeamRequest(int requestId)
        {
            return _context.ClientRequestTeam.FirstOrDefault(r => r.RequestID == requestId);
        }

        public bool DeveloperExists(int developerId)
        {
            return _context.Developer.Any(d => d.DeveloperID == developerId);
        }

        public bool TeamExists(int teamId)
        {
            return _context.Teams.Any(t => t.TeamID == teamId);
        }

        public string GetClientEmail(int clientId)
        {
            return _context.Users
                .Where(u => u.UID == clientId)
                .Select(u => u.Email)
                .FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
