using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class StatusPurchaseOrder
    {
        [Key]
        public int idStatus { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; }
        public List<POHeader> PoHeader { get; set; }
    }
}
