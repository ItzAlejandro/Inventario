using InventarioProductos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventariosProductos.Persistencia.Configuraciones
{
    public class ProductosConfiguracion
    {
        public ProductosConfiguracion(EntityTypeBuilder<ProductoEntidad> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(e => e.Nombre)
                 .HasMaxLength(100)
                 .IsRequired(true);

            entityBuilder.Property(e => e.Descripcion)
                 .HasMaxLength(250)
                 .IsRequired(false);           
            
            entityBuilder.Property(e => e.Imagen)
                 .HasMaxLength(250)
                 .IsRequired(false);    
            
            entityBuilder.Property(e => e.Categoria)
                 .HasMaxLength(250)
                 .IsRequired(true);

            entityBuilder.Property(e => e.FechaCreacion)
                .IsRequired();


            entityBuilder.Property(e => e.FechaModificacion)
                .IsRequired();


            entityBuilder.Property(e => e.Activo)
                .IsRequired(true);

            entityBuilder.Property(e => e.Precio)
                .IsRequired(true);  

            entityBuilder.Property(e => e.Stock)
                .IsRequired(true);

            entityBuilder.Property(e => e.FechaEliminacion);
               
        }
    }
}
