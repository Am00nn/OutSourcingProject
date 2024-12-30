using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IUserRepositry
    {
        void AddUser(User user);
        List<User> GetAllUsers(int iduser);
        User GetUser(string email, string password);
        User GetUserByEmail(string email);
        User GetUserById(int userId);
        User GetUserByPassword(string password);
        void Update(User user);
        public bool Delete(User user);
    }
}