namespace InventarioTransacciones.Aplicacion.External.DTO
{
    public class ActualizarStockModel
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public int Tipo { get; set; }
    }
}
