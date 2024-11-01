using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;
using System.Text.RegularExpressions;

namespace ReservacionVuelos.Handlers
{
    public class SeleccionAsientoHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            if (context.AsientoSeleccionado == null || string.IsNullOrWhiteSpace(context.AsientoSeleccionado?.CodigoAsiento))
            {
                Console.Write("Ingrese el código de asiento a reservar (Ej. A1):");
                var codigoAsiento = Console.ReadLine() ?? "";

                if (!Regex.IsMatch(codigoAsiento, @"^[A-F]\d+$"))
                {
                    throw new Exception("Código de asiento no válido.");
                }

                string columna = codigoAsiento[0].ToString();
                int fila = int.Parse(codigoAsiento[1..]);

                var claseAsiento = DistribucionAsientos.ObtenerClasePorFila(fila);

                if (DistribucionAsientos.EsAsientoValido(claseAsiento, fila, columna, context.AsientosDisponibles))
                {
                    var asientoSeleccionado = context.AsientosDisponibles
                        .FirstOrDefault(asiento => asiento.CodigoAsiento == codigoAsiento && !asiento.Reservado);

                    if (asientoSeleccionado == null)
                    {
                        throw new Exception("El asiento ya está reservado o no existe en el sistema.");
                    }

                    var reserva = context.Reservaciones
                        .FirstOrDefault(r => r.CodigoReserva == context.CodigoReservaSeleccionada);

                    if (reserva?.AsientoSeleccionado != null && reserva.AsientoSeleccionado.CodigoAsiento != codigoAsiento)
                    {
                        throw new Exception("No puede seleccionar más de un asiento en el mismo vuelo.");
                    }

                    if (reserva != null && !EsAsientoPermitidoParaClasePasajero(reserva.AsientoSeleccionado.Categoria, claseAsiento))
                    {
                        throw new Exception($"La reserva con clase '{reserva.AsientoSeleccionado.Categoria}' no puede seleccionar asientos en la cabina '{claseAsiento}'.");
                    }

                    context.AsientoSeleccionado = asientoSeleccionado;
                    Console.WriteLine($"Asiento {codigoAsiento} seleccionado correctamente en la clase {claseAsiento}.");
                    base.Handle(context);
                }
                else
                {
                    throw new Exception($"El asiento {codigoAsiento} no es válido para la clase {claseAsiento} o excede el límite de asientos disponibles en esta clase.");
                }
            }
            else
            {
                throw new Exception("Ya posee una reserva activa.");
            }
        }

        private bool EsAsientoPermitidoParaClasePasajero(string clasePasajero, string claseAsiento)
        {
            if (clasePasajero == "P")
            {
                return claseAsiento == "Premium" || claseAsiento == "Premium Economy";
            }
            else
            {
                return claseAsiento != "Premium";
            }
        }
    }

}
