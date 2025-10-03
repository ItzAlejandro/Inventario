using InventarioProductos.Aplicacion.Contratos.Repositorios;
using InventarioProductos.Aplicacion.Servicios;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductos
{
    public class ListarProductosConsulta : IListarProductosConsulta
    {
        private readonly IRepositorioProductos _repositorioProductos;

        public ListarProductosConsulta(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public async Task<ListadoPaginado<ListarProductosModelo>> Ejecutar(FiltroPaginadoModel filtro)
        {
            var query = _repositorioProductos.ObtenerTodos();


            if (!string.IsNullOrWhiteSpace(filtro.TextoBusqueda))
            {
                var texto = filtro.TextoBusqueda.ToLower().Trim();
                query = query.Where(x => x.Nombre.Contains(texto)
                    || x.Descripcion.Contains(texto));
            }

            query = query.Where(x => x.Activo);

            var totalRegistros = query.Count();
            var listadoPaginado = query
                .OrderBy(q => q.FechaCreacion)
                .Paginar(filtro)
                .Select(x => new ListarProductosModelo
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Stock = x.Stock
                })
                .ToList();

            return new ListadoPaginado<ListarProductosModelo>
            {
                cantidadTotal = totalRegistros,
                elemento = listadoPaginado
            };
        }
    }
}
