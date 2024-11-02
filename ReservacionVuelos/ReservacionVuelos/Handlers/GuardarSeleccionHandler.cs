using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;
using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.Handlers
{
    public class GuardarSeleccionHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            ResumenService resumenService = new();
            Console.WriteLine("Guardando selección en archivo...");

            File.AppendAllText("Files/seat-selection.txt",
                $"{context.AsientoSeleccionado?.CodigoReserva}|{context.AsientoSeleccionado?.CodigoAsiento}|{context.FechaHoraLocal?.ToFormatedStringDateTime() + Environment.NewLine}");

            resumenService.GenerarResumenPorUsuario(context.Reservaciones, context.Email ?? string.Empty, context.AsientoSeleccionado?.CodigoAsiento ?? string.Empty);

            base.Handle(context);
        }
    }
}
