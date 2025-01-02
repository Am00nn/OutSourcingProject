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
    }
}