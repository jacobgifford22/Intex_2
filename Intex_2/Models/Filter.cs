using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models
{
    public class Filter
    {
        public IEnumerable<string> Severities { get; set; }
        public IEnumerable<string> Counties { get; set; }
        public IEnumerable<string> Cities { get; set; }
        public string SearchString { get; set; }

    }
}
