
using InventarioProductos.Aplicacion.Contratos.Repositorios;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoEditarPorId
{
    public class BuscarProductoEditarPorIdConsulta : IBuscarProductoEditarPorIdConsulta
    {
        private readonly IRepositorioProductos _repositorioProductos;

        public BuscarProductoEditarPorIdConsulta(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public async Task<BuscarProductoEditarPorIdModelo> Ejecutar(Guid id)
        => await _repositorioProductos.BuscarProductoEditar(id);
    }
}
