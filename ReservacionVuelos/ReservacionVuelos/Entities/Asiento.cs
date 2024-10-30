namespace ReservacionVuelos.Entities
{
    public class Asiento
    {
        public string Fila { get; private set; }
        public string Columna { get; private set; }
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

            public AsientoBuilder SetFila(string fila)
            {
                asiento.Fila = fila;
                return this;
            }

            public AsientoBuilder SetColumna(string columna)
            {
                asiento.Columna = columna;
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
