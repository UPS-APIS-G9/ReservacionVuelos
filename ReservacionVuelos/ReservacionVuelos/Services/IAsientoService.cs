using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    public interface IAsientoService : IAsientoValidations
    {
        List<Asiento> GenerarAsientosDisponibles(List<Reservacion> reservaciones);
        List<Reservacion> GenerarAsientosOcupados(List<Reservacion> reservaciones);        
        string ObtenerClasePorFila(int fila);
        Asiento CrearAsiento(ReservacionInfo info);
        Asiento ActualizarAsiento(Reservacion info, string codigoAsiento, bool reservado);
        Asiento ActualizarAsientoReservado(string codigoReserva, Asiento asiento);

    }
}
