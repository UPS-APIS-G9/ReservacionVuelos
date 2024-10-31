namespace ReservacionVuelos.Entities
{
    public class Asiento
    {
        public string CodigoReserva { get; private set; }
        public string CodigoAsiento { get; private set; }
        public string Categoria { get; private set; }
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
