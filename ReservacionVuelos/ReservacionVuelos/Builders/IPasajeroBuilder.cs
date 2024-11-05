using ReservacionVuelos.Entities;
using ReservacionVuelos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Builders
{
    public interface IPasajeroBuilder
    {
        PasajeroBuilder SetNumeroIdentificacion(string numeroIdentificacion);
        PasajeroBuilder SetTipoIdentificacion(TipoIdentificacion tipoIdentificacion);
        PasajeroBuilder SetPaisEmision(string paisEmision);
        PasajeroBuilder SetNombres(string nombres);
        PasajeroBuilder SetApellidos(string apellidos);
        PasajeroBuilder SetCorreo(string correo);
        Pasajero Build();
    }
}
