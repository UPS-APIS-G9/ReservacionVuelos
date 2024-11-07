using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Tests
{
    public class ResumenServiceTest
    {

        [Fact]
        public void Test_GenerarResumenPorUsuario_Theory()
        {
            // Arrange
            List<Reservacion> reservaciones = new();
            string email = "angela@mail.com";
            Asiento AsientoSeleccionado = new();

            // Act
            int result = math.Add(numberOne, numberTwo);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
