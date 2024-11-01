using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;
using System.Text.RegularExpressions;

namespace ReservacionVuelos.Handlers
{
    public class SeleccionAsientoHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            if (string.IsNullOrWhiteSpace(context.AsientoSeleccionado?.CodigoAsiento))
            {
                Console.Write("Ingrese el código de asiento a reservar (Ej. A1):");
                var codigoAsiento = Console.ReadLine();

                codigoAsiento = codigoAsiento ?? "";

                if (!Regex.IsMatch(codigoAsiento, @"^[A-F]\d+$"))
                {
                    throw new Exception("Código de asiento no válido.");
                }

                string columna = codigoAsiento[0].ToString();
                int fila = int.Parse(codigoAsiento[1..]);

                var clase = ObtenerClasePorFila(fila);

                if (DistribucionAsientos.EsAsientoValido(clase, fila, columna, context.AsientosDisponibles))
                {
                    var asientoSeleccionado = context.AsientosDisponibles.FirstOrDefault(a => a.CodigoReserva == codigoAsiento && !a.Reservado);

                    if (asientoSeleccionado != null)
                    {
                        context.AsientoSeleccionado = asientoSeleccionado;
                        Console.WriteLine($"Asiento {codigoAsiento} seleccionado correctamente en la clase {clase}.");
                        base.Handle(context);
                    }
                    else
                    {
                        throw new Exception("El asiento ya está reservado o no existe en el sistema.");
                    }
                }
                else
                {
                    throw new Exception($"El asiento {codigoAsiento} no es válido para la clase {clase} o excede el límite de asientos disponibles en esta clase.");
                }
            }
            else {
                throw new Exception("Posee una reserva activa.");
            }

            base.Handle(context);
        }

        private string ObtenerClasePorFila(int fila)
        {
            if (fila >= 1 && fila <= 3) return "Premium";
            if (fila >= 4 && fila <= 8) return "Premium Economy";
            if (fila >= 9 && fila <= 27) return "Economy";
            return "Desconocida";
        }
    }
}
