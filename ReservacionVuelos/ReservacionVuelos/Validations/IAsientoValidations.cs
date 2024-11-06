using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Validations
{
    public interface IAsientoValidations
    {
        bool EsAsientoValido(string clase, int fila, string columna, List<Asiento> asientosSeleccionados);
        bool EsAsientoPermitidoParaClasePasajero(string clasePasajero, string claseAsiento);
        bool PuedeSeleccionarAsiento(DateTime fechaHoraVuelo, bool esNacional);
    }
}
