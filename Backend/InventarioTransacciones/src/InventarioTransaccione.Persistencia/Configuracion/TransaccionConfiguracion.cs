using InventarioTransacciones.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventarioTransaccione.Persistencia.Configuracion
{
    public class TransaccionConfiguracion
    {
        public TransaccionConfiguracion(EntityTypeBuilder<TransaccionEntidad> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(e => e.TipoTransaccion)
                .IsRequired();

            entityBuilder.Property(e => e.FechaCreacion)
                .IsRequired();

            entityBuilder.Property(e => e.FechaModificacion)
                .IsRequired();

            entityBuilder.Property(e => e.FechaEliminacion);

            entityBuilder.Property(e => e.Activo)
                .IsRequired();

            entityBuilder.Property(e => e.IdProducto)
                .IsRequired();

            entityBuilder.Property(e => e.Cantidad)
                .IsRequired();

            entityBuilder.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entityBuilder.Property(e => e.PrecioTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();


            entityBuilder.Property(e => e.Detalle)
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}
