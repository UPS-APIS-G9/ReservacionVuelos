using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public interface IResumenService
    {
        void GenerarResumenPorFecha(List<Reservacion> reservaciones);
        void GenerarResumenPorUsuario(List<Reservacion> reservaciones, string email, Asiento AsientoSeleccionado);
    }
}
