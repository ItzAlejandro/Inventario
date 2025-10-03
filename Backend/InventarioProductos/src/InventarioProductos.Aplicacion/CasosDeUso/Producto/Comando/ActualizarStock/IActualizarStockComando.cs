namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.ActualizarStock
{
    public interface IActualizarStockComando
    {
        Task<bool> Ejecutar(ActualizarStockModel actualizarStockModel);
    }
}
