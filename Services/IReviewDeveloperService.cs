using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IReviewDeveloperService
    {
        int AddReviewDev(int ClientID, ClientReviewInDTO input);
        bool CheckReviewByDevID(int DevID);
        List<ClientReviewDeveloper> GetAllDevReviews(int Page, int PageSize, int? Rating, int? DevID);
        ClientReviewDeveloper GetReviewByDevID(int DevID);
        int UpdateDevReview(int ClientID, ClientReviewInDTO review);
        bool CheckReviewByDevIDandTeamID(int ClientID, int DevID);
        void DeleteDeveloperReview(ClientReviewDeveloper devrev);
        ClientReviewDeveloper GetByDevIDandTeamID(int ClientID, int DevID);
    }
}