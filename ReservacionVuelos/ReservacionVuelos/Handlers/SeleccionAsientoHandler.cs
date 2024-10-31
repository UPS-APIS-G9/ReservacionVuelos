using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public class SeleccionAsientoHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            if (string.IsNullOrWhiteSpace(context.AsientoSeleccionado?.CodigoAsiento))
            {
                Console.Write("Ingrese el código de asiento a reservar:");
                var codigoAsiento = Console.ReadLine();

            }

            if (string.IsNullOrWhiteSpace(context.CodigoAsiento))
            {
                throw new Exception("Código de asiento no válido.");
            }

            base.Handle(context);
        }
    }
}
