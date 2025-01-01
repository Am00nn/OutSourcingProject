using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IUserRepositry
    {
        void AddUser(User user);
        int AddUserInt(User user);
        bool Delete(User user);
        bool DoesEmailExist(string email);
        List<User> GetAllUsers(int iduser);
        User GetUser(string email, string password);
        User GetUserByEmail(string email);
        User GetUserById(int userId);
        User GetUserByPassword(string password);
        void Update(User user);
        bool UserExists(int userId);
    }
}