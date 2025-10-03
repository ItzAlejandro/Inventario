using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Aplicacion.Persistencia;
using InventarioProductos.Dominio.Entidades;
using System.ComponentModel.Design;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.ActualizarStock
{
    public class ActualizarStockComando : IActualizarStockComando
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo; 
        public ActualizarStockComando(IRepositorioProductos repositorioProductos, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _repositorioProductos = repositorioProductos;
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task<bool> Ejecutar(ActualizarStockModel actualizarStockModel)
        {
            try
            {
                var producto = await _repositorioProductos.ObtenerPorId(actualizarStockModel.Id);

                if (producto == null) return false;

                producto.AjustarStock(actualizarStockModel.Cantidad, actualizarStockModel.Tipo == 1);

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
