using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class Roles
    {
        [Key]
        public int idRol { get; set; }

        [Required]
        [MaxLength(50)]
        public string roleName { get; set; }
    }
}
