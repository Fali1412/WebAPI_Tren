using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _mongoItemCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            return await _mongoItemCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateItemAsync(Item item)
        {
            await _mongoItemCollection.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = _filterDefinitionBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await _mongoItemCollection.ReplaceOneAsync(filter, item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            await _mongoItemCollection.DeleteOneAsync(filter);
        }
    }
}