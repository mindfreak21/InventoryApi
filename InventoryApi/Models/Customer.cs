using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class Customer
    {
        [Key]
        public int idCustomer { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        public List<POHeader> PoHeader { get; set; }
    }
}
