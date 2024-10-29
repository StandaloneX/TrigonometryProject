using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Interfaces.CalculationArea;
using TrigonometryLibrary.Models.Figures;

namespace TrigonometryLibrary.Tests.Figures
{
    public class CircleTests
    {
        [Theory]
        [InlineData(2.0, 12.57)]
        [InlineData(4.0, 50.27)]
        [InlineData(5.0, 78.54)]
        public void CalculateArea_SimpleValues_ReturnsExpectedResult(double radius, double expected)
        {
            // Arrange (usage of interface as proof of the ability to calculate without knowing the type of the figure at compile time)
            IAreaCalculatable circle = new Circle(radius);

            // Act
            var actual = Math.Round(circle.CalculateArea(), 2);

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
                Circle circle = new(radius);
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