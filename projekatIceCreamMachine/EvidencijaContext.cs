using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatIceCreamMachine
{

    public class EvidencijaContext : DbContext
    {
        public DbSet<Sladoled> Sladoledi { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Blogging;TrustServerCertificate=True; Trusted_Connection=True;"); // Postavite svoj ConnectionString ovdje
        }
    }
}
