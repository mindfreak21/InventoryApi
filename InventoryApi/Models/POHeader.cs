using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace InventoryApi.Models
{
    public class POHeader
    {
        [Key]
        public int idPO { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomeridCustomer { get; set; }
        public int StatusPurchaseOrderidStatus { get; set; }
        public List<PODetails> poDetails { get; set; }
    }
}
