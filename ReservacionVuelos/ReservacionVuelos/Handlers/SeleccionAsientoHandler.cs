using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;
using System.Text.RegularExpressions;

namespace ReservacionVuelos.Handlers
{
    public class SeleccionAsientoHandler : ReservaHandlerBase
    {

        private readonly IAsientoService _asientoService;

        public SeleccionAsientoHandler(IAsientoService asientoService)
        {
            _asientoService = asientoService;
        }

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

                var claseAsiento = _asientoService.ObtenerClasePorFila(fila);

                var verificarReserva = (context.Reservaciones?.FirstOrDefault(r => r.CodigoReserva == context.AsientoSeleccionado?.CodigoReserva)) ??
                    throw new Exception("Reserva no encontrada.");
                
                if (_asientoService.EsAsientoValido(claseAsiento, fila, columna, context.AsientosDisponibles))
                {
                    var vuelo = context.Reservaciones
                        .FirstOrDefault(v => v.CodigoReserva == context.CodigoReserva);

                    var asientosOcupados = context.reservasConAsientoOcupado
                        .FirstOrDefault(ocupado => ocupado.AsientoSeleccionado.Reservado &&
                                        ocupado.AsientoSeleccionado.CodigoAsiento.Equals(codigoAsiento) &&
                                        ocupado.Vuelo.NumeroVuelo.Equals(vuelo?.Vuelo.NumeroVuelo));

                    if (asientosOcupados != null)
                    {
                        throw new Exception("El asiento ya está reservado.");
                    }

                    var asientoSeleccionado = context.AsientosDisponibles
                        .FirstOrDefault(asiento => asiento.CodigoAsiento == codigoAsiento);

                    asientoSeleccionado = _asientoService.ActualizarAsientoReservado(context.AsientoSeleccionado?.CodigoReserva??"", asientoSeleccionado);

                    var reserva = context.Reservaciones
                        .FirstOrDefault(r => r.CodigoReserva == context.AsientoSeleccionado?.CodigoReserva);

                    if (reserva?.AsientoSeleccionado.CodigoAsiento != null && reserva?.AsientoSeleccionado.CodigoAsiento != codigoAsiento)
                    {
                        throw new Exception("No puede seleccionar más de un asiento en el mismo vuelo.");
                    }

                    if (reserva != null && !_asientoService.EsAsientoPermitidoParaClasePasajero(reserva.AsientoSeleccionado.Categoria, claseAsiento))
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

    }

}
