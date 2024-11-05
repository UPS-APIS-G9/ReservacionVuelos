using ReservacionVuelos.Builders;
using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    internal class PasajeroService : IPasajeroService
    {
        public PasajeroService() {}

        public Pasajero CrearPasajero(ReservacionInfo info)
        {
            IPasajeroBuilder pasajeroBuilder = new PasajeroBuilder();
            return pasajeroBuilder
                .SetNombres(info.Nombres)
                .SetApellidos(info.Apellidos)
                .SetPaisEmision(info.PaisEmision)
                .SetCorreo(info.Correo)
                .SetNumeroIdentificacion(info.NumeroIdentificacion)
                .SetTipoIdentificacion(info.TipoIdentificacion.Equals("PAS") ? TipoIdentificacion.PAS : TipoIdentificacion.NAC)
                .Build();
        }

    }
}
