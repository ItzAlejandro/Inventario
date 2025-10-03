using InventarioTransacciones.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioTransacciones.Domain.Entidades
{
    public class TransaccionEntidad
    {
        protected TransaccionEntidad() { }

        public Guid Id { get; set; }
        public EstadoTransaccion TipoTransaccion { get; private set; }
        public DateTime FechaCreacion { get; private set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; private set; } = DateTime.UtcNow;
        public DateTime? FechaEliminacion { get; private set; }
        public bool Activo { get; private set; } = true;
        public Guid IdProducto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal PrecioTotal { get; private set; }
        public string? Detalle { get; private set; }

        [NotMapped] 
        public int Stock { get; private set; }

        public void EliminarTransaccion()
        {
            Activo = false;
            FechaEliminacion = DateTime.UtcNow;
            FechaModificacion = DateTime.UtcNow;
        }

        public void ActualizarCantidad(int nuevaCantidad)
        {
            Cantidad = nuevaCantidad;
            ActualizarPrecioTotal();
            FechaModificacion = DateTime.UtcNow;
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            PrecioUnitario = nuevoPrecio;
            ActualizarPrecioTotal();
            FechaModificacion = DateTime.UtcNow;
        }

        private void ActualizarPrecioTotal()
        {
            PrecioTotal = Cantidad * PrecioUnitario;
        }

        public TransaccionEntidad(Guid idProducto, EstadoTransaccion tipoTransaccion, int cantidad, decimal precioUnitario, int stock, string? detalle = null)
        {
            if (tipoTransaccion == EstadoTransaccion.Venta && cantidad > stock)
                throw new Exception("No existe stock");

            Id = Guid.NewGuid();
            IdProducto = idProducto;
            TipoTransaccion = tipoTransaccion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Detalle = detalle;
            Stock = stock;

            ActualizarPrecioTotal();

            FechaCreacion = DateTime.UtcNow;
            FechaModificacion = DateTime.UtcNow;
            Activo = true;
        }
    }
}
