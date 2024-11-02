﻿using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;
using System.Text.RegularExpressions;

namespace ReservacionVuelos.Handlers
{
    public class SeleccionAsientoHandler : ReservaHandlerBase
    {
        public override void Handle(ReservaContext context)
        {
            BuilderService builderService = new();
            AsientoService asientoService = new();

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

                var claseAsiento = asientoService.ObtenerClasePorFila(fila);

                var verificarReserva = (context.Reservaciones?.FirstOrDefault(r => r.CodigoReserva == context.AsientoSeleccionado?.CodigoReserva)) ??
                    throw new Exception("Reserva no encontrada.");
                
                if (verificarReserva.AsientoSeleccionado.Categoria != claseAsiento)
                {
                    throw new Exception($"La clase del asiento seleccionado ({claseAsiento}) no coincide con la clase de la reserva ({verificarReserva.AsientoSeleccionado.Categoria}).");
                }

                if (asientoService.EsAsientoValido(claseAsiento, fila, columna, context.AsientosDisponibles))
                {
                    var asientoSeleccionado = context.AsientosDisponibles
                        .FirstOrDefault(asiento => asiento.CodigoAsiento == codigoAsiento && !asiento.Reservado);

                    if (asientoSeleccionado == null)
                    {
                        throw new Exception("El asiento ya está reservado o no existe en el sistema.");
                    }

                    asientoSeleccionado = builderService.ActualizarAsientoReservado(context.AsientoSeleccionado?.CodigoReserva??"", asientoSeleccionado);

                    var reserva = context.Reservaciones
                        .FirstOrDefault(r => r.CodigoReserva == context.AsientoSeleccionado?.CodigoReserva);

                    if (reserva?.AsientoSeleccionado.CodigoAsiento != null && reserva?.AsientoSeleccionado.CodigoAsiento != codigoAsiento)
                    {
                        throw new Exception("No puede seleccionar más de un asiento en el mismo vuelo.");
                    }

                    if (reserva != null && !context.EsAsientoPermitidoParaClasePasajero(reserva.AsientoSeleccionado.Categoria, claseAsiento))
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
