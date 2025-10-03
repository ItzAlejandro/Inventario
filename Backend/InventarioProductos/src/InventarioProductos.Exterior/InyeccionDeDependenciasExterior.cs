using Microsoft.Extensions.DependencyInjection;
using InventarioProductos.Exterior.Servicios;
using InventarioProductos.Aplicacion.Exterior.Servicios;
using Microsoft.Extensions.Configuration;

namespace InventarioProductos.Exterior
{
    public static class InyeccionDeDependenciasExterior
    {
        public static IServiceCollection AgregarExterior(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddTransient<IGuardarDocumentos, GuardarDocumentos>();

            return services;
        }
    }
}
