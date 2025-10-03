namespace InventarioProductos.Aplicacion.Servicios
{
    public class ListadoPaginado<T>
    {
        public int cantidadTotal { get; set; }
        public IEnumerable<T> elemento { get; set; }
        public ListadoPaginado()
        {
            elemento = new List<T>();
            cantidadTotal = 0;
        }
    }
}
