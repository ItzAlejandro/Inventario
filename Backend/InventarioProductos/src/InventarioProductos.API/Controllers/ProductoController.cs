using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.ActualizarStock;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.CrearProducto;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EditarProducto;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EliminarProducto;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoEditarPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarStock;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductos;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones;
using InventarioProductos.Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace InventarioProductos.API.Controllers
{
    [Route("api/v1/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> CrearProducto(
            [FromServices] ICrearProductoComando service,
            [FromForm] CrearProductoModelo model
            )
        {

            var response = await service.Hadle(model);
            if (response == Guid.Empty) return BadRequest(RespuestaApiServicio.Response(
                StatusCodes.Status400BadRequest, response, "Existio un error al crear un producto"));


            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }

        [HttpPut("ActualizarProducto")]
        public async Task<ActionResult> ActualizarProducto(
            [FromServices] IEditarProductoComando service,
            [FromForm] EditarProductoModelo model
            )
        {

            var response = await service.Hadle(model);
            if (!response) return BadRequest(RespuestaApiServicio.Response(
                StatusCodes.Status400BadRequest, response, "Existio un error al actualizar un producto"));


            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }

        [HttpPut("productoEliminar")]

        public async Task<IActionResult> AssignmentUpdate(
           [FromServices] IEliminarProductoComando service,
           [FromBody] Guid id)
        {

            var response = await service.Ejecutar(id);
            if (!response) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, response, "Existio un error al eliminar producto"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }

        [HttpPut("ActualizarStock")]

        public async Task<IActionResult> ActualizarStock(
           [FromServices] IActualizarStockComando service,
           [FromBody] ActualizarStockModel id)
        {

            var response = await service.Ejecutar(id);
            if (!response) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, response, "Existio un error al actualziar el stock"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }

        [HttpGet("ListarProductos")]

        public async Task<IActionResult> ListarProductos(
        [FromQuery] FiltroPaginadoModel filtro,
        [FromServices] IListarProductosConsulta service)
        {


            var listProvider = await service.Ejecutar(filtro);
            if (listProvider == null || listProvider.cantidadTotal == 0) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, listProvider, "No existen Productos"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, listProvider));
        }



        [HttpGet]
        public async Task<IActionResult> AssignmentById(
               [FromServices] IBuscarProductoPorIdConsulta service,
               Guid id)
        {

            var response = await service.Ejecutar(id);
            if (response == null) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, response, "No existe el producto"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }

        [HttpGet("ConsultarStock")]
        public async Task<IActionResult> ConsultarStock(
           [FromServices] IBuscarStockConsulta service,
           [FromQuery] Guid id)
        {

            var response = await service.Ejecutar(id);
            if (response == null ) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, response, "No existe stock"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }

        [HttpGet("ProductosTransacciones")]
        public async Task<IActionResult> ProductosTransacciones(
               [FromServices] IListarProductosTransaccionesConsulta service)
        {

            var response = await service.Ejecutar();
            if (response == null) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, response, "No existen productos"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }


        [HttpGet("BuscarEditar")]
        public async Task<IActionResult> BuscarEditar(
               [FromServices] IBuscarProductoEditarPorIdConsulta service,
               Guid id)
        {

            var response = await service.Ejecutar(id);
            if (response == null) return Ok(RespuestaApiServicio.Response(
                    StatusCodes.Status200OK, response, "No existe el producto"));

            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));
        }



    }
}
