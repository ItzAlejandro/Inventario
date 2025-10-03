using InventarioTransacciones.Aplicacion.External;
using InventarioTransacciones.Aplicacion.External.DTO;
using InventarioTransacciones.Domain.Modelos;
using Newtonsoft.Json;
using System.Reflection;

namespace InventarioTransacciones.Exterior.Servicio
{
    public class ProductoServiceMicroservicio : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoServiceMicroservicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BuscarStockModelo> ObtenerProductoPorIdAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7063/api/v1/producto/ConsultarStock?id={id}");

                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var responseServicio =  JsonConvert.DeserializeObject<RespuestaBaseModelExterior<BuscarStockModelo>>(json);
                return responseServicio.Data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> ActualizarStock(ActualizarStockModel modelo)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(modelo),System.Text.Encoding.UTF8,
                            "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7063/api/v1/producto/ActualizarStock",jsonContent);

                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var responseServicio = JsonConvert.DeserializeObject<RespuestaBaseModelExterior<bool>>(json);
                return responseServicio?.Data ?? false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
