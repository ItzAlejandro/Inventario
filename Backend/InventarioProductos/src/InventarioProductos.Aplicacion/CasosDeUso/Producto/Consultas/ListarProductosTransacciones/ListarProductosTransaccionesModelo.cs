namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones
{
    public class ListarProductosTransaccionesModelo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}
