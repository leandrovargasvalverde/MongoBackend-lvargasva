using MongoBackend.DatabaseHelper;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoBackend.Models
{
    public class UserCollection : IUserCollection
    {
        internal Database _users = new Database();
        private IMongoCollection<User> Collection;
        public UserCollection()
        {
            Collection = _users.db.GetCollection<User>("Users");
        }
        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
        public List<User> GetAllUsers()
        {
            var list = Collection.Find(new BsonDocument()).ToListAsync();

            return list.Result;
        }
        public User GetUserById(string id1)
        {
            var user = Collection.Find(new BsonDocument { { "_id", new ObjectId(id1) } }).FirstAsync().Result;

            return user;
        }
        public User GetUserById2(string id2)
        {
            var user = Collection.Find(new BsonDocument { { "_id", new ObjectId(id2) } }).FirstAsync().Result;

            return user;
        }
        //public void InsertUser(User user)
        //{
        //    Collection.InsertOneAsync(user);
        //}
        public void UpdateUser(User user)
        {
            var filter = Builders<User>
                .Filter
                .Eq(s => s._id, user._id);

            Collection.ReplaceOneAsync(filter, user);
        }
        public void DeleteUser(string id2)
        {
            var filter = Builders<User>
                .Filter
                .Eq(s => s._id, new ObjectId(id2));

            Collection.DeleteOneAsync(filter);
        }
    }
}
