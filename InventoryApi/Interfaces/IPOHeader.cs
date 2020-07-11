using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Interfaces
{
   public interface IPOHeader
    {
        Task<List<HearderTable>> GetPOHeaders();
        Task<HearderTable> GetPOHeaderById(int id);
        Task<int> AddPOHeader(POHeader header);
        Task<int> DeletePOHeader(int id);
        Task UpdatePOHeader(POHeader header);

    }
}
