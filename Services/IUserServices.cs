using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using System.Security.Claims;

namespace OutsourcingSystem.Services
{
    public interface IUserServices
    {
        int AddUserAdmin(AdminInputDto user);
        bool DeleteUser(int userIdFromToken);
        List<User> GetAllUsers(ClaimsPrincipal user);
        string GetEmail(int userid);
        User GetUserByID(int ID, ClaimsPrincipal user);
        User Login(string email, string password);
        bool UpdateUser(int userIdFromToken, UserUpdateDto updateRequest);
        bool UserExists(int userId);
    }
}