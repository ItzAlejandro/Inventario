using InventarioTransaccione.Persistencia.Configuracion;
using InventarioTransacciones.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InventarioTransaccione.Persistencia
{
    public class InventarioTransaccioneDBContext : DbContext
    {
        public InventarioTransaccioneDBContext(DbContextOptions<InventarioTransaccioneDBContext> options) : base(options) 
        {
            
        }
        public DbSet<TransaccionEntidad> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new TransaccionConfiguracion(modelBuilder.Entity<TransaccionEntidad>());
        }
    }
}
