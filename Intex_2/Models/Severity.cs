using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models
{
    public class Severity
    {
        [Key]
        [Required]
        public int CRASH_SEVERITY_ID { get; set; }
        public string SEVERITY_NAME { get; set; }

        public virtual ICollection<Crash> Crashes { get; set; }
    }
}
