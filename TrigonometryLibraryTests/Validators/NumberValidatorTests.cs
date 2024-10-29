using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Tests.Validators
{
    public class NumberValidatorTests
    {
        [Theory]
        [InlineData(2.0, 2.0)]
        [InlineData(4.23, 4.23)]
        [InlineData(5.71, 5.71)]
        [InlineData(double.MaxValue, double.MaxValue)]
        public void ValidatePositiveRange_SimpleValues_ReturnsExpectedResult(double number, double expected)
        {
            // Act
            var actual = NumberValidator.ValidatePositiveRange(number);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2.0, typeof(ArgumentOutOfRangeException))]
        [InlineData(0.0, typeof(ArgumentOutOfRangeException))]
        [InlineData(double.MaxValue * 2.0, typeof(ArgumentOutOfRangeException))]
        public void ValidatePositiveRange_InvalidValues_ReturnsExceptions(double number, Type expected)
        {
            // Arrange
            Exception? actual = null;

            // Act
            try
            {
                NumberValidator.ValidatePositiveRange(number);
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
