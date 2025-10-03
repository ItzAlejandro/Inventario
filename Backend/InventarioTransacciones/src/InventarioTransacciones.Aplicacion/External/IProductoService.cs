using InventarioTransacciones.Aplicacion.External.DTO;

namespace InventarioTransacciones.Aplicacion.External
{
    public interface IProductoService
    {
        Task<BuscarStockModelo> ObtenerProductoPorIdAsync(Guid id);
        Task<bool> ActualizarStock(ActualizarStockModel modelo);
    }
}
