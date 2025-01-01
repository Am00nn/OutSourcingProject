using OutsourcingSystem.Models;
using System.Security.Claims;

namespace OutsourcingSystem.Services
{
    public interface IRequestService
    {
        string ProcessRequest(int requestId, string requestType, bool isAccepted);
        string SubmitRequest(ClaimsPrincipal user, SubmitRequestModel requestModel);
    }
}