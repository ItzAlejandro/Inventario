using InventarioProductos.Aplicacion.Persistencia;

namespace InventariosProductos.Persistencia.UnidadesDeTrabajo
{
    public class UnidadDeTrabajoEF : IUnidadDeTrabajo
    {
        private readonly InventariosProductosDBContext _inventariosProductosDBContext;

        public UnidadDeTrabajoEF(InventariosProductosDBContext inventariosProductosDBContext)
        {
            _inventariosProductosDBContext = inventariosProductosDBContext;
        }
        public async Task Persistir()
        {
            await _inventariosProductosDBContext.SaveChangesAsync();
        }

        public Task Reversar()
        {
            return Task.CompletedTask;
        }
    }
}
