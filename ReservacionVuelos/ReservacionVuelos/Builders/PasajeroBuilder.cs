using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Builders
{
    public class PasajeroBuilder : IPasajeroBuilder
    {
        private readonly Pasajero pasajero;

        public PasajeroBuilder()
        {
            pasajero = new Pasajero();
        }

        public PasajeroBuilder SetNumeroIdentificacion(string numeroIdentificacion)
        {
            pasajero.NumeroIdentificacion = numeroIdentificacion;
            return this;
        }

        public PasajeroBuilder SetTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
        {
            pasajero.TipoIdentificacion = tipoIdentificacion;
            return this;
        }

        public PasajeroBuilder SetPaisEmision(string paisEmision)
        {
            pasajero.PaisEmision = paisEmision;
            return this;
        }

        public PasajeroBuilder SetNombres(string nombres)
        {
            pasajero.Nombres = nombres;
            return this;
        }

        public PasajeroBuilder SetApellidos(string apellidos)
        {
            pasajero.Apellidos = apellidos;
            return this;
        }

        public PasajeroBuilder SetCorreo(string correo)
        {
            pasajero.Correo = correo;
            return this;
        }

        public Pasajero Build()
        {
            return pasajero;
        }
    }
}
