using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models
{
    public class CrashDbContext : DbContext
    {
        public CrashDbContext(DbContextOptions<CrashDbContext> options) : base (options)
        {

        }

        public DbSet<Crash> Crashes { get; set; }

        public DbSet<Severity> Severities { get; set; }
    }
}
