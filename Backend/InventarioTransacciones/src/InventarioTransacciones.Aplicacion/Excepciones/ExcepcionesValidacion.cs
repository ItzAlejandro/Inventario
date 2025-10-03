
using FluentValidation.Results;

namespace InventarioTransacciones.Aplicacion.Excepciones
{
    public class ExcepcionesValidacion : Exception
    {
        public List<string> ErroresDeValidacion { get; set; } = [];
        public ExcepcionesValidacion(ValidationResult validationResult)
        {
            foreach (var errorDeValidacion in validationResult.Errors)
            {
                ErroresDeValidacion.Add(errorDeValidacion.ErrorMessage);
            }
        }
    }
}
