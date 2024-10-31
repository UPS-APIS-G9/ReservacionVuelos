using ReservacionVuelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Services
{
    public class ResumenService
    {
        public void GenerarResumenPorFecha(List<Reservacion> reservaciones)
        {
            var resumen = reservaciones
                .GroupBy(r => r.Vuelo.FechaHoraVuelo.Date)
                .Select(g => new
                {
                    Fecha = g.Key,
                    Reservas = g.Select(r => new
                    {
                        CodigoReserva = r.CodigoReserva,
                        Asiento = r.AsientoSeleccionado?.CodigoReserva,
                        CategoriaAsiento = r.AsientoSeleccionado?.Categoria,
                        Vuelo = r.Vuelo.NumeroVuelo
                    }).ToList()
                });

            Console.WriteLine("Resumen de vuelos y asientos seleccionados por fecha:");
            foreach (var item in resumen)
            {
                Console.WriteLine($"Fecha: {item.Fecha.ToShortDateString()}");
                foreach (var reserva in item.Reservas)
                {
                    Console.WriteLine($"  Código de Reserva: {reserva.CodigoReserva}, Asiento: {reserva.Asiento}, Categoría: {reserva.CategoriaAsiento}, Vuelo: {reserva.Vuelo}");
                }
            }
        }
    }
}
