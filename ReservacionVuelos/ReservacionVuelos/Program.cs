using ReservacionVuelos.Builders;
using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Handlers;
using ReservacionVuelos.Services;
using ReservacionVuelos.Utiles;

try
{
    LeerArchivoService.Instance.InitializeFileReservations("Files/reservations.txt");
    LeerArchivoService.Instance.InitializeFileSeatSelection("Files/seat-selection.txt");

    List<Reservacion> reservaciones = new();
    List<Asiento> asientosDisponibles = new();

    IVueloService vueloService = new VueloService();
    IPasajeroService pasajeroService = new PasajeroService();
    IAsientoService asientoService = new AsientoService();
    IResumenService resumenService = new ResumenService();

    List<string> contenidoReservaciones = LeerArchivoService.Instance.GetcontenidoReservaciones();
    List<string> contenidoSeleccionAsientos = LeerArchivoService.Instance.GetcontenidoSeleccionAsiento();

    foreach (var lineaReservacion in contenidoReservaciones)
    {
        var reservacionInfo = new ReservacionInfo(lineaReservacion);

        Pasajero pasajero = pasajeroService.CrearPasajero(reservacionInfo);
        Vuelo vuelo = vueloService.CrearVuelo(reservacionInfo);
        Asiento asiento = asientoService.CrearAsiento(reservacionInfo);

        Reservacion reservacion = new Reservacion.ReservacionBuilder()
            .SetCodigoReserva(reservacionInfo.CodigoReserva)
            .SetAsientoSeleccionado(asiento)
            .SetVuelo(vuelo)
            .SetPasajero(pasajero)
            .SetFechaReserva(reservacionInfo.FechaHoraVuelo.ToFormatedDateTime())
            .Build();

        reservaciones.Add(reservacion);
    }

    foreach (var codigoReserva in contenidoSeleccionAsientos)
    {
        var asientoReservaInfo = new AsientoReservaInfo(codigoReserva);

        var reservacion = reservaciones.FirstOrDefault(reserva => reserva.CodigoReserva == asientoReservaInfo.CodigoReserva);

        if (reservacion != null && reservacion.AsientoSeleccionado != null)
        {
            Asiento asientoActualizado = asientoService.ActualizarAsiento(reservacion, asientoReservaInfo.CodigoAsiento, true);

            Reservacion reservacionActualizada = new Reservacion.ReservacionBuilder()
                .SetCodigoReserva(reservacion.CodigoReserva)
                .SetPasajero(reservacion.Pasajero)
                .SetVuelo(reservacion.Vuelo)
                .SetAsientoSeleccionado(asientoActualizado)
                .Build();

            reservaciones.Remove(reservacion);
            reservaciones.Add(reservacionActualizada);
        }
    }

    var context = new ReservaContext
    {
        Reservaciones = reservaciones
    };

    context.AsientosDisponibles = asientoService.GenerarAsientosDisponibles(reservaciones);
    context.reservasConAsientoOcupado =  asientoService.GenerarAsientosOcupados(reservaciones);

    var emailHandler = new CorreoHandler(resumenService);
    var mostrarReservasHandler = new MostrarReservasHandler(asientoService);
    var seleccionAsientoHandler = new SeleccionAsientoHandler(asientoService);
    var validacionFechaHoraHandler = new ValidacionFechaHoraHandler();
    var guardarSeleccionHandler = new GuardarSeleccionHandler(resumenService);

    emailHandler.SetNext(mostrarReservasHandler);
    mostrarReservasHandler.SetNext(seleccionAsientoHandler);
    seleccionAsientoHandler.SetNext(validacionFechaHoraHandler);
    validacionFechaHoraHandler.SetNext(guardarSeleccionHandler);

    emailHandler.Handle(context);

    Console.WriteLine("Proceso completado exitosamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}


