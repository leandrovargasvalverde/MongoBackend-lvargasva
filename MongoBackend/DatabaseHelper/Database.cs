using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoBackend.Models;
using System.Text.Json.Nodes;

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
    }
}
