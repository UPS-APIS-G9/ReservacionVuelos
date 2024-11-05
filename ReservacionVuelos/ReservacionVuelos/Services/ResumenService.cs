using ReservacionVuelos.Entities;
using ReservacionVuelos.Utiles;

namespace ReservacionVuelos.Services
{
    public class ResumenService : IResumenService
    {
        public void GenerarResumenPorFecha(List<Reservacion> reservaciones)
        {
            var resumen = reservaciones
                .GroupBy(r => new
                {
                    Fecha = r.Vuelo.FechaHoraVuelo.Date,
                    Vuelo = r.Vuelo.NumeroVuelo
                })
                .Select(g => new
                {
                    Fecha = g.Key.Fecha,
                    NumeroVuelo = g.Key.Vuelo,
                    TotalAsientosOcupados = g.Count(r => r.AsientoSeleccionado.CodigoAsiento != null),
                    Reservas = g.Select(r => new
                    {
                        r.CodigoReserva,
                        Asiento = r.AsientoSeleccionado?.CodigoReserva ?? "No seleccionado",
                        CategoriaAsiento = r.AsientoSeleccionado?.Categoria,
                        Origen = r.Vuelo.AeropuertoOrigen,
                        Destino = r.Vuelo.AeropuertoDestino
                    }).ToList()
                });

            var resumenAgrupadoPorFecha = resumen
                .GroupBy(item => item.Fecha)
                .Select(g => new
                {
                    Fecha = g.Key,
                    Vuelos = g.ToList()
                });

            Console.WriteLine("Resumen de vuelos y asientos reservados por fecha:");
            Console.WriteLine("");
            foreach (var item in resumenAgrupadoPorFecha)
            {
                Console.WriteLine(item.Fecha.ToFormatedStringDateTime());

                foreach (var vuelo in item.Vuelos)
                {
                    Console.WriteLine($"{vuelo.NumeroVuelo}|{vuelo.Reservas.FirstOrDefault()?.CategoriaAsiento ?? "N"}|{vuelo.Reservas.FirstOrDefault()?.Origen}|{vuelo.Reservas.FirstOrDefault()?.Destino}|Asientos seleccionados: {vuelo.TotalAsientosOcupados}");
                }
                Console.WriteLine("");
            }
        }

        public void GenerarResumenPorUsuario(List<Reservacion> reservaciones, string email, string codigoAsiento)
        {
            var resumen = reservaciones
                .Where(u => u.Pasajero.Correo.Equals(email))
                .GroupBy(r => r.Pasajero.Nombres + " " + r.Pasajero.Apellidos)
                .Select(g => new
                {
                    Pasajero = g.Key,
                    Reservas = g.Select(r => new
                    {
                        r.CodigoReserva,
                        Asiento = string.IsNullOrEmpty(codigoAsiento) ? "No seleccionado" : codigoAsiento,
                        Vuelo = r.Vuelo.NumeroVuelo,
                        Origen = r.Vuelo.AeropuertoOrigen,
                        Destino = r.Vuelo.AeropuertoDestino,
                        Fecha = r.FechaReserva
                    }).ToList()
                });

            foreach (var item in resumen)
            {
                Console.WriteLine(item.Pasajero);
                foreach (var reserva in item.Reservas)
                {
                    Console.WriteLine($"{reserva.CodigoReserva}|Vuelo: {reserva.Vuelo}|Origen: {reserva.Origen}|Destino: {reserva.Destino}|Fecha: {reserva.Fecha.ToFormatedStringDateTime()}|Asiento: {reserva.Asiento}");
                }
            }
        }
    }
}
