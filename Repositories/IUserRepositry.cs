using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IUserRepositry
    {
        void AddUser(User user);
        public int AddUserInt(User user);
        List<User> GetAllUsers(int iduser);
        User GetUser(string email, string password);
        User GetUserByEmail(string email);
        User GetUserById(int userId);
        User GetUserByPassword(string password);
        void Update(User user);
        public bool Delete(User user);
        public bool DoesEmailExist(string email);
        public bool UserExists(int userId);
    }
}