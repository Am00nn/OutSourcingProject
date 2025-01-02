using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    public class RequestService : IRequestService
    {
        private readonly IClientRequestDeveloperRepository _developerRequestRepository;
        private readonly IClientRequestTeamRepository _teamRequestRepository;
        private readonly IEmailService _emailService;

        public RequestService(
            IClientRequestDeveloperRepository developerRequestRepository,
            IClientRequestTeamRepository teamRequestRepository,
            IEmailService emailService)
        {
            _developerRequestRepository = developerRequestRepository;
            _teamRequestRepository = teamRequestRepository;
            _emailService = emailService;
        }

        public async Task SubmitRequestAsync(RequestDto requestDto, int clientId)
        {
            // Ensure ClientID is not null
            if (clientId == 0)
            {
                throw new InvalidOperationException("ClientID cannot be null.");
            }

            // Convert ClientID from nullable to non-nullable
            // int clientId = requestDto.ClientID.Value;

            if (requestDto.RequestType == "Developer")
            {
                var developerRequest = new ClientRequestDeveloper
                {
                    ClientID = clientId, // Use converted value
                    DeveloperID = requestDto.developerid ?? 0, // Default to 0 if null
                    StartDate = requestDto.StartDate,
                    EndDate = requestDto.EndDate,
                    Status = "Pending"
                };
                await _developerRequestRepository.AddRequestAsync(developerRequest);
            }
            else if (requestDto.RequestType == "Team")
            {
                var teamRequest = new ClientRequestTeam
                {
                    ClientID = clientId, // Use converted value
                    TID = requestDto.TeamID ?? 0, // Default to 0 if null
                    StartDate = requestDto.StartDate,
                    EndDate = requestDto.EndDate,
                    Status = "Pending"
                };
                await _teamRequestRepository.AddRequestAsync(teamRequest);
            }

            await _emailService.SendEmailAsync("amanialshmali7@gmail.com", "New Request Submitted", "A new request has been submitted.");
        }

        public async Task ProcessRequestAsync(int requestId, bool isAccepted, string requestType)
        {
            if (requestType == "Developer")
            {
                var request = await _developerRequestRepository.GetRequestByIdAsync(requestId);
                request.Status = isAccepted ? "Approved" : "Rejected";
                await _developerRequestRepository.UpdateRequestAsync(request);
            }
            else if (requestType == "Team")
            {
                var request = await _teamRequestRepository.GetRequestByIdAsync(requestId);
                request.Status = isAccepted ? "Approved" : "Rejected";
                await _teamRequestRepository.UpdateRequestAsync(request);
            }

            string clientEmail = "client@example.com"; // Retrieve from database in real implementation
            string statusMessage = isAccepted ? "Your request has been approved." : "Your request has been rejected.";
            await _emailService.SendEmailAsync(clientEmail, "Request Status Update", statusMessage);
        }

    }
}
