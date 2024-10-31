using ReservacionVuelos.Entities;

namespace ReservacionVuelos.DTOs
{
    public class ReservaContext
    {
        public string? Email { get; set; }
        public string? CodigoAsiento { get; set; }
        public Asiento? AsientoSeleccionado { get; set; }

        public DateTime? FechaHoraLocal { get; set; }
        public bool IsAdmin => Email == "admin@airline.com";

        public List<Reservacion>? Reservaciones { get; set; } = new();
        public List<Reservacion>? AsientosReservados { get; set; } = new();
    }
}
