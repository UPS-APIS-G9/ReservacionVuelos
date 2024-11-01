using ReservacionVuelos.Entities;

namespace ReservacionVuelos.DTOs
{
    public class ReservaContext
    {
        public string? Email { get; set; }
        public string? CodigoAsiento { get; set; }
        public Asiento? AsientoSeleccionado { get; set; }
        public string? CodigoReservaSeleccionada { get; set; }
        public DateTime? FechaHoraLocal { get; set; }
        public bool IsAdmin => Email == "admin@airline.com";
        public List<Reservacion> Reservaciones { get; set; } = new();
        public List<Asiento> AsientosDisponibles { get; set; } = new();

        public string ClasePasajero { get; set; } = string.Empty;

        public Vuelo? VueloSeleccionado { get; set; }

        public bool PuedeSeleccionarAsiento(string claseAsiento)
        {
            if (ClasePasajero == "P")
            {
                return claseAsiento == "P";
            }
            else
            {
                return claseAsiento != "P";
            }
        }

        // Método para verificar si ya existe una selección de asiento en el mismo vuelo
        public bool TieneAsientoEnVuelo()
        {
            return Reservaciones.Any(reserva =>
                reserva.Vuelo.NumeroVuelo == VueloSeleccionado?.NumeroVuelo && reserva.AsientoSeleccionado != null);
        }
    }
}
