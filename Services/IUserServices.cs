using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using System.Security.Claims;

namespace OutsourcingSystem.Services
{
    public interface IUserServices
    {
        public int AddUser(UserInputDto user);
        bool DeleteUser(string role, int userIdFromToken);
        List<User> GetAllUsers(int userid);
        User GetUserByID(int ID, ClaimsPrincipal user);
        User Login(string email, string password);
        bool UpdateUser(int userIdFromToken, UserUpdateDto updateRequest);
        public bool UserExists(int userId);
    }
}