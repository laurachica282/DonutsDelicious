using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Datos
{
    public class DonasContext
    {
        public class DonasContext : DbContext
        {
            public DbSet<DonaTipo> DonaTipos { get; set; }
            public DbSet<DonaTamano> DonaTamanos { get; set; }
            public DbSet<DonaRelleno> DonaRellenos { get; set; }
            public DbSet<DonaCobertura> DonaCoberturas { get; set; }
            public DbSet<DonaTopping> DonaToppings { get; set; }
            public DbSet<Transaccion> Transacciones { get; set; }
            public DbSet<TransaccionTopping> TransaccionToppings { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("Server=(localdb)\\MSSQLLocalDB;Database=happydonuts;User Id=laurac;Password=Camila2011;",
                new MySqlServerVersion(new Version(8, 0, 23)));
            }

            public DonasContext(DbContextOptions<DonasContext> options) : base(options) { }
        }
    }
}
