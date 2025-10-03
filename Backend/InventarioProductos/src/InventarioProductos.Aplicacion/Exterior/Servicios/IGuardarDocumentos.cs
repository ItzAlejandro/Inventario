using Microsoft.AspNetCore.Http;

namespace InventarioProductos.Aplicacion.Exterior.Servicios
{
    public interface IGuardarDocumentos
    {
       Task<string> Guardar(string container, IFormFile file, Guid act_id);
    }
}
