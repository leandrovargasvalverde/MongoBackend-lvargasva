using MongoBackend.Models;

namespace MongoBackend.DatabaseHelper
{
    public interface IUserCollection
    {
        //void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string user);
        List<User> GetAllUsers();
        User GetUserById(string id1);
        User GetUserById2(string id2);
    }
}
