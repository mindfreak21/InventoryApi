using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class PODetails
    {
        [Key]
        public int idPODetails { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public int Quantiy { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Price {get;set;}
        public int POHeaderidPo { get; set; }
        public int ItemidItem { get; set; }
      
        
    }
}
