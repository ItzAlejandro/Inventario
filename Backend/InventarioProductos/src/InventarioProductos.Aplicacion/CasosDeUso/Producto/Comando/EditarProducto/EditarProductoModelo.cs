using Microsoft.AspNetCore.Http;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EditarProducto
{
    public class EditarProductoModelo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public IFormFile? Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
