using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Aplicacion.Persistencia;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EliminarProducto
{
    public class EliminarProductoComando : IEliminarProductoComando
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;


        public EliminarProductoComando(IRepositorioProductos repositorioProductos, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _repositorioProductos = repositorioProductos;
            _unidadDeTrabajo = unidadDeTrabajo;

        }
        public async Task<bool> Ejecutar(Guid id)
        {
            try
            {
                var producto = await _repositorioProductos.ObtenerPorId(id);

                if (producto == null)
                    throw new Exception("El producto no fue encontrado.");

                producto.Eliminar();

                await _repositorioProductos.Actualizar(producto);
                await _unidadDeTrabajo.Persistir();

                return true;
            }
            catch (Exception)
            {
                await _unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
