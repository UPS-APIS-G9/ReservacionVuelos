using ReservacionVuelos.Enums;

namespace ReservacionVuelos.Entities
{
    public class Pasajero
    {
        public string NumeroIdentificacion { get; private set; }
        public TipoIdentificacion TipoIdentificacion { get; private set; }
        public string PaisEmision { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public string Correo { get; private set; }

        private Pasajero() { }

        public class PasajeroBuilder
        {
            private readonly Pasajero pasajero;

            public PasajeroBuilder()
            {
                pasajero = new Pasajero();
            }

            public PasajeroBuilder SetNumeroIdentificacion(string numeroIdentificacion)
            {
                pasajero.NumeroIdentificacion = numeroIdentificacion;
                return this;
            }

            public PasajeroBuilder SetTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
            {
                pasajero.TipoIdentificacion = tipoIdentificacion;
                return this;
            }

            public PasajeroBuilder SetPaisEmision(string paisEmision)
            {
                pasajero.PaisEmision = paisEmision;
                return this;
            }

            public PasajeroBuilder SetNombres(string nombres)
            {
                pasajero.Nombres = nombres;
                return this;
            }

            public PasajeroBuilder SetApellidos(string apellidos)
            {
                pasajero.Apellidos = apellidos;
                return this;
            }

            public PasajeroBuilder SetCorreo(string correo)
            {
                pasajero.Correo = correo;
                return this;
            }

            public Pasajero Build()
            {
                return pasajero;
            }
        }
    }

}
