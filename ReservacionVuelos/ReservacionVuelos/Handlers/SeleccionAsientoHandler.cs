using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public class SeleccionAsientoHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Verificando el código de asiento...");
            if (string.IsNullOrWhiteSpace(context.CodigoAsiento))
            {
                throw new Exception("Código de asiento no proporcionado.");
            }

            base.Handle(context);
        }
    }
}
