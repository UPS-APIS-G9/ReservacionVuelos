using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.DTOs
{
    public class ReservacionInfo
    {
        public string CodigoReserva { get; }
        public string NumeroIdentificacion { get; }
        public string TipoIdentificacion { get; }
        public string PaisEmision { get; }
        public string Nombres { get; }
        public string Apellidos { get; }
        public string Correo { get; }
        public string CategoriaAsiento { get; }
        public string NumeroVuelo { get; }
        public string AlcanceVuelo { get; }
        public string AeropuertoOrigen { get; }
        public string AeropuertoDestino { get; }
        public DateTime FechaHoraVuelo { get; }

        public ReservacionInfo(string linea)
        {
            var partes = linea.Split("|");

            CodigoReserva = partes[0];
            NumeroIdentificacion = partes[1];
            TipoIdentificacion = partes[2];
            PaisEmision = partes[3];
            Nombres = partes[4];
            Apellidos = partes[5];
            Correo = partes[6];
            CategoriaAsiento = partes[7];
            NumeroVuelo = partes[8];
            AlcanceVuelo = partes[9];
            AeropuertoOrigen = partes[10];
            AeropuertoDestino = partes[11];
            FechaHoraVuelo = partes[12].ToFormatedDateTime();
        }
    }

    public class AsientoReservaInfo
    {
        public string CodigoReserva { get; }
        public string CodigoAsiento { get; }
        public DateTime FechaReservado { get; }

        public AsientoReservaInfo(string linea)
        {
            var partes = linea.Split("|");

            CodigoReserva = partes[0];
            CodigoAsiento = partes[1];
            FechaReservado = DateTime.Parse(partes[2]);
        }
    }
}
