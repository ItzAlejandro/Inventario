namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.ActualizarStock
{
    public class ActualizarStockModel
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public int Tipo { get; set; }
    }
}
