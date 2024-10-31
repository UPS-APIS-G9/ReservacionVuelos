using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public class GuardarSeleccionHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            Console.WriteLine("Guardando selección en archivo...");
            // Lógica para escribir en el archivo (p. ej., usando File.AppendAllText)
            // File.AppendAllText("Files/seat-selection.txt", $"{context.CodigoAsiento}|{context.Email}");
            base.Handle(context);
        }
    }
}
