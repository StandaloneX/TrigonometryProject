using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Enums;
using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.CalculationArea.Triangle
{
    public class CalculateByTriangleThreeSides : CalculateAreaBehavior
    {
        public CalculateByTriangleThreeSides(double sideA, double sideB, double sideC)
        {
            var triangleType = TriangleValidator.DetermineTriangleType(sideA, sideB, sideC);
            if (triangleType == TriangleType.None)
                throw new NotATriangleException();

            try
            {
                var halfPerimeter = NumberValidator.ValidatePositiveRange((sideA + sideB + sideC) / 2.0);
                _area = NumberValidator.ValidatePositiveRange(Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC)));
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }
        }
    }
}
