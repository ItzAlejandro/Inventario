using InventarioTransacciones.Aplicacion.External;
using InventarioTransacciones.Exterior.Servicio;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioTransacciones.Exterior
{
    public static class InyeccionDeDependenciasExterior
    {
        public static IServiceCollection AgregarExterior(this IServiceCollection services)
        {

            services.AddHttpClient<IProductoService, ProductoServiceMicroservicio>();

            return services;
        }
    }
}
