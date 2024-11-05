using ReservacionVuelos.Enums;

namespace ReservacionVuelos.Entities
{
    public class Pasajero
    {
        public string NumeroIdentificacion { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        public string PaisEmision { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        public Pasajero() { }
        
    }

}
