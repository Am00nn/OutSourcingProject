using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class ReviewDevRepository : IReviewDevRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewDevRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Adds a new DevReview [returns review id]
        public int AddDevReview(ClientReviewDeveloper DevRev)
        {
            _context.ClientReviewDeveloper.Add(DevRev);
            _context.SaveChanges();
            return DevRev.ReviewID;
        }

        //Update DevReview [does not return anything]
        public void UpdateDevReview(ClientReviewDeveloper DevRev)
        {
            _context.ClientReviewDeveloper.Update(DevRev);
            _context.SaveChanges();
        }

        //Hard deleting Developer review
        public void DeleteDevReview(ClientReviewDeveloper DevRev)
        {
            _context.ClientReviewDeveloper.Remove(DevRev);
        }

        //Gets all DeveloperReviews [returns list of developer reviews]
        public List<ClientReviewDeveloper> GetAllDevReviews()
        {
            return _context.ClientReviewDeveloper.ToList();
        }

        //Get DeveloperReview by DeveloperID [returns devReview by ID]
        public ClientReviewDeveloper GetDevReviewByDevID(int DevID)
        {
            return _context.ClientReviewDeveloper.FirstOrDefault(r => r.DeveloperID == DevID);
        }

        public ClientReviewDeveloper GetReviewByClientAndTeamIDs(int ClientID, int DevID)
        {
              return _context.ClientReviewDeveloper.FirstOrDefault(r => r.DeveloperID == DevID && r.ClientID == ClientID);
        }
    }
}
