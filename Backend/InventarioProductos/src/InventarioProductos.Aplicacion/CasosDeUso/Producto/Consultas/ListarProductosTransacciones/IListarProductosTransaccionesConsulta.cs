namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductosTransacciones
{
    public interface IListarProductosTransaccionesConsulta
    {
        Task<List<ListarProductosTransaccionesModelo>> Ejecutar();
    }
}
