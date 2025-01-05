using DocuSign.eSign.Model;
using OutsourcingSystem.Configurations;
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
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepositry _userRepository;
        private readonly IUserServices _userServices;


        public RequestService(
            IClientRequestDeveloperRepository developerRequestRepository,
            IClientRequestTeamRepository teamRequestRepository,
            IEmailService emailService, IClientRepository clientRepository, IUserServices userServices, IUserRepositry userRepository)
        {
            _developerRequestRepository = developerRequestRepository;
            _teamRequestRepository = teamRequestRepository;
            _emailService = emailService;
            _clientRepository = clientRepository;
            _userServices = userServices;
            _userRepository = userRepository;

        }

        public async Task SubmitRequestAsync(RequestDto requestDto, int userid)
        {
            // Ensure ClientID is not null
            if (userid == 0)
            {
                throw new InvalidOperationException("ClientID cannot be null.");
            }

            // Convert ClientID from nullable to non-nullable
            int clientId = _clientRepository.GetByuid(userid).ClientID;
            string email = _userServices.GetEmail(userid);

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

            await _emailService.SendEmailAsync(email, "New Request Submitted", "A new request has been submitted.");
            string AdmintEmail = "amanialshmali7@gmail.com";
            await _emailService.SendEmailAsync(AdmintEmail, "New Request Submitted", "A new request has been submitted.");



        }


        public async Task ProcessRequestAsync(int requestId, bool isAccepted, string requestType)
        {
            string clientEmail = "";

            if (requestType == "Developer")
            {
                // Retrieve the developer request by requestId
                var request = await _developerRequestRepository.GetRequestByIdAsync(requestId);
                request.Status = isAccepted ? "Approved" : "Rejected";
                await _developerRequestRepository.UpdateRequestAsync(request);

                // Retrieve the client's User and email using UID
                var client = _clientRepository.GetById(request.ClientID);
                var user = _userRepository.GetUserById(client.UID);
                clientEmail = user?.Email ?? throw new InvalidOperationException("Client email not found.");
            }
            else if (requestType == "Team")
            {
                // Retrieve the team request by requestId
                var request = await _teamRequestRepository.GetRequestByIdAsync(requestId);
                request.Status = isAccepted ? "Approved" : "Rejected";
                await _teamRequestRepository.UpdateRequestAsync(request);

                // Retrieve the client's User and email using UID
                var client = _clientRepository.GetById(request.ClientID);
                var user = _userRepository.GetUserById(client.UID);
                clientEmail = user?.Email ?? throw new InvalidOperationException("Client email not found.");
            }

            // Send an email notification to the client
            string statusMessage = isAccepted ? "Your request has been approved." : "Your request has been rejected.";
            await _emailService.SendEmailAsync(clientEmail, "Request Status Update", statusMessage);
        }


    }




}



