using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Handlers;
using ReservacionVuelos.Services;

try
{
    LeerArchivo.Instance.InitializeFileReservations("Files/reservations.txt");
    LeerArchivo.Instance.InitializeFileSeatSelection("Files/seat-selection.txt");

    List<string> contenidoReservaciones = LeerArchivo.Instance.GetcontenidoReservaciones();
    List<string> contenidoSeleccionAsientos = LeerArchivo.Instance.GetcontenidoSeleccionAsiento();

    List<Reservacion> reservaciones = new();
    ReservacionService reservacionService = new();

    foreach (var lineaReservacion in contenidoReservaciones)
    {
        var reservacionInfo = new ReservacionInfo(lineaReservacion);

        Pasajero pasajero = reservacionService.CrearPasajero(reservacionInfo);
        Vuelo vuelo = reservacionService.CrearVuelo(reservacionInfo);
        Asiento asiento = reservacionService.CrearAsiento(reservacionInfo);

        Reservacion reservacion = new Reservacion.ReservacionBuilder()
            .SetCodigoReserva(reservacionInfo.CodigoReserva)
            .SetAsientoSeleccionado(asiento)
            .SetVuelo(vuelo)
            .SetPasajero(pasajero)
            .Build();

        reservaciones.Add(reservacion);
    }

    foreach (var codigoReserva in contenidoSeleccionAsientos)
    {
        var asientoReservaInfo = new AsientoReservaInfo(codigoReserva);

        var reservacion = reservaciones.FirstOrDefault(reserva => reserva.CodigoReserva == asientoReservaInfo.CodigoReserva);

        if (reservacion != null && reservacion.AsientoSeleccionado != null)
        {
            Asiento asientoActualizado = reservacionService.ActualizarAsiento(reservacion, true);

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

    Console.Write("Ingrese su email:");
    string? email = Console.ReadLine();

    var context = new ReservaContext
    {
        Email = email??"",
        Reservaciones = reservaciones
    };

    // Crear y encadenar los handlers
    var emailHandler = new CorreoHandler();
    var mostrarReservasHandler = new MostrarReservasHandler();
    var seleccionAsientoHandler = new SeleccionAsientoHandler();
    var validacionFechaHoraHandler = new ValidacionFechaHoraHandler();
    var guardarSeleccionHandler = new GuardarSeleccionHandler();

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


