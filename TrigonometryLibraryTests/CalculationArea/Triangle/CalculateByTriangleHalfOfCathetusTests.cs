using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Models.CalculationArea.Triangle;

namespace TrigonometryLibrary.Tests.CalculationArea.Triangle
{
    public class CalculateByTriangleHalfOfCathetusTests
    {
        [Theory]
        [InlineData(3.0, 4.0, 5.0, 6.0)]
        [InlineData(5.0, 12.0, 13.0, 30.0)]
        [InlineData(8.0, 15.0, 17.0, 60.0)]
        public void Constructor_SimpleValues_ReturnsExpectedResult(double sideA, double sideB, double sideC, double expected)
        {
            // Arrange
            CalculateByTriangleHalfOfCathetus calculateAreaBehavior = new(sideA, sideB, sideC);

            // Act
            var actual = Math.Round(calculateAreaBehavior.Area, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(0.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue * 2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(1.0, 2.0, 110.0, typeof(NotARectangularTriangleException))]
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, typeof(ResultOutOfRangeException))]
        public void Constructor_InvalidValues_ReturnsExceptions(double sideA, double sideB, double sideC, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                CalculateByTriangleHalfOfCathetus calculateAreaBehavior = new(sideA, sideB, sideC);
            }
            catch (NotARectangularTriangleException exception)
            {
                actual = exception;
            }
            catch (ResultOutOfRangeException exception)
            {
                actual = exception;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                actual = exception;
            }

            // Assert
            Assert.Equal(expected, actual?.GetType());
        }
    }
}
