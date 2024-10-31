namespace ReservacionVuelos.Entities
{
    public class Reservacion
    {
        public string CodigoReserva { get; private set; }
        public Pasajero Pasajero { get; private set; }
        public Vuelo Vuelo { get; private set; }
        public Asiento AsientoSeleccionado { get; private set; }
        public DateTime FechaReserva { get; private set; }

        private Reservacion() { }

        public class ReservacionBuilder
        {
            private readonly Reservacion reservacion;

            public ReservacionBuilder()
            {
                reservacion = new Reservacion();
            }

            public ReservacionBuilder SetCodigoReserva(string codigoReserva)
            {
                reservacion.CodigoReserva = codigoReserva;
                return this;
            }

            public ReservacionBuilder SetPasajero(Pasajero pasajero)
            {
                reservacion.Pasajero = pasajero;
                return this;
            }

            public ReservacionBuilder SetVuelo(Vuelo vuelo)
            {
                reservacion.Vuelo = vuelo;
                return this;
            }

            public ReservacionBuilder SetAsientoSeleccionado(Asiento asiento)
            {
                reservacion.AsientoSeleccionado = asiento;
                return this;
            }

            public ReservacionBuilder SetFechaReserva(DateTime fechaReserva)
            {
                reservacion.FechaReserva = fechaReserva;
                return this;
            }

            public Reservacion Build()
            {
                return reservacion;
            }
        }

        public override string ToString()
        {
            return $"{CodigoReserva}|{Pasajero.NumeroIdentificacion}|{Pasajero.TipoIdentificacion}|{Pasajero.PaisEmision}|{Pasajero.Nombres}|{Pasajero.Apellidos}|{Pasajero.Correo}|{AsientoSeleccionado.Categoria}|{Vuelo.NumeroVuelo}|{Vuelo.Alcance}|{Vuelo.AeropuertoOrigen}|{Vuelo.AeropuertoDestino}|{Vuelo.FechaHoraVuelo}";
        }
    }

}
