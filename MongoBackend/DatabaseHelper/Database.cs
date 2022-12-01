using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoBackend.Models;
using System.Text.Json.Nodes;

namespace MongoBackend.DatabaseHelper
{
    public class Database
    {
        public List<User> getUsers()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://root:Admin$1234@cluster0.j5g7fn8.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            List<BsonDocument> userArray = users.Find(new BsonDocument()).ToList();

            List<User> userList = new List<User>();

            foreach (BsonDocument bsonUser in userArray)
            {
                User user = BsonSerializer.Deserialize<User>(bsonUser);
                userList.Add(user);
            }

            return userList;
        }

        public void insertUser(User user)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://root:Admin$1234@cluster0.j5g7fn8.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
            {
                { "name", user.name },
                { "email", user.email },
                { "phone", user.phone },
                { "address", user.address},
                { "dateIn", user.dateIn }
            };

            users.InsertOne(doc);
        }
    }
}
