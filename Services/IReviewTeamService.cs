using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IReviewTeamService
    {
        int AddReviewTeam(int ClientID, ClientReviewInDTO input);
        List<ClientReviewTeam> GetAllTeamReviews(int Page, int PageSize, int? Rating, int? TeamID);
        ClientReviewTeam GetReviewByTeamID(int TeamID);
        int UpdateTeamReview(int ClientID, ClientReviewInDTO review);
        bool CheckReviewByTeamIDAndClientID(int TeamID, int ClientID);
        bool CheckReviewByTeamID(int TeamID);
        void DeleteTeamReview(ClientReviewTeam teamRev);
        ClientReviewTeam GetRevTeamByTeamIDAndClientID(int TeamID, int ClientID);
    }
}