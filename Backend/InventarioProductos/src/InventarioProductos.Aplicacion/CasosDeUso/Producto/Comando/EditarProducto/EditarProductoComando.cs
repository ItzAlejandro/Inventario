using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Aplicacion.Exterior.Servicios;
using InventarioProductos.Aplicacion.Persistencia;


namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EditarProducto
{
    public class EditarProductoComando : IEditarProductoComando
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IGuardarDocumentos _guardarDocumentos;
        private readonly string container = "Img";
        public EditarProductoComando(IRepositorioProductos repositorioProductos, IUnidadDeTrabajo unidadDeTrabajo,
            IGuardarDocumentos guardarDocumentos)
        {
            _repositorioProductos = repositorioProductos;
            _unidadDeTrabajo = unidadDeTrabajo;
            _guardarDocumentos = guardarDocumentos;
        }
        public async Task<bool> Hadle(EditarProductoModelo editarProductoModelo)
        {
            var productoEntidad = await _repositorioProductos.ObtenerPorId(editarProductoModelo.Id);
            if (productoEntidad == null)
                throw new Exception("El producto no fue encontrado.");

            string? urlImagen = productoEntidad.Imagen;
            if (editarProductoModelo.Imagen is not null)
            {
                urlImagen = await _guardarDocumentos.Guardar(container, editarProductoModelo.Imagen, editarProductoModelo.Id);
            }

            productoEntidad.Editar(editarProductoModelo.Id, editarProductoModelo.Nombre, editarProductoModelo.Categoria, editarProductoModelo.Precio,
                editarProductoModelo.Stock, editarProductoModelo.Descripcion, urlImagen);


            try
            {
                await _repositorioProductos.Actualizar(productoEntidad);
                await _unidadDeTrabajo.Persistir();
                return true;
            }
            catch (Exception)
            {
                await _unidadDeTrabajo.Reversar();
                return false;
            }
        }
    }
}
