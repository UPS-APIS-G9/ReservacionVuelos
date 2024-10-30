using ReservacionVuelos.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Entities
{
    public class Vuelo
    {
        public string AeropuertoOrigen { get; private set; }
        public string AeropuertoDestino { get; private set; }
        public AlcanceVuelo Alcance { get; private set; }
        public string NumeroVuelo { get; private set; }
        public DateTime FechaHoraVuelo { get; private set; }

        private Vuelo() { }

        public class VueloBuilder
        {
            private readonly Vuelo vuelo;

            public VueloBuilder()
            {
                vuelo = new Vuelo();
            }

            public VueloBuilder SetAeropuertoOrigen(string aeropuertoOrigen)
            {
                vuelo.AeropuertoOrigen = aeropuertoOrigen;
                return this;
            }

            public VueloBuilder SetAeropuertoDestino(string aeropuertoDestino)
            {
                vuelo.AeropuertoDestino = aeropuertoDestino;
                return this;
            }

            public VueloBuilder SetAlcance(AlcanceVuelo alcance)
            {
                vuelo.Alcance = alcance;
                return this;
            }

            public VueloBuilder SetNumeroVuelo(string numeroVuelo)
            {
                vuelo.NumeroVuelo = numeroVuelo;
                return this;
            }

            public VueloBuilder SetFechaHoraVuelo(DateTime fechaHoraVuelo)
            {
                vuelo.FechaHoraVuelo = fechaHoraVuelo;
                return this;
            }

            public Vuelo Build()
            {
                return vuelo;
            }
        }
    }

}
