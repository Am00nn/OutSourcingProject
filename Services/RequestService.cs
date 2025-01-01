using OutsourcingSystem.Models;
using System.Security.Claims;

namespace OutsourcingSystem.Services
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext _context;

        public RequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string SubmitRequest(ClaimsPrincipal user, SubmitRequestModel requestModel)
        {
            var clientId = int.Parse(user.FindFirst("clientID")?.Value);
            var role = user.FindFirst("role")?.Value;

            if (role != "Client")
            {
                throw new UnauthorizedAccessException("Only clients can submit requests.");
            }

            if (requestModel.RequestType == "Developer" && requestModel.DeveloperID == null)
            {
                throw new ArgumentException("Please specify a valid Developer ID.");
            }

            if (requestModel.RequestType == "Team" && requestModel.TeamID == null)
            {
                throw new ArgumentException("Please specify a valid Team ID.");
            }

            if (requestModel.RequestType == "Developer")
            {
                var developerExists = _context.Developer.Any(d => d.DeveloperID == requestModel.DeveloperID);
                if (!developerExists)
                {
                    throw new ArgumentException("The specified Developer ID does not exist.");
                }
            }

            if (requestModel.RequestType == "Team")
            {
                var teamExists = _context.Teams.Any(t => t.TeamID == requestModel.TeamID);
                if (!teamExists)
                {
                    throw new ArgumentException("The specified Team ID does not exist.");
                }
            }

            if (requestModel.RequestType == "Developer")
            {
                var request = new ClientRequestDeveloper
                {
                    ClientID = clientId,
                   // DeveloperID = requestModel.DeveloperID.Value,
                    StartDate = requestModel.StartDate,
                    EndDate = requestModel.EndDate,
                    Status = "Pending"
                };
                _context.ClientRequestDeveloper.Add(request);
            }
            else if (requestModel.RequestType == "Team")
            {
                var request = new ClientRequestTeam
                {
                    ClientID = clientId,
                    TID = requestModel.TeamID.Value,
                    StartDate = requestModel.StartDate,
                    EndDate = requestModel.EndDate,
                    Status = "Pending"
                };
                _context.ClientRequestTeam.Add(request);
            }
            else
            {
                throw new ArgumentException("Invalid request type.");
            }

            _context.SaveChanges();

            EmailService.SendEmail(
                "amanialshmali7@gmail.com",
                "New Request Submitted",
                $"A new request has been submitted by client ID: {clientId} for type: {requestModel.RequestType}."
            );

            return "Request submitted successfully.";
        }

        public string ProcessRequest(int requestId, string requestType, bool isAccepted)
        {
            string status = isAccepted ? "Approved" : "Rejected";
            string clientEmail = string.Empty;

            if (requestType == "Developer")
            {
                var request = _context.ClientRequestDeveloper.Find(requestId);
                if (request != null)
                {
                    request.Status = status;

                    clientEmail = _context.Users
                        .Where(u => u.UID == request.ClientID)
                        .Select(u => u.Email)
                        .FirstOrDefault();
                }
            }
            else if (requestType == "Team")
            {
                var request = _context.ClientRequestTeam.Find(requestId);
                if (request != null)
                {
                    request.Status = status;

                    clientEmail = _context.Users
                        .Where(u => u.UID == request.ClientID)
                        .Select(u => u.Email)
                        .FirstOrDefault();
                }
            }
            else
            {
                throw new ArgumentException("Invalid request type.");
            }

            if (string.IsNullOrEmpty(clientEmail))
            {
                throw new ArgumentException("Client email not found.");
            }

            _context.SaveChanges();

            EmailService.SendEmail(
                clientEmail,
                "Request Status",
                isAccepted ? "Your request has been approved." : "Your request has been rejected."
            );

            return "Request processed successfully.";
        }

    }
}
