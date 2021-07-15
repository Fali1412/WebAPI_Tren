using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI_Tren.Entities;

namespace WebAPI_Tren.Repositories
{
    public class MongoDBItemsRepository : IInMemItemsRepository
    {
        private const string MongoDataBaseName = "WebAPI_Tren";
        private const string CollectionName = "items";
        private readonly IMongoCollection<Item> _mongoItemCollection;
        private readonly FilterDefinitionBuilder<Item> _filterDefinitionBuilder = Builders<Item>.Filter;
        
        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(MongoDataBaseName);
            _mongoItemCollection = mongoDatabase.GetCollection<Item>(CollectionName);
        }
        
        public IEnumerable<Item> GetItems()
        {
            return _mongoItemCollection.Find(new BsonDocument()).ToList();
        }

        public Item GetItem(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            return _mongoItemCollection.Find(filter).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            _mongoItemCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            var filter = _filterDefinitionBuilder.Eq(existingItem => existingItem.Id, item.Id);
            _mongoItemCollection.ReplaceOne(filter, item);
        }

        public void DeleteItem(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            _mongoItemCollection.DeleteOne(filter);
        }
    }
}