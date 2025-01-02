using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using System.Security.Claims;

namespace OutsourcingSystem.Services
{
    public interface IUserServices
    {
        public int AddUserAdmin(AdminInputDto user);
       // int AddUser(UserInputDto user);
        void ApproveClient(ApprovalDto approval, ClaimsPrincipal user, int userid);
        bool DeleteUser(string role, int userIdFromToken);
        List<User> GetAllUsers(int userid);
        User GetUserByID(int ID, ClaimsPrincipal user);
        User Login(string email, string password, string role);
        bool UpdateUser(int userIdFromToken, UserUpdateDto updateRequest);
        bool UserExists(int userId);
        public IEnumerable<Client> GetUnapprovedClients(ClaimsPrincipal User );
        public IEnumerable<Developer> GetUnapprovedDeveloper(ClaimsPrincipal user);
        public void Approvedeveloper(ApproveDeveloper approval, ClaimsPrincipal user, int userid);
    }
}