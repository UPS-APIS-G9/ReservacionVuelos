using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using ReservacionVuelos.Services;

try
{
    LeerArchivo.Instance.InitializeFileReservations("Files/reservations.txt");
    LeerArchivo.Instance.InitializeFileSeatSelection("Files/seat-selection.txt");

    // Obtener el contenido del archivo
    List<string> contenidoReservaciones = LeerArchivo.Instance.GetcontenidoReservaciones();
    List<string> contenidoSeleccionAsientos = LeerArchivo.Instance.GetcontenidoSeleccionAsiento();


    foreach (var reservacion in contenidoReservaciones)
    {
        var reservacionDividida = reservacion.Split("|");

        Pasajero pasajero = new Pasajero.PasajeroBuilder()
            .SetNombres(reservacionDividida[4].ToString())
            .SetApellidos(reservacionDividida[5].ToString())
            .SetPaisEmision(reservacionDividida[3].ToString())
            .SetCorreo(reservacionDividida[6].ToString())
            .SetNumeroIdentificacion(reservacionDividida[1].ToString())
            .SetTipoIdentificacion(reservacionDividida[2].ToString().Equals("PAS") ? TipoIdentificacion.PAS : TipoIdentificacion.NAC)
            .Build();

        Vuelo vuelo = new Vuelo.VueloBuilder()
            .SetNumeroVuelo(reservacionDividida[4].ToString())
            .Build();
    }


    Asiento asiento = new Asiento.AsientoBuilder()
        .SetFila("8")
        .SetColumna("A")
        .SetCategoria("P")
        .Build();

    
    Console.WriteLine(contenidoSeleccionAsientos);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}