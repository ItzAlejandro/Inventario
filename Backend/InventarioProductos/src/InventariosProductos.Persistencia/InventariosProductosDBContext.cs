using InventarioProductos.Dominio.Entidades;
using InventariosProductos.Persistencia.Configuraciones;
using Microsoft.EntityFrameworkCore;

namespace InventariosProductos.Persistencia
{
    public class InventariosProductosDBContext : DbContext
    {
        public InventariosProductosDBContext(DbContextOptions<InventariosProductosDBContext> options) : base(options)
        {
            
        }
        public DbSet<ProductoEntidad> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new ProductosConfiguracion(modelBuilder.Entity<ProductoEntidad>());
        }
    }
}
