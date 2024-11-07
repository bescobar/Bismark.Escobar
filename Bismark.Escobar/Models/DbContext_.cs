using Bismark.Escobar.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bismark.Escobar.Models
{
    public class DbContext_: DbContext
    {
        public DbContext_(DbContextOptions<DbContext_> options) : base(options) {

        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Cuenta> cuenta { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }

    }
}
