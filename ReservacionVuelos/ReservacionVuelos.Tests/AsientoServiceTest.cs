using ReservacionVuelos.Services;
using ReservacionVuelos.Utiles;
using System.Globalization;

namespace ReservacionVuelos.Tests
{
    public class AsientoServiceTest
    {

        IAsientoService service;

        [Theory]
        [InlineData("2024-01-01 00:00:00", true)]
        [InlineData("2024-01-01 00:00:00", false)]
        public void givenFechaDeVueloPasada_when_PuedeSeleccionarAsiento_thenReturnFalse(string date, bool esNacional)
        {
            service = new AsientoService();
            DateTime fechaHoraVuelo = DateTime.ParseExact(date, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

            var puedeSeleccionarAssiento = service.PuedeSeleccionarAsiento(fechaHoraVuelo, esNacional);

            Assert.False(puedeSeleccionarAssiento);

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void givenFechaDeVueloHoraActual_when_PuedeSeleccionarAsiento_thenReturnFalse(bool esNacional)
        {
            service = new AsientoService();
            DateTime localDate = DateTime.Now;

            var puedeSeleccionarAssiento = service.PuedeSeleccionarAsiento(localDate, esNacional);

            Assert.False(puedeSeleccionarAssiento);

        }

        [Theory]
        [InlineData(Constantes.HorasAntesVueloNacional, true)]
        [InlineData(Constantes.HorasAntesVueloInternancional, false)]
        public void givenFechaDeVueloDentroRangoPermitido_when_PuedeSeleccionarAsiento_thenReturnTrue(int horasAntesVuelo, bool esNacional)
        {
            service = new AsientoService();
            DateTime localDate = DateTime.Now;

            var puedeSeleccionarAssiento = service.PuedeSeleccionarAsiento(localDate.AddHours(horasAntesVuelo).AddSeconds(1), esNacional);

            Assert.True(puedeSeleccionarAssiento);

        }

    }
}
