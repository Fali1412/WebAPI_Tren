using System;
using System.Collections.Generic;
using WebAPI_Tren.Entities;

namespace WebAPI_Tren.Repositories
{
    public interface IInMemItemsRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}