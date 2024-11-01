namespace ReservacionVuelos.Entities
{
    public class Asiento
    {
        public string CodigoReserva { get; private set; }
        public string CodigoAsiento { get; private set; }
        public string Categoria { get; private set; }
        public bool EsVentana { get; private set; } = false;
        public bool EsPasillo { get; private set; } = false;
        public bool Reservado { get; private set; } = false;

        private Asiento() { }

        public class AsientoBuilder
        {
            private readonly Asiento asiento;

            public AsientoBuilder()
            {
                asiento = new Asiento();
            }

            public AsientoBuilder SetCodigoReserva(string codigoReserva)
            {
                asiento.CodigoReserva = codigoReserva;
                return this;
            }

            public AsientoBuilder SetCodigoAsiento(string codigoAsiento)
            {
                asiento.CodigoAsiento = codigoAsiento;
                return this;
            }

            public AsientoBuilder SetCategoria(string categoria)
            {
                asiento.Categoria = categoria;
                return this;
            }

            public AsientoBuilder SetEsVentana(bool esVentana)
            {
                asiento.EsVentana = esVentana;
                return this;
            }

            public AsientoBuilder SetEsPasillo(bool esPasillo)
            {
                asiento.EsPasillo = esPasillo;
                return this;
            }

            public AsientoBuilder SetReservado(bool reservado)
            {
                asiento.Reservado = reservado;
                return this;
            }

            public Asiento Build()
            {
                return asiento;
            }
        }
    }


}
