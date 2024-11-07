using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;
using ReservacionVuelos.Services;
using ReservacionVuelos.Utiles;
using System.Runtime.CompilerServices;
using System.Text;

namespace ReservacionVuelos.Tests
{
    public class ResumenServiceTest
    {

        [Fact]
        public void Test_GenerarResumenPorUsuario_Theory()
        {
            // Arrange
            List<string> textoOriginal = new();
            List<Reservacion> reservaciones = new();
            IVueloService vueloService = new VueloService();
            IPasajeroService pasajeroService = new PasajeroService();
            IAsientoService asientoService = new AsientoService();
            IResumenService resumenService = new ResumenService();

            textoOriginal.Add("ASDFGH|0201010101|NAC|EC|ANGELA|TRELLO|angela@mail.com|P|LA1447|I|GYE|SCL|2024-11-03 10:00:00");
            textoOriginal.Add("UIOZXC|0201010101|NAC|EC|ANGELA|TRELLO|angela@mail.com|Y|LX1012|N|UIO|GYE|2024-11-05 09:00:00");
            textoOriginal.Add("JKLPER|0201010101|NAC|EC|ANGELA|TRELLO|angela@mail.com|P|LA1555|I|SCL|LIM|2024-11-12 22:00:00");

            foreach (var lineaReservacion in textoOriginal)
            {
                var reservacionInfo = new ReservacionInfo(lineaReservacion);

                Pasajero pasajero = pasajeroService.CrearPasajero(reservacionInfo);
                Vuelo vuelo = vueloService.CrearVuelo(reservacionInfo);
                Asiento asiento = asientoService.CrearAsiento(reservacionInfo);

                Reservacion reservacion = new Reservacion.ReservacionBuilder()
                    .SetCodigoReserva(reservacionInfo.CodigoReserva)
                    .SetAsientoSeleccionado(asiento)
                    .SetVuelo(vuelo)
                    .SetPasajero(pasajero)
                    .SetFechaReserva(reservacionInfo.FechaHoraVuelo.ToFormatedDateTime())
                    .Build();

                reservaciones.Add(reservacion);
            }

            string email = "angela@mail.com";
            Asiento AsientoSeleccionado = new Asiento.AsientoBuilder()
                .SetCategoria("P")
                .SetCodigoAsiento("B3")
                .SetCodigoReserva("JKLPER")
                .SetEsPasillo(true)
                .SetEsVentana(false)
                .SetReservado(true)
                .Build();

            // Act
            resumenService.GenerarResumenPorUsuario(reservaciones, email, AsientoSeleccionado);

            // Assert
            //Assert.Equal(expected, result);
        }
    }
}
