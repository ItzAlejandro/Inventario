namespace InventarioProductos.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> ObtenerPorId(Guid id);
        IQueryable<T> ObtenerTodos();
        Task<T> Crear(T entidad);
        Task Actualizar(T entidad);
        Task Eliminar(T entidad);
    }
}
