using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;
using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.Handlers
{
    public class GuardarSeleccionHandler : ReservaHandlerBase
    {
        private readonly IResumenService _resumenService;

        public GuardarSeleccionHandler(IResumenService resumenService)
        {
            this._resumenService = resumenService;
        }

        public override void Handle(ReservaContext context)
        {            
            Console.WriteLine("Guardando selección en archivo...");

            File.AppendAllText("Files/seat-selection.txt",
                $"{context.AsientoSeleccionado?.CodigoReserva}|{context.AsientoSeleccionado?.CodigoAsiento}|{context.FechaHoraLocal?.ToFormatedStringDateTime() + Environment.NewLine}");

            this._resumenService.GenerarResumenPorUsuario(context.Reservaciones, context.Email ?? string.Empty, context.AsientoSeleccionado);

            base.Handle(context);
        }
    }
}
