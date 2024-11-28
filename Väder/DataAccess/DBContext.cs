using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väder.DataAccess
{
    public class Vädercontext : DbContext
    {
        private const string connectionString =
        "Server=(localdb)\\MSSQLLocalDB;Database=MorrisDB;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Weathermodel> Weatherdata { get; set; }
    }
}

