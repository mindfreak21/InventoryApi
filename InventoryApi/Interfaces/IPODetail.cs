using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Interfaces
{
   public interface IPODetail
    {
        Task<List<PoDetailTable>> GetDetailByOrder(int idOrden);
        Task<int> AddDetailLine(PODetails detail);
        Task<int> DeleteDetailLine(int idOrdenDetalle);
        Task UpdateDetailLine(PODetails detail);
    }
}
