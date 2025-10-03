using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoEditarPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarProductoPorId;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.BuscarStock;
using InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones;
using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InventariosProductos.Persistencia.Repositorios
{
    public class RepositoriosProductos : Repositorio<ProductoEntidad>, IRepositorioProductos
    {
        private readonly InventariosProductosDBContext _inventariosProductosDBContext;
        private readonly IConfiguration _configuration;

        public RepositoriosProductos(InventariosProductosDBContext inventariosProductosDBContext,
            IConfiguration configuration) : base(inventariosProductosDBContext)
        {
            _inventariosProductosDBContext = inventariosProductosDBContext;
            _configuration = configuration;

        }

        public async Task<BuscarProductoPorIdModelo> BuscarPorIdModel(Guid id)
            => await _inventariosProductosDBContext.Productos.Where(
                x => x.Id == id && x.Activo).Select(
                x => new BuscarProductoPorIdModelo
                {
                    Categoria = x.Categoria,
                    Descripcion = x.Descripcion,
                    FechaCreacion = x.FechaCreacion,
                    Imagen = x.Imagen,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Stock = x.Stock,
                }).FirstOrDefaultAsync();

        public async Task<BuscarProductoEditarPorIdModelo> BuscarProductoEditar(Guid id) {
            string url = _configuration["PublicImagesPath"];
            var resultado = await _inventariosProductosDBContext.Productos.Where(
                x => x.Id == id && x.Activo).Select(
                x => new BuscarProductoEditarPorIdModelo
                {
                    Id = x.Id,
                    Categoria = x.Categoria,
                    Descripcion = x.Descripcion,
                    Imagen = !string.IsNullOrEmpty(x.Imagen) ? $"{url}{x.Imagen}" : null,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Stock = x.Stock
                }).FirstOrDefaultAsync();
            return resultado;
        }

        public async Task<List<ListarProductosTransaccionesModelo>> BuscarProductoTransacciones()
        => await _inventariosProductosDBContext.Productos.Where(x => x.Activo).Select(x => new ListarProductosTransaccionesModelo
        {
            Id = x.Id,
            Nombre = x.Nombre,
            Precio = x.Precio,
            Stock = x.Stock,
        }).ToListAsync();

        public async Task<BuscarStockModelo> GetStock(Guid id)
                => await _inventariosProductosDBContext.Productos.Where(x => x.Id == id && x.Activo).Select(x =>
                 new BuscarStockModelo {
                     id = x.Id,
                     Stock = x.Stock
                 }).FirstOrDefaultAsync();
    }
}
