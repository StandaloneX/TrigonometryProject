using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Models.CalculationArea.Triangle;

namespace TrigonometryLibrary.Tests.CalculationArea.Triangle
{
    public class CalculateByTriangleSideTests
    {
        [Theory]
        [InlineData(3.0, 3.0, 3.0, 3.9)]
        [InlineData(5.0, 5.0, 5.0, 10.83)]
        [InlineData(9.0, 9.0, 9.0, 35.07)]
        public void Constructor_SimpleValues_ReturnsExpectedResult(double sideA, double sideB, double sideC, double expected)
        {
            // Arrange
            CalculateByTriangleSide calculateAreaBehavior = new(sideA, sideB, sideC);

            // Act
            var actual = Math.Round(calculateAreaBehavior.Area, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(0.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue * 2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(1.0, 2.0, 110.0, typeof(NotAEquilateralTriangleException))]
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, typeof(ResultOutOfRangeException))]
        public void Constructor_InvalidValues_ReturnsExceptions(double sideA, double sideB, double sideC, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                CalculateByTriangleSide calculateAreaBehavior = new(sideA, sideB, sideC);
            }
            catch (NotAEquilateralTriangleException exception)
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
