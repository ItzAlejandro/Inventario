namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId
{
    public interface IBuscarProductoPorIdConsulta
    {
        Task<BuscarProductoPorIdModelo> Ejecutar(Guid id);
    }
}
