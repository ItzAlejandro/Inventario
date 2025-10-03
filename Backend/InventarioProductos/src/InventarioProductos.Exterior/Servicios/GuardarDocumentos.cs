using InventarioProductos.Aplicacion.Exterior.Servicios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace InventarioProductos.Exterior.Servicios
{
    public class GuardarDocumentos : IGuardarDocumentos
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly string _outputDirectory;
        public GuardarDocumentos(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IWebHostEnvironment env)
        {
            _outputDirectory = env.WebRootPath;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public async Task<string> Guardar(string container, IFormFile file, Guid id)
        {
            string physicalBasePath = _outputDirectory;
            var extension = Path.GetExtension(file.FileName);
            var nombreArchivo = $"{id}{extension}";
            string folder = Path.Combine(physicalBasePath, container);
            if (!Directory.Exists(container))
            {
                Directory.CreateDirectory(container);
            }
            string finalFileName = nombreArchivo;
            string finalFilePath = Path.Combine(folder, finalFileName);
            int i = 1;
            while (File.Exists(finalFilePath))
            {
                nombreArchivo = $"{id}_{i.ToString()}{extension}";
                finalFilePath = Path.Combine(folder, nombreArchivo);
                i++;
            }

            string ruta = Path.Combine(folder, nombreArchivo);
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var contenido = ms.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);


            }
            var request = _httpContextAccessor.HttpContext.Request;
            var url = $"{request.Scheme}://{request.Host}";
            var urlArchivo = Path.Combine(url, container, nombreArchivo).Replace("\\", "/");
            return nombreArchivo;
        }
    }
}
