using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Models.CalculationArea.Square;

namespace TrigonometryLibrary.Tests.CalculationArea.Square
{
    public class CalculateBySquareSideTests
    {
        [Theory]
        [InlineData(2.0, 4.0)]
        [InlineData(4.0, 16.0)]
        [InlineData(5.0, 25.0)]
        public void Constructor_SimpleValues_ReturnsExpectedResult(double side, double expected)
        {
            // Arrange
            CalculateBySquareSide calculateAreaBehavior = new(side);

            // Act
            var actual = Math.Round(calculateAreaBehavior.Area, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2.0, typeof(ArgumentOutOfRangeException))]
        [InlineData(0.0, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue * 2.0, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue, typeof(ResultOutOfRangeException))]
        public void Constructor_InvalidValues_ReturnsExceptions(double side, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                CalculateBySquareSide calculateAreaBehavior = new(side);
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
