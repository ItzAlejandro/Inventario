namespace InventarioProductos.Dominio.Entidades
{
    public class ProductoEntidad
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string? Descripcion { get; private set; }
        public string Categoria { get; private set; } = null!;
        public string? Imagen { get; private set; }
        public DateTime FechaCreacion{ get; private set; } = DateTime.UtcNow;
        public DateTime FechaModificacion{ get; private set; } = DateTime.UtcNow;
        public bool Activo { get; private set; } = true;
        public DateTime? FechaEliminacion{ get; private set; }
        public decimal Precio { get;private set; } 
        public int Stock { get; private set; }

        public ProductoEntidad(string nombre, string categoria, decimal precio, int stock, string? descripcion = null, string? imagen = null)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
            Descripcion = descripcion;
            Imagen = imagen;
            FechaCreacion = DateTime.UtcNow;
            FechaModificacion = DateTime.UtcNow;
            Activo = true;
        }
        public void Eliminar()
        {
            if (!Activo)
                return;

            Activo = false;
            FechaEliminacion = DateTime.UtcNow;
            FechaModificacion = DateTime.UtcNow;
        }

        public void Editar(Guid id, string nombre, string categoria, decimal precio, int stock, string? descripcion = null, string? imagen = null)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
            Descripcion = descripcion;
            Imagen = imagen;
            FechaModificacion = DateTime.UtcNow;
            Activo = true;
        }
        public void AjustarStock(int cantidad, bool tipoTransaccion)
        {
            if (tipoTransaccion)
            {
                Stock += cantidad;
            }
            else
            {
                if (cantidad > Stock)
                    throw new Exception("No hay suficiente stock disponible.");

                Stock -= cantidad;
            }
        }
    }
}
