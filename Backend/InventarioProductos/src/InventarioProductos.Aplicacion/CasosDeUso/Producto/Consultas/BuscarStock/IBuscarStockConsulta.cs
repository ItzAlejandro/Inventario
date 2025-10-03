namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarStock
{
    public interface IBuscarStockConsulta
    {
        Task<BuscarStockModelo> Ejecutar(Guid id);
    }
}
