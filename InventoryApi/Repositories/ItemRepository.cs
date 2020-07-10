using InventoryApi.Context;
using InventoryApi.Interfaces;
using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Repositories
{
    public class ItemRepository : ICatalogItem
    {

        InventoryContext _context;

        public ItemRepository(InventoryContext context)
        {
            _context = context;
        }
        public async Task<int> AddItem(Item item)
        {
            int identityItem;

         if (_context != null)
            {
                await _context.itemCatalog.AddAsync(item);
                await _context.SaveChangesAsync();

                identityItem = item.idItem;

                return identityItem;
            }

            return 0;
        }

        public async Task<int> DeleteItem(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var item = await _context.itemCatalog.FirstOrDefaultAsync(x => x.idItem == id);

                if (item != null)
                {
                    _context.itemCatalog.Remove(item);
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task<Item> GetItemById(int id)
        {
         
           if (_context == null)
            {
                return null;
            }

            return await _context.itemCatalog.FindAsync(id);

        }

        public async Task<List<Item>> GetItems()
        {
            if (_context != null)
            {
                return await _context.itemCatalog.ToListAsync();
            }

            return null; 
        }

        public async Task UpdateItem(Item item)
        {
          if (_context != null)
            {
                _context.itemCatalog.Update(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
