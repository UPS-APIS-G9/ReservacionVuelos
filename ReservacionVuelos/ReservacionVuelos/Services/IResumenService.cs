using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    public interface IResumenService
    {
        void GenerarResumenPorFecha(List<Reservacion> reservaciones);
        void GenerarResumenPorUsuario(List<Reservacion> reservaciones, string email, Asiento AsientoSeleccionado);
    }
}
