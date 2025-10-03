namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EditarProducto
{
    public interface IEditarProductoComando
    {
        Task<bool> Hadle(EditarProductoModelo editarProductoModelo);
    }
}
