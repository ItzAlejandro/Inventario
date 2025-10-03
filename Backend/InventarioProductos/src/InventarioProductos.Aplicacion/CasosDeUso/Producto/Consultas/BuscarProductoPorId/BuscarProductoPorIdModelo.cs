namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId
{
    public class BuscarProductoPorIdModelo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Imagen {  get; set; }
        public DateTime FechaCreacion { get; set; } 
        public decimal Precio { get; set; } 
        public int Stock {  get; set; }
    }
}
