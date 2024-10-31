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
                Console.WriteLine($"Código de Reserva: {reserva.CodigoReserva}, Asiento: {reserva.AsientoSeleccionado?.CodigoReserva ?? "No asignado"}");
            }

            Console.Write("Ingrese el código de asiento a seleccionar: ");
            var codigoAsiento = Console.ReadLine();

            var asientoSeleccionado = reservaciones
                .Select(r => r.AsientoSeleccionado)
                .FirstOrDefault(a => a?.CodigoReserva == codigoAsiento);

            if (asientoSeleccionado != null)
            {
                context.AsientoSeleccionado = asientoSeleccionado;
                Console.WriteLine($"Asiento {codigoAsiento} seleccionado con éxito.");
                base.Handle(context);
            }
            else
            {
                Console.WriteLine("El código de asiento ingresado no es válido. Intente nuevamente.");
            }
        }
    }
}
