using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.CalculationArea.Square
{
    public class CalculateBySquareSide : CalculateAreaBehavior
    {
        public CalculateBySquareSide(double side)
        {
            NumberValidator.ValidatePositiveRange(side);
            try
            {
                _area = NumberValidator.ValidatePositiveRange(side * side);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }
        }
    }
}
