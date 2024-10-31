using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;

namespace ReservacionVuelos.Handlers
{
    public class CorreoHandler : ReservaHandlerBase
    {
        private readonly ResumenService _resumenService;

        public CorreoHandler()
        {
            _resumenService = new ResumenService();
        }

        public override void Handle(ReservaContext context)
        {
            if (context.IsAdmin)
            {
                _resumenService.GenerarResumenPorFecha(context.Reservaciones);
            }
            Console.WriteLine("\r\n");
            base.Handle(context);
        }
    }
}
