using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IFeedBackOnClientService
    {
        int AddFeedbackOnClient(int ReviewerID, FeedBackOnClientDTO feedback, int OnTeam);
        string DeleteFeedback(int ClientID, int ReviewerID);
        List<FeedbackOnClient> GetAllFeedbacks(int Page, int PageSize, int? Rating, int? ClientID);
        List<FeedbackOnClient> GetFeedbackByClientID(int ClientID);
        FeedbackOnClient GetRevTeamByDevIDAndClientID(int DevID, int ClientID);
        FeedbackOnClient GetRevTeamByTeamIDAndClientID(int TeamID, int ClientID);
        int UpdateFeedback(int ClientID, FeedBackOnClientDTO feedback);
    }
}