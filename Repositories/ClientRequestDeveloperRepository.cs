using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class ClientRequestDeveloperRepository : IClientRequestDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRequestDeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRequestAsync(ClientRequestDeveloper request)
        {
            await _context.ClientRequestDeveloper.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientRequestDeveloper> GetRequestByIdAsync(int requestId)
        {
            return await _context.ClientRequestDeveloper.FindAsync(requestId);
        }

        public async Task UpdateRequestAsync(ClientRequestDeveloper request)
        {
            _context.ClientRequestDeveloper.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientRequestDeveloper>> GetPendingRequestsAsync()
        {
            return await Task.Run(() => _context.ClientRequestDeveloper.Where(req => req.Status == "Pending").ToList());
        }

    }
}
