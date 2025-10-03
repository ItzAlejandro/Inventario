using InventarioTransacciones.Aplicacion.Contratos.Repositorios;

namespace InventarioTransaccione.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly InventarioTransaccioneDBContext _inventarioTransaccioneDBContext;
        public Repositorio(InventarioTransaccioneDBContext inventarioTransaccioneDBContext)
        {
            _inventarioTransaccioneDBContext = inventarioTransaccioneDBContext;
        }

        public Task Actualizar(T entidad)
        {
            _inventarioTransaccioneDBContext.Update(entidad);
            return Task.CompletedTask;
        }

        public Task<T> Crear(T entidad)
        {
            _inventarioTransaccioneDBContext.Add(entidad);
            return Task.FromResult(entidad);
        }

        public Task Eliminar(T entidad)
        {

            _inventarioTransaccioneDBContext.Remove(entidad);
            return Task.CompletedTask;
        }

        public async Task<T?> ObtenerPorId(Guid id)
        {
            return await _inventarioTransaccioneDBContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> ObtenerTodos()
        {
            return _inventarioTransaccioneDBContext.Set<T>();

        }

    }
}
