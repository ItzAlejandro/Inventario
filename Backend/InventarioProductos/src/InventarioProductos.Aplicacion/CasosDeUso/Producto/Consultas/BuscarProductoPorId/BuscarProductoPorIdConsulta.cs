using InventarioProductos.Aplicacion.Contratos.Repositorios;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId
{
    public class BuscarProductoPorIdConsulta : IBuscarProductoPorIdConsulta
    {
        private readonly IRepositorioProductos _repositorioProductos;

        public BuscarProductoPorIdConsulta(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public async Task<BuscarProductoPorIdModelo> Ejecutar(Guid id)
           => await _repositorioProductos.BuscarPorIdModel(id);
          
    }
}
