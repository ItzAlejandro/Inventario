using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoEditarPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarStock;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones;
using InventarioProductos.Dominio.Entidades;

namespace InventarioProductos.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioProductos : IRepositorio<ProductoEntidad>
    {
        Task<BuscarProductoPorIdModelo> BuscarPorIdModel(Guid id);
        Task<BuscarProductoEditarPorIdModelo> BuscarProductoEditar(Guid id);
        Task<List<ListarProductosTransaccionesModelo>> BuscarProductoTransacciones();
        Task<BuscarStockModelo> GetStock(Guid id);
    }
}
