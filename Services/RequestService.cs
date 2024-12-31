 using Azure.Core;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    public class RequestService : IRequestService
    {
        private readonly IClientRequestRepository _requestRepository;
        private readonly IEmailService _emailService;

        public RequestService(IClientRequestRepository requestRepository, IEmailService emailService)
        {
            _requestRepository = requestRepository;
            _emailService = emailService;
        }

        public void SubmitRequest(RequestDTO requestDto, string smtpUsername, string smtpPassword)
        {
            try
            {
                // chack type of request 
                if (requestDto.RequestType != "Developer" && requestDto.RequestType != "Team")
                {
                    throw new ArgumentException("Invalid request type. Only 'Developer' or 'Team' are allowed.");
                }

                // Save request on DB 
                if (requestDto.RequestType == "Developer")
                {
                    var developerRequest = new ClientRequestDeveloper
                    {
                        ClientID = requestDto.ClientID,
                        
                        StartDate = requestDto.StartDate,
                        
                        EndDate = requestDto.EndDate,
                        
                        Status = "Pending"
                    };
                    _requestRepository.AddDeveloperRequest(developerRequest);
                }
                else
                {
                    var teamRequest = new ClientRequestTeam
                    {
                        
                        ClientID = requestDto.ClientID,
                       
                        StartDate = requestDto.StartDate,
                       
                        EndDate = requestDto.EndDate,
                       
                        Status = "Pending"
                    };
                    _requestRepository.AddTeamRequest(teamRequest);
                }

                // send email to Admin
                var emailMessage = new EmailMessage
                {
                   
                    From = requestDto.ClientEmail,
                   
                    To = requestDto.AdminEmail,
                   
                    Subject = "New Project Request Submitted",
                   
                    Body = $"Client {requestDto.ClientID} has submitted a {requestDto.RequestType} request."
                };

                _emailService.SendEmail(emailMessage, smtpUsername, smtpPassword);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while submitting the request.", ex);
            }
        }

        public void ProcessRequest(int requestId, string status, string smtpUsername, string smtpPassword)
        {
            try
            {
                // get request from 
                var developerRequest = _requestRepository.GetDeveloperRequestById(requestId);
                var teamRequest = _requestRepository.GetTeamRequestById(requestId);

                if (developerRequest == null && teamRequest == null)
                {
                    throw new KeyNotFoundException($"Request with ID {requestId} not found.");
                }

                // update Status
                if (developerRequest != null)
                {
                   
                    developerRequest.Status = status;
                   
                    _requestRepository.UpdateDeveloperRequest(developerRequest);
                }
                else
                {
                    teamRequest.Status = status;
                    _requestRepository.UpdateTeamRequest(teamRequest);
                }

                // sent email to ClientEmail
                //This following function will be added after pulling code --needs the user class will update after added
                
                //var emailMessage = new EmailMessage
                //{
                    
                //    From = smtpUsername,
                   
                //    To = developerRequest != null ? developerRequest.Client.ClientEmail : teamRequest.Client.ClientEmail,
                   
                //    Subject = "Request Status Update",
                   
                //    Body = $"Your request with ID {requestId} has been {status}."
                //};

                //_emailService.SendEmail(emailMessage, smtpUsername, smtpPassword);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing the request.", ex);
            }
        }

        public IEnumerable<RequestDTO> GetRequestsByClient(int clientId)
        {
            try
            {
                var developerRequests = _requestRepository.GetDeveloperRequestsByClientId(clientId);

                var teamRequests = _requestRepository.GetTeamRequestsByClientId(clientId);

                var requests = developerRequests.Select(r => new RequestDTO
                {
                    RequestID = r.RequestID,
                   
                    ClientID = r.ClientID,
                   
                    RequestType = "Developer",
                   
                    StartDate = r.StartDate,
                  
                    EndDate = r.EndDate,
                   
                    Status = r.Status
                }).ToList();

                requests.AddRange(teamRequests.Select(r => new RequestDTO
                {
                    
                    RequestID = r.RequestID,
                   
                    ClientID = r.ClientID,
                    
                    RequestType = "Team",
                   
                    StartDate = r.StartDate,
                    
                    EndDate = r.EndDate,
                    
                    Status = r.Status
                }));

                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving requests.", ex);
            }
        }
    }



}

