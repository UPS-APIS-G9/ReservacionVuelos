using ReservacionVuelos.Entities;

namespace ReservacionVuelos.DTOs
{
    public class ReservaContext
    {
        public string? Email { get; set; }
        public Asiento? AsientoSeleccionado { get; set; }
        public DateTime? FechaHoraLocal { get; set; }
        public bool IsAdmin => Email == "admin@airline.com";
        public List<Reservacion> Reservaciones { get; set; } = new();
        public List<Asiento> AsientosDisponibles { get; set; } = new();

        public bool EsAsientoPermitidoParaClasePasajero(string clasePasajero, string claseAsiento)
        {
            if (clasePasajero == "P")
            {
                return claseAsiento == "P" || claseAsiento == "Y";
            }
            else
            {
                return claseAsiento != "P";
            }
        }
    }
}
