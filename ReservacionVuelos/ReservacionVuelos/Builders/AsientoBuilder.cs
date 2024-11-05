using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Builders
{
    public class AsientoBuilder : IAsientoBuilder
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
