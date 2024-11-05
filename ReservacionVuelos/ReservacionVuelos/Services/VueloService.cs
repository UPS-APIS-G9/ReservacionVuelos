using ReservacionVuelos.Builders;
using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using ReservacionVuelos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    public class VueloService : IVueloService
    {
        public VueloService() {}

        public Vuelo CrearVuelo(ReservacionInfo info)
        {
            IVueloBuilder vueloBuilder = new VueloBuilder();
            return vueloBuilder
                .SetNumeroVuelo(info.NumeroVuelo)
                .SetAeropuertoOrigen(info.AeropuertoOrigen)
                .SetAeropuertoDestino(info.AeropuertoDestino)
                .SetAlcance(info.AlcanceVuelo.Equals("I") ? AlcanceVuelo.I : AlcanceVuelo.N)
                .SetFechaHoraVuelo(info.FechaHoraVuelo.ToFormatedDateTime())
                .Build();
        }
    }
}
