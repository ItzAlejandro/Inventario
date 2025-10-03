using InventarioTransacciones.Aplicacion.CasoDeUso.Transacciones.Comandos.CrearTransacciones;
using InventarioTransacciones.Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace InventarioTransacciones.API.Controllers
{
    [Route("api/v1/transaccion")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CrearTransaccion(
           [FromServices] ICrearTransaccionesComando service,
           [FromBody] CrearTransaccionesModelo model
           )
        {

            var response = await service.Hadle(model);
            if (response == Guid.Empty) return BadRequest(RespuestaApiServicio.Response(
                StatusCodes.Status400BadRequest, response, "Existio un error al realizar la transacción"));


            return Ok(RespuestaApiServicio.Response(StatusCodes.Status200OK, response));

        }
    }
}
