using OutsourcingSystem.DTOs;

namespace OutsourcingSystem.Services
{
    public interface IRequestService
    {
        IEnumerable<RequestDTO> GetRequestsByClient(int clientId);
        void ProcessRequest(int requestId, string status, string smtpUsername, string smtpPassword);
        void SubmitRequest(RequestDTO requestDto, string smtpUsername, string smtpPassword);
    }
}