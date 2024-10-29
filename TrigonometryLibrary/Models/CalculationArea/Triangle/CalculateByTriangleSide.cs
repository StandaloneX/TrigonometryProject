using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Enums;
using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.CalculationArea.Triangle
{
    public class CalculateByTriangleSide : CalculateAreaBehavior
    {
        public CalculateByTriangleSide(double sideA, double sideB, double sideC) 
        {
            var triangleType = TriangleValidator.DetermineTriangleType(sideA, sideB, sideC);
            if (triangleType != TriangleType.Equilateral)
                throw new NotAEquilateralTriangleException();

            try
            {
                _area = NumberValidator.ValidatePositiveRange(Math.Sqrt(3.0) / 4.0 * Math.Pow(sideA, 2.0));
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }
        }
    }
}
