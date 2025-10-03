using InventarioProductos.Aplicacion.Servicios;

namespace InventarioProductos.Aplicacion.CasosDeUso.Producto.Consultas.ListarProductos
{
    public interface IListarProductosConsulta
    {
        Task<ListadoPaginado<ListarProductosModelo>> Ejecutar(FiltroPaginadoModel filtro);

    }
}
