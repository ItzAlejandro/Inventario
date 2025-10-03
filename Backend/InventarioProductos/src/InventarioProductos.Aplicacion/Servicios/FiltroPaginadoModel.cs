namespace InventarioProductos.Aplicacion.Servicios
{
    public class FiltroPaginadoModel
    {
        public int Pagina { get; set; }
        public int Cantidad
        {
            get { return recordsPorPagina; }
            set
            {
                recordsPorPagina = (value > cantiMaximaRecordsPorPagina && value != 5000)
                    ? cantiMaximaRecordsPorPagina
                    : value;
            }
        }
        public string? TextoBusqueda { get; set; }
        private int recordsPorPagina = 10;
        private readonly int cantiMaximaRecordsPorPagina = 50;
    }
}
