using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Aplicacion.Persistencia;
using InventariosProductos.Persistencia.Repositorios;
using InventariosProductos.Persistencia.UnidadesDeTrabajo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventariosProductos.Persistencia
{
    public static class InyeccionDeDependenciasPersistencia
    {
        public static IServiceCollection AgregarPersistencia(this IServiceCollection services)
        {
            services.AddDbContext<InventariosProductosDBContext>(options =>
            options.UseSqlServer("name=InventariosProductosConnectionString"));

            services.AddScoped<IRepositorioProductos, RepositoriosProductos>();
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajoEF>();

            return services;
        }
    }
}
