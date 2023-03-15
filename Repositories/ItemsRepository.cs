using MongoDB.Driver;
using MyProject.Catalog.Entities;

namespace MyProject.Catalog.Service.Repositories
{
    public class ItemsRepository
    {
        private const string collectionName = "items"; // mongoDB collection name
        private readonly IMongoCollection<Item> dbCollection;
        private FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public ItemsRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017"); // mongo db connection
            var database = mongoClient.GetDatabase("Catalog"); // database name
            dbCollection = database.GetCollection<Item>(collectionName); // database collection (tables)
            
        }
    }
}