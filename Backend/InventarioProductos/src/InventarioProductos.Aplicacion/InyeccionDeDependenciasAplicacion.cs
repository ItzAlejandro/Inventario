using FluentValidation;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.ActualizarStock;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.CrearProducto;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EditarProducto;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.EliminarProducto;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoEditarPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarStock;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductos;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioProductos.Aplicacion
{
    public static class InyeccionDeDependenciasAplicacion
    {
        public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
        {
            services.AddTransient<ICrearProductoComando, CrearProductoComando>();
            services.AddTransient<IListarProductosConsulta, ListarProductosConsulta>();
            services.AddTransient<IBuscarProductoPorIdConsulta, BuscarProductoPorIdConsulta>();
            services.AddTransient<IEliminarProductoComando, EliminarProductoComando>();
            services.AddTransient<IBuscarProductoEditarPorIdConsulta, BuscarProductoEditarPorIdConsulta>();
            services.AddTransient<IEditarProductoComando, EditarProductoComando>();
            services.AddTransient<IListarProductosTransaccionesConsulta, ListarProductosTransaccionesConsulta>();
            services.AddTransient<IBuscarStockConsulta, BuscarStockConsulta>();
            services.AddTransient<IActualizarStockComando, ActualizarStockComando>();


            services.AddScoped<IValidator<CrearProductoModelo>, CrearProductoValidator>();



            return services;
        }

    }
}
