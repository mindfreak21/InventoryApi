using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Interfaces
{
    public interface ICatalogItem
    {
        Task<List<Item>> GetItems();
        Task<Item> GetItemById(int id);
        Task<int> AddItem(Item item);
        Task<int> DeleteItem(int id);
        Task UpdateItem(Item item);
    }
}
