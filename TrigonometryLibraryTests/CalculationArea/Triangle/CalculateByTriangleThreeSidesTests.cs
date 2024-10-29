using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Models.CalculationArea.Triangle;

namespace TrigonometryLibrary.Tests.CalculationArea.Triangle
{
    public class CalculateByTriangleThreeSidesTests
    {
        [Theory]
        [InlineData(3.0, 3.0, 3.0, 3.9)]
        [InlineData(3.0, 4.0, 5.0, 6.0)]
        [InlineData(4.0, 5.0, 6.0, 9.92)]
        public void Constructor_SimpleValues_ReturnsExpectedResult(double sideA, double sideB, double sideC, double expected)
        {
            // Arrange
            CalculateByTriangleThreeSides calculateAreaBehavior = new(sideA, sideB, sideC);

            // Act
            var actual = Math.Round(calculateAreaBehavior.Area, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(0.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue * 2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(1.0, 2.0, 110.0, typeof(NotATriangleException))]
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, typeof(ResultOutOfRangeException))]
        public void Constructor_InvalidValues_ReturnsExceptions(double sideA, double sideB, double sideC, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                CalculateByTriangleThreeSides calculateAreaBehavior = new(sideA, sideB, sideC);
            }
            catch (NotATriangleException exception)
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
