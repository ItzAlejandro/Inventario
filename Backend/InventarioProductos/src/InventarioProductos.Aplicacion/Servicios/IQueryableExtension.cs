namespace InventarioProductos.Aplicacion.Servicios
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable,
            FiltroPaginadoModel paginacion)
        {
            return queryable.Skip((paginacion.Pagina - 1) * paginacion.Cantidad)
                .Take(paginacion.Cantidad);
        }
    }
}
