using InventarioTransaccione.Persistencia.Repositorios;
using InventarioTransaccione.Persistencia.UnidadesDeTrabajo;
using InventarioTransacciones.Aplicacion.Contratos.Repositorios;
using InventarioTransacciones.Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioTransaccione.Persistencia
{
    public static class InyeccionDeDependenciasPersistencia
    {
        public static IServiceCollection AgregarPersistencia(this IServiceCollection services)
        {

            services.AddDbContext<InventarioTransaccioneDBContext>(options =>
            options.UseSqlServer("name=InventarioTransaccionesConnectionString"));

            services.AddScoped<IRepositorioTransacciones, RepositoriosTransacciones>();
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajoEF>();

            return services;
        }

    }
}
