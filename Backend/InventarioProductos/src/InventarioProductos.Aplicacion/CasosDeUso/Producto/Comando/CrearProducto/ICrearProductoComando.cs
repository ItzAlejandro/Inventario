namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.CrearProducto
{
    public interface ICrearProductoComando
    {
        Task<Guid> Hadle(CrearProductoModelo crearProductoModelo);
    }
}
