using TrigonometryLibrary.Enums;
using TrigonometryLibrary.Exceptions.Result;

namespace TrigonometryLibrary.Validators
{
    public static class TriangleValidator
    {
        public static TriangleType DetermineTriangleType(double sideA, double sideB, double sideC)
        {
            if (IsTriangle(sideA, sideB, sideC) is not true)
            {
                return TriangleType.None;
            }
            if (IsEquilateral(sideA, sideB, sideC) is true)
            {
                return TriangleType.Equilateral;
            }
            if (IsRectangular(sideA, sideB, sideC) is true)
            {
                return TriangleType.Rectangular;
            }

            return TriangleType.Default;
        }

        private static bool IsTriangle(double sideA, double sideB, double sideC)
        {
            NumberValidator.ValidatePositiveRange(sideA);
            NumberValidator.ValidatePositiveRange(sideB);
            NumberValidator.ValidatePositiveRange(sideC);

            try
            {
                if (NumberValidator.ValidatePositiveRange(sideA + sideB) < sideC) return false;
                if (NumberValidator.ValidatePositiveRange(sideB + sideC) < sideA) return false;
                if (NumberValidator.ValidatePositiveRange(sideC + sideA) < sideB) return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }

            return true;
        }

        private static bool IsRectangular(double sideA, double sideB, double sideC)
        {
            try
            {
                var squareSideA = NumberValidator.ValidatePositiveRange(Math.Pow(sideA, 2.0));
                var squareSideB = NumberValidator.ValidatePositiveRange(Math.Pow(sideB, 2.0));
                var squareSideC = NumberValidator.ValidatePositiveRange(Math.Pow(sideC, 2.0));

                if (NumberValidator.ValidatePositiveRange(squareSideA + squareSideB) == squareSideC) return true;
                if (NumberValidator.ValidatePositiveRange(squareSideB + squareSideC) == squareSideA) return true;
                if (NumberValidator.ValidatePositiveRange(squareSideC + squareSideA) == squareSideB) return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ResultOutOfRangeException();
            }

            return false;
        }

        private static bool IsEquilateral(double sideA, double sideB, double sideC)
        {
            return sideA == sideB && sideB == sideC;
        }
    }
}
