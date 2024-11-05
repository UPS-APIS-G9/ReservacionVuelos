using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Builders
{
    public interface IAsientoBuilder
    {

        AsientoBuilder SetCodigoReserva(string codigoReserva);
        AsientoBuilder SetCodigoAsiento(string codigoAsiento);
        AsientoBuilder SetCategoria(string categoria);
        AsientoBuilder SetEsVentana(bool esVentana);
        AsientoBuilder SetEsPasillo(bool esPasillo);
        AsientoBuilder SetReservado(bool reservado);
        Asiento Build();

    }
}
