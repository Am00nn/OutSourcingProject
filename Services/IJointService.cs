using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IJointService
    {
        string AddTeamMemberToTeam(int developerID, int teamID);
        List<TeamMember> GetTeamMemberByTeamID(int teamID);
        string RemoveTeamMemberFromTeam(int developerID, int teamID);
        int AddReviewDeveloper(int DevID, ClientReviewInDTO input);
        int AddReviewTeam(int ClientID, ClientReviewInDTO input);
        int UpdateReviewDeveloper(int ClientID, ClientReviewInDTO review);
        int UpdateReviewTeam(int ClientID, ClientReviewInDTO review);
        List<ClientReviewDeveloper> GetDeveloperReviews(int Page, int PageSize, int? Rating, int? DevID);
        List<ClientReviewTeam> GetTeamReviews(int Page, int PageSize, int? Rating, int? TeamID);
        string DeleteTeamReview(int ClientID, int TeamID);
        string DeleteDeveloperReview(int ClientID, int DevID);
        int FeedbackValidation(int DevID, FeedBackOnClientDTO feedback);
        int UpdateFeebackOnClient(int DevID, FeedBackOnClientDTO feedback);
        string DeleteFeedbackOnClient(int DevID, int clientID);
        List<FeedbackOnClient> GetClientFeedback(int Page, int PageSize, int? Rating, int? ClientID);
    }
}