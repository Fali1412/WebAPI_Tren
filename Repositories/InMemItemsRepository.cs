using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }

        public Item GetItem(Guid id)
        {
            return _items.SingleOrDefault(item => item.Id == id);
        }

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items.RemoveAt(index);
        }
    }
}