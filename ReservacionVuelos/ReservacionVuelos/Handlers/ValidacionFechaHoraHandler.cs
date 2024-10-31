using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public class ValidacionFechaHoraHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Ingrese la fecha y hora actual:");
            var fechaHoraActual = Console.ReadLine();

            if (context.FechaHoraLocal < DateTime.Now)
            {
                throw new Exception("Fecha y hora inválidas.");
            }

            base.Handle(context);
        }
    }
}
