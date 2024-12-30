using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddDeveloperRequest(ClientRequestDeveloper request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Developer request cannot be null.");

            try
            {
                _context.ClientRequestDeveloper.Add(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error happen while adding a developer request.", ex);
            }
        }

        public void AddTeamRequest(ClientRequestTeam request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Team request cannot be null.");

            try
            {
                _context.ClientRequestTeam.Add(request);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("An error happen while adding a team request.", ex);
            }
        }

        public IEnumerable<ClientRequestDeveloper> GetDeveloperRequests()
        {
            try
            {

                return _context.ClientRequestDeveloper.ToList();

            }
            catch (Exception ex)
            {


                throw new Exception("An error happen while retrieving developer requests.", ex);


            }
        }

        public IEnumerable<ClientRequestTeam> GetTeamRequests()
        {
            try
            {
                return _context.ClientRequestTeam.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("An error happen while retrieving team requests.", ex);
            }
        }

        public dynamic GetRequestById(int requestId)
        {
            try
            {
                var developerRequest = _context.ClientRequestDeveloper.FirstOrDefault(r => r.RequestID == requestId);

                var teamRequest = _context.ClientRequestTeam.FirstOrDefault(r => r.RequestID == requestId);

                return developerRequest ?? teamRequest as dynamic;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while get the request with ID {requestId}.", ex);
            }
        }



    }
}
