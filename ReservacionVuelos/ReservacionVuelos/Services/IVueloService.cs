using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    public interface IVueloService
    {
        Vuelo CrearVuelo(ReservacionInfo info);
    }
}
