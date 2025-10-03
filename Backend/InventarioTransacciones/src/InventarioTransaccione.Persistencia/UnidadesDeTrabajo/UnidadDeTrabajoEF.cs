using InventarioTransacciones.Aplicacion.Persistencia;

namespace InventarioTransaccione.Persistencia.UnidadesDeTrabajo
{
    public class UnidadDeTrabajoEF : IUnidadDeTrabajo
    {
        private readonly InventarioTransaccioneDBContext _inventarioTransaccioneDBContext;

        public UnidadDeTrabajoEF(InventarioTransaccioneDBContext inventarioTransaccioneDBContext)
        {
            _inventarioTransaccioneDBContext = inventarioTransaccioneDBContext;
        }
        public async Task Persistir()
        {
            await _inventarioTransaccioneDBContext.SaveChangesAsync();
        }

        public Task Reversar()
        {
            return Task.CompletedTask;
        }
    }
}
