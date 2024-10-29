using TrigonometryLibrary.Enums;
using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Tests.Validators
{
    public class TriangleValidatorTests
    {
        [Theory]
        [InlineData(100.0, 5.0, 6.0, TriangleType.None)]
        [InlineData(3.0, 3.0, 3.0, TriangleType.Equilateral)]
        [InlineData(3.0, 4.0, 5.0, TriangleType.Rectangular)]
        [InlineData(4.0, 5.0, 6.0, TriangleType.Default)]
        public void DetermineTriangleType_SimpleValues_ReturnsExpectedResult(double sideA, double sideB, double sideC, TriangleType expected)
        {
            // Act
            var actual = TriangleValidator.DetermineTriangleType(sideA, sideB, sideC);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(0.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue * 2.0, 4.0, 5.7, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, typeof(ResultOutOfRangeException))]
        public void DetermineTriangleType_InvalidValues_ReturnsExceptions(double sideA, double sideB, double sideC, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                TriangleValidator.DetermineTriangleType(sideA, sideB, sideC);
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
