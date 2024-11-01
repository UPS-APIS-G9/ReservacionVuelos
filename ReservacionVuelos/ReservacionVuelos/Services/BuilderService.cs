using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;

namespace ReservacionVuelos.Services
{
    public class BuilderService
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

        public Asiento CrearAsiento(string codigoAsiento, string categoria, bool esVentana, bool esPasillo) =>
         new Asiento.AsientoBuilder()
                .SetCodigoAsiento(codigoAsiento)
                .SetCategoria(categoria)
                .SetEsVentana(esVentana)
                .SetEsPasillo(esPasillo)
                .Build();

        public Asiento CrearAsientoReservado(Asiento asiento) =>
         new Asiento.AsientoBuilder()
                .SetCodigoReserva(asiento.CodigoReserva)
                .SetCategoria(asiento.Categoria)
                .SetEsVentana(asiento.EsVentana)
                .SetEsPasillo(asiento.EsPasillo)
                .SetReservado(true)
                .Build();

        public Asiento ActualizarAsientoReservado(string codigoReserva, Asiento asiento) =>
         new Asiento.AsientoBuilder()
                .SetCodigoAsiento(asiento.CodigoAsiento)
                .SetCodigoReserva(codigoReserva)
                .SetCategoria(asiento.Categoria)
                .SetEsVentana(asiento.EsVentana)
                .SetEsPasillo(asiento.EsPasillo)
                .SetReservado(true)
                .Build();

        public Asiento ActualizarAsiento(Reservacion info, string codigoAsiento, bool reservado) =>
            new Asiento.AsientoBuilder()
                .SetCodigoReserva(info.CodigoReserva)
                .SetCodigoAsiento(codigoAsiento)
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
