using FluentValidation;
using InventarioTransacciones.Aplicacion.Contratos.Repositorios;
using InventarioTransacciones.Aplicacion.External;
using InventarioTransacciones.Aplicacion.External.DTO;
using InventarioTransacciones.Aplicacion.Persistencia;
using InventarioTransacciones.Domain.Entidades;
using InventarioTransacciones.Domain.Enums;
using System.Reflection;

namespace InventarioTransacciones.Aplicacion.CasoDeUso.Transacciones.Comandos.CrearTransacciones
{
    public class CrearTransaccionesComando : ICrearTransaccionesComando
    {
        private readonly IRepositorioTransacciones _repositorioTransacciones;
        private readonly IValidator<CrearTransaccionesModelo> _validator;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IProductoService _productoService;
        public CrearTransaccionesComando(IRepositorioTransacciones repositorioTransacciones, 
            IValidator<CrearTransaccionesModelo> validator, IUnidadDeTrabajo unidadDeTrabajo, IProductoService productoService)
        {
            _repositorioTransacciones = repositorioTransacciones;
            _validator = validator;
            _unidadDeTrabajo = unidadDeTrabajo;
            _productoService  = productoService;
        }
        public async Task<Guid> Hadle(CrearTransaccionesModelo crear)
        {
            var response = await _productoService.ObtenerProductoPorIdAsync(crear.IdProducto);

            if (response == null) throw new Exception("Existio un error en Productos");

            var tipo = (EstadoTransaccion)crear.TipoTransaccion;
            
            var transaccion = new TransaccionEntidad(crear.IdProducto, tipo, crear.Cantidad,
                crear.PrecioUnitario, response.Stock, crear.Detalle);

            try
            {
                var respuesta = await _repositorioTransacciones.Crear(transaccion);
                var actualizarStock = await _productoService.ActualizarStock(new ActualizarStockModel
                {
                    Id = response.id,Cantidad = crear.Cantidad, Tipo =crear.TipoTransaccion
                });
                if(!actualizarStock) await _unidadDeTrabajo.Reversar();
                await _unidadDeTrabajo.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await _unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
