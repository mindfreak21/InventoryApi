using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        [MaxLength(15)]
        public string userName { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string password { get; set; }

        public int idRol { get; set; }

        public string rolName { get; set; }

        public Roles Roles { get; set; }


    }
}
