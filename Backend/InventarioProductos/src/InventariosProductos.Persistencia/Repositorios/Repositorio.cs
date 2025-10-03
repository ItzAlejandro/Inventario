using InventarioProductos.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace InventariosProductos.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly InventariosProductosDBContext _inventariosProductosDBContext;

        public Repositorio(InventariosProductosDBContext inventariosProductosDBContext)
        {
            _inventariosProductosDBContext = inventariosProductosDBContext;
        }
        public Task Actualizar(T entidad)
        {
            _inventariosProductosDBContext.Update(entidad);
            return Task.CompletedTask;
        }

        public Task<T> Crear(T entidad)
        {
            _inventariosProductosDBContext.Add(entidad);
            return Task.FromResult(entidad);
        }

        public Task Eliminar(T entidad)
        {
            
            _inventariosProductosDBContext.Remove(entidad);
            return Task.CompletedTask;
        }

        public async Task<T?> ObtenerPorId(Guid id)
        {
            return await _inventariosProductosDBContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> ObtenerTodos()
        {
            return _inventariosProductosDBContext.Set<T>();

        }
    }
}
