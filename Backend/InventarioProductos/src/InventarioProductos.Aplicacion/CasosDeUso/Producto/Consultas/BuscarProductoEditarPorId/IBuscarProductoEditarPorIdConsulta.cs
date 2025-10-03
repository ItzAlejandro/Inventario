namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoEditarPorId
{
    public interface IBuscarProductoEditarPorIdConsulta
    {
        Task<BuscarProductoEditarPorIdModelo> Ejecutar(Guid id);
    }
}
