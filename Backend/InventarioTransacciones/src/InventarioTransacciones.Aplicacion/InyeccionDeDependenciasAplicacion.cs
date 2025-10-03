using FluentValidation;
using InventarioTransacciones.Aplicacion.CasoDeUso.Transacciones.Comandos.CrearTransacciones;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioTransacciones.Aplicacion
{
    public static class InyeccionDeDependenciasAplicacion
    {
        public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
        {


            services.AddScoped<IValidator<CrearTransaccionesModelo>, CrearTransaccionesValidacion>();
            services.AddTransient<ICrearTransaccionesComando, CrearTransaccionesComando>();


            return services;
        }
    }
}
