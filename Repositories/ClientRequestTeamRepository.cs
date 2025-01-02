using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class ClientRequestTeamRepository : IClientRequestTeamRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRequestTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRequestAsync(ClientRequestTeam request)
        {
            await _context.ClientRequestTeam.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientRequestTeam> GetRequestByIdAsync(int requestId)
        {
            return await _context.ClientRequestTeam.FindAsync(requestId);
        }

        public async Task UpdateRequestAsync(ClientRequestTeam request)
        {
            _context.ClientRequestTeam.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
