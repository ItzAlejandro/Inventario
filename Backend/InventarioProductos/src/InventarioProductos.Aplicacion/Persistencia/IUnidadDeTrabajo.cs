namespace InventarioProductos.Aplicacion.Persistencia
{
    public interface IUnidadDeTrabajo
    {
        Task Persistir();
        Task Reversar();
    }
}
