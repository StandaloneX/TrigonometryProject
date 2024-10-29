using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Enums;
using TrigonometryLibrary.Exceptions.Result;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.CalculationArea.Triangle
{
    public class CalculateByTriangleHalfOfCathetus : CalculateAreaBehavior
    {
        public CalculateByTriangleHalfOfCathetus(double sideA, double sideB, double sideC)
        {
            var triangleType = TriangleValidator.DetermineTriangleType(sideA, sideB, sideC);
            if (triangleType != TriangleType.Rectangular)
                throw new NotARectangularTriangleException();

            var sidesArray = new double[] { sideA, sideB, sideC };
            Array.Sort(sidesArray);
            try
            {
                _area = NumberValidator.ValidatePositiveRange(0.5 * sidesArray[0] * sidesArray[1]);
            }
            catch(ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }
        }
    }
}
