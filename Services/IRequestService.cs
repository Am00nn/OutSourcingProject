using OutsourcingSystem.DTOs;

namespace OutsourcingSystem.Services
{
    public interface IRequestService
    {
        Task ProcessRequestAsync(int requestId, bool isAccepted, string requestType);
        Task SubmitRequestAsync(RequestDto requestDto, int userid,ProjectInputDto project);
    }
}