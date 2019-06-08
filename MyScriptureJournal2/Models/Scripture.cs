using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal2.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Cannon { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }

        [DataType(DataType.Date)]
        public DateTime Accessed { get; set; }

        public string Notes { get; set; }
    }
}
