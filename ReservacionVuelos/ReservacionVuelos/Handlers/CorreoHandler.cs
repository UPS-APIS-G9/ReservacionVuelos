﻿using ReservacionVuelos.DTOs;
using ReservacionVuelos.Services;

namespace ReservacionVuelos.Handlers
{
    public class CorreoHandler : ReservaHandlerBase
    {
        private readonly IResumenService _resumenService;

        public CorreoHandler(IResumenService resumenService)
        {
            this._resumenService = resumenService;
        }

        public override void Handle(ReservaContext context)
        {
            Console.Write("Ingrese su email:");
            string? email = Console.ReadLine();
            context.Email = email ?? "";

            var reservaciones = context.Reservaciones?.FindAll(registros => registros.Pasajero.Correo.Equals(context.Email));

            context.Reservaciones = reservaciones;

            if (context.IsAdmin)
            {
                _resumenService.GenerarResumenPorFecha(context.Reservaciones);
            }
            Console.WriteLine("\r\n");
            base.Handle(context);
        }
    }
}
