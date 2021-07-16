using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Tren.Entities;

namespace WebAPI_Tren.Repositories
{
    public interface IInMemItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
    }
}