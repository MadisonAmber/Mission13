using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }

        [MaxLength(50)]
        public string TeamName { get; set; }
    }
}
