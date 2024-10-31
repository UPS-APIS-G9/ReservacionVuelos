using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;

namespace ReservacionVuelos.Services
{
    public class ReservacionService
    {
        public Pasajero CrearPasajero(ReservacionInfo info) =>
            new Pasajero.PasajeroBuilder()
        .SetNombres(info.Nombres)
        .SetApellidos(info.Apellidos)
        .SetPaisEmision(info.PaisEmision)
        .SetCorreo(info.Correo)
        .SetNumeroIdentificacion(info.NumeroIdentificacion)
        .SetTipoIdentificacion(info.TipoIdentificacion.Equals("PAS") ? TipoIdentificacion.PAS : TipoIdentificacion.NAC)
        .Build();

        public Vuelo CrearVuelo(ReservacionInfo info) =>
            new Vuelo.VueloBuilder()
                .SetNumeroVuelo(info.NumeroVuelo)
                .SetAeropuertoOrigen(info.AeropuertoOrigen)
                .SetAeropuertoDestino(info.AeropuertoDestino)
                .SetAlcance(info.AlcanceVuelo.Equals("I") ? AlcanceVuelo.I : AlcanceVuelo.N)
                .SetFechaHoraVuelo(info.FechaHoraVuelo)
                .Build();

        public Asiento CrearAsiento(ReservacionInfo info) =>
            new Asiento.AsientoBuilder()
                .SetCodigoReserva(info.CodigoReserva)
                .SetCategoria(info.CategoriaAsiento)
                .Build();

        public Asiento ActualizarAsiento(Reservacion info, bool reservado) =>
            new Asiento.AsientoBuilder()
                .SetCodigoReserva(info.CodigoReserva)
                .SetCategoria(info.AsientoSeleccionado.Categoria)
                .SetReservado(reservado)
                .Build();

        public Reservacion CrearReservacion(Asiento asiento, Vuelo vuelo, Pasajero pasajero) =>
            new Reservacion.ReservacionBuilder()
                    .SetCodigoReserva(asiento.CodigoReserva)
                    .SetAsientoSeleccionado(asiento)
                    .SetVuelo(vuelo)
                    .SetPasajero(pasajero)
                    .Build();
    }
}
