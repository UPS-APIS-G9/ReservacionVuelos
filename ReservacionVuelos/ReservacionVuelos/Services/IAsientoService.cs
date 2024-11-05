using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    public interface IAsientoService
    {
        List<Asiento> GenerarAsientosDisponibles(List<Reservacion> reservaciones);
        List<Reservacion> GenerarAsientosOcupados(List<Reservacion> reservaciones);
        bool PuedeSeleccionarAsiento(DateTime fechaHoraVuelo, bool esNacional);
        string ObtenerClasePorFila(int fila);
        bool EsAsientoValido(string clase, int fila, string columna, List<Asiento> asientosSeleccionados);
        bool EsAsientoPermitidoParaClasePasajero(string clasePasajero, string claseAsiento);
        Asiento CrearAsiento(ReservacionInfo info);
        Asiento ActualizarAsiento(Reservacion info, string codigoAsiento, bool reservado);
        Asiento ActualizarAsientoReservado(string codigoReserva, Asiento asiento);

    }
}
