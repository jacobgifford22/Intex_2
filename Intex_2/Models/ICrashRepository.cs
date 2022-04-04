using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models
{
    public interface ICrashRepository
    {
        IQueryable<Crash> Crashes { get; }

        IQueryable<Severity> Severities { get; }

        public void SaveCrash(Crash c);

        public void AddCrash(Crash c);
        
        public void DeleteCrash(Crash c);

    }
}
