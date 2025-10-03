using InventarioTransacciones.Aplicacion.Contratos.Repositorios;
using InventarioTransacciones.Domain.Entidades;
using Microsoft.Extensions.Configuration;

namespace InventarioTransaccione.Persistencia.Repositorios
{
    public class RepositoriosTransacciones : Repositorio<TransaccionEntidad>, IRepositorioTransacciones
    {
        private readonly InventarioTransaccioneDBContext _inventarioTransaccioneDBContext;
        private readonly IConfiguration _configuration;
        public RepositoriosTransacciones(InventarioTransaccioneDBContext inventarioTransaccioneDBContext,
            IConfiguration configuration) : base(inventarioTransaccioneDBContext)
        {
            _inventarioTransaccioneDBContext = inventarioTransaccioneDBContext;
            _configuration = configuration;
        }
    }
}
