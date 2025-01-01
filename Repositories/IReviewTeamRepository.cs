using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IReviewTeamRepository
    {
        int AddTeamReview(ClientReviewTeam teamRev);
        void DeleteTeamReview(ClientReviewTeam TeamRev);
        List<ClientReviewTeam> GetAllTeamReviews();
        ClientReviewTeam GetTeamReviewByTeamID(int TeamID);
        void UpdateTeamReview(ClientReviewTeam TeamRev);
        ClientReviewTeam GetReviewByClientAndTeamIDs(int ClientID, int TeamID);
    }
}