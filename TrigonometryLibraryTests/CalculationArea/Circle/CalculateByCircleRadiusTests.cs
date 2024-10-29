using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Models.CalculationArea.Circle;

namespace TrigonometryLibrary.Tests.CalculationArea.Circle
{
    public class CalculateByCircleRadiusTests
    {
        [Theory]
        [InlineData(2.0, 12.57)]
        [InlineData(4.0, 50.27)]
        [InlineData(5.0, 78.54)]
        public void Constructor_SimpleValues_ReturnsExpectedResult(double radius, double expected)
        {
            // Arrange
            CalculateByCircleRadius calculateAreaBehavior = new(radius);

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
        public void Constructor_InvalidValues_ReturnsExceptions(double radius, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                CalculateByCircleRadius calculateAreaBehavior = new(radius);
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
