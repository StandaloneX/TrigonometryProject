using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Interfaces.CalculationArea;
using TrigonometryLibrary.Models.Figures;

namespace TrigonometryLibrary.Tests.Figures
{
    public class SquareTests
    {
        [Theory]
        [InlineData(2.0, 4.0)]
        [InlineData(4.0, 16.0)]
        [InlineData(5.0, 25.0)]
        public void CalculateArea_SimpleValues_ReturnsExpectedResult(double radius, double expected)
        {
            // Arrange (usage of interface as proof of the ability to calculate without knowing the type of the figure at compile time)
            IAreaCalculatable square = new Square(radius);

            // Act
            var actual = Math.Round(square.CalculateArea(), 2);

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
                Square square = new(side);
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