using FluentValidation;
using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Aplicacion.Excepciones;
using InventarioProductos.Aplicacion.Exterior.Servicios;
using InventarioProductos.Aplicacion.Persistencia;
using InventarioProductos.Dominio.Entidades;
using System.ComponentModel;
using System.Reflection;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.CrearProducto
{
    public class CrearProductoComando : ICrearProductoComando
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IValidator<CrearProductoModelo> _validator;
        private readonly IGuardarDocumentos _guardarDocumentos;
        private readonly string container = "Img";

        public CrearProductoComando(IRepositorioProductos repositorioProductos, IUnidadDeTrabajo unidadDeTrabajo, IValidator<CrearProductoModelo> validator,
            IGuardarDocumentos guardarDocumentos)
        {
            _repositorioProductos = repositorioProductos;
            _unidadDeTrabajo = unidadDeTrabajo;
            _validator = validator;
            _guardarDocumentos  = guardarDocumentos;
        }


        public async Task<Guid> Hadle(CrearProductoModelo crearProductoModelo)
        {
            var resultadoValidacion = await _validator.ValidateAsync(crearProductoModelo);

            if (!resultadoValidacion.IsValid)
            {
                throw new ExcepcionesValidacion(resultadoValidacion);
            }

            string? urlImagen = null;
            if (crearProductoModelo.Imagen is not null)
            {
                urlImagen = await _guardarDocumentos.Guardar(container, crearProductoModelo.Imagen, Guid.NewGuid());
            }


            var producto = new ProductoEntidad(crearProductoModelo.Nombre, crearProductoModelo.Categoria,  crearProductoModelo.Precio, crearProductoModelo.Stock,
                crearProductoModelo.Descripcion,urlImagen);

            try
            {
                var respuesta = await _repositorioProductos.Crear(producto);
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
