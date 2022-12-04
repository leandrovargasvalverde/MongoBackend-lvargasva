using MongoBackend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoBackend.DatabaseHelper
{
    public class Database
    {
        public MongoClient client;

        public IMongoDatabase db;
        public Database()
        {
            client = new MongoClient("mongodb+srv://root:Admin$1234@cluster0.j5g7fn8.mongodb.net/test");

            db = client.GetDatabase("MongoBackend");
        }
        public static void insertUser(User user)
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
