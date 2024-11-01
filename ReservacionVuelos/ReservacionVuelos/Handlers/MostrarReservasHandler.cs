using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public class MostrarReservasHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Reservas disponibles:");

            var reservaciones = context.Reservaciones?.FindAll(registros => registros.Pasajero.Correo.Equals(context.Email));

            if (reservaciones?.Count == 0)
            {
                throw new Exception("No se encontraron reservas para este pasajero.");
            }

            foreach (var reserva in reservaciones)
            {
                Console.WriteLine(reserva.ToString());
            }

            Console.Write("Ingrese el código de reserva a seleccionar: ");
            var codigoReserva = Console.ReadLine();

            Console.WriteLine("Verificando el código de reserva...");

            var asientoSeleccionado = reservaciones
                .Select(r => r.AsientoSeleccionado)
                .FirstOrDefault(a => a?.CodigoReserva == codigoReserva);

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
