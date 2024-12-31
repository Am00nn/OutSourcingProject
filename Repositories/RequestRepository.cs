using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class ClientRequestRepository : IClientRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public void AddDeveloperRequest(ClientRequestDeveloper request)
        {
            try
            {
                _context.ClientRequestDeveloper.Add(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the developer request.", ex);
            }
        }

        
        public void AddTeamRequest(ClientRequestTeam request)
        {
            try
            {
                _context.ClientRequestTeam.Add(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the team request.", ex);
            }
        }

       
        public ClientRequestDeveloper GetDeveloperRequestById(int requestId)
        {
            try
            {
                return _context.ClientRequestDeveloper.FirstOrDefault(r => r.RequestID == requestId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the developer request with ID {requestId}.", ex);
            }
        }

        
        public ClientRequestTeam GetTeamRequestById(int requestId)
        {
            try
            {
                return _context.ClientRequestTeam.FirstOrDefault(r => r.RequestID == requestId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the team request with ID {requestId}.", ex);
            }
        }

       
        public IEnumerable<ClientRequestDeveloper> GetDeveloperRequestsByClientId(int clientId)
        {
            try
            {
                return _context.ClientRequestDeveloper.Where(r => r.ClientID == clientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving developer requests for client ID {clientId}.", ex);
            }
        }

        
        public IEnumerable<ClientRequestTeam> GetTeamRequestsByClientId(int clientId)
        {
            try
            {
                return _context.ClientRequestTeam.Where(r => r.ClientID == clientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving team requests for client ID {clientId}.", ex);
            }
        }

      
        public void UpdateDeveloperRequest(ClientRequestDeveloper request)
        {
            try
            {
                _context.ClientRequestDeveloper.Update(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the developer request.", ex);
            }
        }

        
        public void UpdateTeamRequest(ClientRequestTeam request)
        {
            try
            {
                _context.ClientRequestTeam.Update(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the team request.", ex);
            }
        }
    }



}

