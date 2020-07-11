using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class HearderTable
    {
      public  int idPo { get; set; }
      public string Customer { get; set; }
      public string Status { get; set; }
      public DateTime OrderDate { get; set; }


    }
}
