
using InventarioProductos.Aplicacion.Contratos.Repositorios;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones
{
    public class ListarProductosTransaccionesConsulta : IListarProductosTransaccionesConsulta
    {
        private readonly IRepositorioProductos _repositorioProductos;
        public ListarProductosTransaccionesConsulta(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public async Task<List<ListarProductosTransaccionesModelo>> Ejecutar()
        {
            var respuesta = await _repositorioProductos.BuscarProductoTransacciones();
            return respuesta;
        }
    }
}
