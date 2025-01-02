using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IReviewDevRepository
    {
        int AddDevReview(ClientReviewDeveloper DevRev);
        void DeleteDevReview(ClientReviewDeveloper DevRev);
        List<ClientReviewDeveloper> GetAllDevReviews();
        ClientReviewDeveloper GetDevReviewByDevID(int DevID);
        void UpdateDevReview(ClientReviewDeveloper DevRev);
        ClientReviewDeveloper GetReviewByClientAndTeamIDs(int ClientID, int DevID);
    }
}