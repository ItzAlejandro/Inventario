﻿namespace InventarioTransacciones.Exterior.Servicio
{
    public class RespuestaBaseModelExterior<T>
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
