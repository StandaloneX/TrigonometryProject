using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.CalculationArea.Circle
{
    public class CalculateByCircleRadius : CalculateAreaBehavior
    {
        public CalculateByCircleRadius(double radius)
        {
            NumberValidator.ValidatePositiveRange(radius);
            try
            {
                _area = NumberValidator.ValidatePositiveRange(Math.PI * radius * radius);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }
        }
    }
}
