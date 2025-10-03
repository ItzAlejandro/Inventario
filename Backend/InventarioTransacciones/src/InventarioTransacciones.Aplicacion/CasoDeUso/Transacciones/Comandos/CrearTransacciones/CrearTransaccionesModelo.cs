using InventarioTransacciones.Domain.Enums;

namespace InventarioTransacciones.Aplicacion.CasoDeUso.Transacciones.Comandos.CrearTransacciones
{
    public class CrearTransaccionesModelo
    {
        public int TipoTransaccion {  get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public string? Detalle {  get; set; }
    }
}
