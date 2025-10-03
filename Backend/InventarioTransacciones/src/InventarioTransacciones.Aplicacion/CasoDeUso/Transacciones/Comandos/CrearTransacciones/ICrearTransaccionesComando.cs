namespace InventarioTransacciones.Aplicacion.CasoDeUso.Transacciones.Comandos.CrearTransacciones
{
    public interface ICrearTransaccionesComando
    {
        Task<Guid> Hadle(CrearTransaccionesModelo crearProductoModelo);
    }
}
