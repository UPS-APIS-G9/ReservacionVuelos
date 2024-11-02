namespace ReservacionVuelos.Tests
{
    public class AsientoServiceTest
    {
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(3, 0, 3)]
        //[InlineData(4, 5, 8)] //Error
        public void Test_Add_Theory(int numberOne, int numberTwo, int expected)
        {
            // Arrange
            MathOperations math = new MathOperations();

            // Act
            int result = math.Add(numberOne, numberTwo);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
