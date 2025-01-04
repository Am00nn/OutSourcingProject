using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IFeedBackOnClientRepository
    {
        int AddFeedback(FeedbackOnClient feedback);
        void DeleteFeedback(FeedbackOnClient feedback);
        List<FeedbackOnClient> GetAllFeedbacks();
        List<FeedbackOnClient> GetAllFeedbacksByClient(int ClientID);
        FeedbackOnClient GetReviewByFeedbackID(int feedbackID);
        void UpdateFeedback(FeedbackOnClient feedback);
        FeedbackOnClient GetReviewByClientAndTeamIDs(int ClientID, int TeamID);
        FeedbackOnClient GetReviewByClientAndDeveloperIDs(int ClientID, int DeveloperID);
        FeedbackOnClient GetByFeedbackID(int FeedbackID);
    }
}