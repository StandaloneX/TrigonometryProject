using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Interfaces.CalculationArea;
using TrigonometryLibrary.Models.Figures;

namespace TrigonometryLibrary.Tests.Figures
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(3.0, 3.0, 3.0, 3.9)]
        [InlineData(3.0, 4.0, 5.0, 6.0)]
        [InlineData(4.0, 5.0, 6.0, 9.92)]
        public void CalculateArea_SimpleValues_ReturnsExpectedResult(double sideA, double sideB, double sideC, double expected)
        {
            // Arrange (usage of interface as proof of the ability to calculate without knowing the type of the figure at compile time)
            IAreaCalculatable triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var actual = Math.Round(triangle.CalculateArea(), 2);

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
                Triangle triangle = new(sideA, sideB, sideC);
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