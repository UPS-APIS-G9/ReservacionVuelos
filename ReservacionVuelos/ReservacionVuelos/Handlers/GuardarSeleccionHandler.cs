using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public class GuardarSeleccionHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Guardando selección en archivo...");

            File.AppendAllText("Files/seat-selection.txt", $"{context.CodigoAsiento}|{context.Email}|{context.FechaHoraLocal + Environment.NewLine}");
            base.Handle(context);
        }
    }
}
