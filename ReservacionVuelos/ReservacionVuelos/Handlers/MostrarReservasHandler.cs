using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;

namespace ReservacionVuelos.Handlers
{
    public class MostrarReservasHandler : ReservaHandlerBase
    {
        private readonly AsientoService asientoService;

        public MostrarReservasHandler(AsientoService asientoService)
        {
            this.asientoService = asientoService;
        }

        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Reservas disponibles:");

            if (context.Reservaciones?.Count == 0)
            {
                throw new Exception("No se encontraron reservas para este pasajero.");
            }

            foreach (var reserva in context.Reservaciones)
            {
                Console.WriteLine(reserva.ToString());
            }

            Console.Write("Ingrese el código de reserva a seleccionar: ");
            var codigoReserva = Console.ReadLine();

            Console.WriteLine("Verificando el código de reserva...");

            var asientoSeleccionado = context.Reservaciones
                .Select(r => r.AsientoSeleccionado)
                .FirstOrDefault(a => a?.CodigoReserva == codigoReserva);

            var vuelo = context.Reservaciones
                .FirstOrDefault(v => v.CodigoReserva == codigoReserva);

            if (!asientoService.PuedeSeleccionarAsiento(vuelo.Vuelo.FechaHoraVuelo, vuelo.Vuelo.Alcance.Equals("N")))
            {
                throw new Exception("No se puede seleccionar un asiento debido a restricciones de tiempo.");
            }

            if (asientoSeleccionado != null)
            {
                context.AsientoSeleccionado = asientoSeleccionado;

                base.Handle(context);
            }
            else
            {
                Console.WriteLine("El código de reserva ingresado no es válido. Intente nuevamente.");
            }
        }
    }
}
