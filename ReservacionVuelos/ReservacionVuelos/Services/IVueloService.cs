using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public interface IVueloService
    {
        Vuelo CrearVuelo(ReservacionInfo info);
    }
}
