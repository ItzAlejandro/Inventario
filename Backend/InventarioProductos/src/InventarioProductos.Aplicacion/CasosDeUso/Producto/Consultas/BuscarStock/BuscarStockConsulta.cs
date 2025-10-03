using InventarioProductos.Aplicacion.Contratos.Repositorios;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarStock
{
    public class BuscarStockConsulta : IBuscarStockConsulta
    {
        private readonly IRepositorioProductos _repositorioProductos;
        public BuscarStockConsulta(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public async Task<BuscarStockModelo> Ejecutar(Guid id)
        {
            try
            {
                return await _repositorioProductos.GetStock(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
