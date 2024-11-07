using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Validations
{
    public interface IAsientoValidations
    {
        bool EsAsientoValido(string clase, int fila, string columna, List<Asiento> asientosSeleccionados);
        bool EsAsientoPermitidoParaClasePasajero(string clasePasajero, string claseAsiento);
        bool PuedeSeleccionarAsiento(DateTime fechaHoraVuelo, bool esNacional);
    }
}
