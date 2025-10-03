namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EliminarProducto
{
    public interface IEliminarProductoComando
    {
        Task<bool> Ejecutar(Guid id);
    }
}
