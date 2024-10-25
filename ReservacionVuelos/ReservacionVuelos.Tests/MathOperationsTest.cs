namespace ReservacionVuelos.Tests
{
    public class MathOperationsTest
    {
        // Ejemplos de tests
        [Fact]
        public void Test_Add()
        {
            // Arrange
            MathOperations math = new MathOperations();

            // Act
            int result = math.Add(3, 5);

            // Assert
            Assert.Equal(8, result);
        }

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