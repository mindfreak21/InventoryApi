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
        Task<IActionResult> GetDetailByOrder(int idOrden);
        Task<string> AddDetailLine(PODetails detail);
        Task<int> DeleteDetailLine(int idOrdenDetalle);
        Task UpdateDetailLine(PODetails detail);

    }
}
