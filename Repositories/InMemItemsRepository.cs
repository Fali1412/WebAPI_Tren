using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Tren.Entities;

namespace WebAPI_Tren.Repositories
{
    public class InMemItemsRepository : IInMemItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potato", Price = 43, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Apple", Price = 23, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Silicon", Price = 142, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Orb of Venom", Price = 53, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Aganim", Price = 43, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Metal Balls", Price = 231, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Paper", Price = 46, CreateDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Computer Mouse", Price = 45, CreateDate = DateTimeOffset.UtcNow}
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(_items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = _items.SingleOrDefault(item => item.Id == id);
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}