using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public interface IPasajeroService
    {
        Pasajero CrearPasajero(ReservacionInfo info);
    }
}
