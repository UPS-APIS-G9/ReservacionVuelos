using ReservacionVuelos.DTOs;
using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.Handlers
{
    public class ValidacionFechaHoraHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Ingrese la fecha y hora actual:");
            var fechaHoraActual = Console.ReadLine();

            if (fechaHoraActual?.ToFormatedDateTime() < DateTime.Now.ToFormatedDateTime())
            {
                throw new Exception("Fecha y hora inválidas.");
            }
            context.FechaHoraLocal = fechaHoraActual?.ToFormatedDateTime();
            base.Handle(context);
        }
    }
}
