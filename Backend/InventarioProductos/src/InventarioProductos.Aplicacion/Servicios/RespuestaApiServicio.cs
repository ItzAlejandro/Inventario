using InventarioProductos.Dominio.Modelos;

namespace InventarioProductos.Aplicacion.Servicios
{
    public class RespuestaApiServicio
    {
        public static RespuestaBaseModelo Response(
           int statusCode, object data = null, string message = null)
        {
            return new RespuestaBaseModelo()
            {
                StatusCode = statusCode,
                Success = statusCode >= 200 && statusCode < 300,
                Data = data,
                Message = message
            };
        }
    }
}
