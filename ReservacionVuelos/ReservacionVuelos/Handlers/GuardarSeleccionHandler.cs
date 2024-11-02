using ReservacionVuelos.DTOs;
using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.Handlers
{
    public class GuardarSeleccionHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Guardando selección en archivo...");

            File.AppendAllText("Files/seat-selection.txt",
                $"{context.AsientoSeleccionado?.CodigoReserva}|{context.AsientoSeleccionado?.CodigoAsiento}|{context.FechaHoraLocal?.ToFormatedStringDateTime() + Environment.NewLine}");

            base.Handle(context);
        }
    }
}
