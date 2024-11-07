using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.Services
{
    public class VueloService : IVueloService
    {
        public VueloService() {}

        public Vuelo CrearVuelo(ReservacionInfo info) =>
            new Vuelo.VueloBuilder()
                .SetNumeroVuelo(info.NumeroVuelo)
                .SetAeropuertoOrigen(info.AeropuertoOrigen)
                .SetAeropuertoDestino(info.AeropuertoDestino)
                .SetAlcance(info.AlcanceVuelo.Equals("I") ? AlcanceVuelo.I : AlcanceVuelo.N)
                .SetFechaHoraVuelo(info.FechaHoraVuelo.ToFormatedDateTime())
                .Build();
    }
}
