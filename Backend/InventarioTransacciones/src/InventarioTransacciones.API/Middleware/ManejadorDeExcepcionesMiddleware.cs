using InventarioTransacciones.Aplicacion.Excepciones;
using System.Net;
using System.Text.Json;

namespace InventarioTransacciones.API.Middleware
{
    public class ManejadorDeExcepcionesMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ManejadorDeExcepcionesMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await ManejarExcepciones(context, ex);

            }
        }

        private Task ManejarExcepciones(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            var respuesta = new
            {
                StatusCode = (int)httpStatusCode,
                Success = false,
                Message = string.Empty
            };

            switch (exception)
            {
                case ExcepcionesValidacion excepcionesValidacion:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    respuesta = new
                    {
                        StatusCode = (int)httpStatusCode,
                        Success = false,
                        Message = excepcionesValidacion.ErroresDeValidacion.First()
                    };
                    break;
            }
            httpContext.Response.StatusCode = (int)httpStatusCode;
            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(respuesta));
        }


    }
    public static class ManejadorDeExcepcionesMiddlewareExtensions
    {
        public static IApplicationBuilder UseManejadorExceptiones(this IApplicationBuilder app)
        {

            return app.UseMiddleware<ManejadorDeExcepcionesMiddleware>();
        }
    }

}
