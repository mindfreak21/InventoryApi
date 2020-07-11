using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class Item
    {
        [Key]
        public int idItem { get; set; }

        [Required]
        [MaxLength(50)]
        public string description { get; set; }

        [Required]
        [MaxLength(15)]
        public string unitOfMeasure { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal quantityInStock { get; set; }

        public List<PODetails> poDetails { get; set; }
    }
}
