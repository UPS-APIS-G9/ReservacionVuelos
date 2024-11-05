using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReservacionVuelos.Entities.Vuelo;

namespace ReservacionVuelos.Builders
{
    public interface IVueloBuilder
    {
        VueloBuilder SetAeropuertoOrigen(string aeropuertoOrigen);
        VueloBuilder SetAeropuertoDestino(string aeropuertoDestino);
        VueloBuilder SetAlcance(AlcanceVuelo alcance);
        VueloBuilder SetNumeroVuelo(string numeroVuelo);
        VueloBuilder SetFechaHoraVuelo(DateTime fechaHoraVuelo);
        Vuelo Build();
    }
}
