﻿using Microsoft.AspNetCore.Http;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Comando.CrearProducto
{
    public class CrearProductoModelo
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public IFormFile?  Imagen {  get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

    }
}
