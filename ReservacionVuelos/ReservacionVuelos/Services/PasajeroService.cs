using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;

namespace ReservacionVuelos.Services
{
    public class PasajeroService : IPasajeroService
    {
        public PasajeroService() {}

        public Pasajero CrearPasajero(ReservacionInfo info) =>
        new Pasajero.PasajeroBuilder()
                .SetNombres(info.Nombres)
                .SetApellidos(info.Apellidos)
                .SetPaisEmision(info.PaisEmision)
                .SetCorreo(info.Correo)
                .SetNumeroIdentificacion(info.NumeroIdentificacion)
                .SetTipoIdentificacion(info.TipoIdentificacion.Equals("PAS") ? TipoIdentificacion.PAS : TipoIdentificacion.NAC)
                .Build();
    }
}
