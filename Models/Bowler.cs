using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

        [MaxLength(50)]
        public string BowlerLastName { get; set; }

        [MaxLength(50)]
        public string BowlerFirstName { get; set; }

        [MaxLength(1)]
        public string BowlerMiddleInit { get; set; }

        [MaxLength(50)]
        public string BowlerAddress { get; set; }

        [MaxLength(50)]
        public string BowlerCity { get; set; }

        [MaxLength(2)]
        public string BowlerState { get; set; }

        [MaxLength(10)]
        public string BowlerZip { get; set; }

        [MaxLength(14)]
        public string BowlerPhoneNumber { get; set; }

        public int TeamID { get; set; }
        public Team Team { get; set; }


    }
}
