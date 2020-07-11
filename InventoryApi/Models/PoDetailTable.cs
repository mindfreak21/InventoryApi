
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class PoDetailTable
    {
        public int idPoDetails { get; set; }
        public decimal quantity { get; set; }
        public string description { get; set; }

        public decimal price { get; set; }

        public int idPo {get;set;}
    }
}
