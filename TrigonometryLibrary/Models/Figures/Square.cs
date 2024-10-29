using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Interfaces.Figures;
using TrigonometryLibrary.Models.CalculationArea.Square;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.Figures
{
    public class Square : ISquare
    {
        private readonly CalculateAreaBehavior _calculateAreaBehavior;
        private readonly double _side;

        public Square(double side)
        {
            _side = NumberValidator.ValidatePositiveRange(side);
            _calculateAreaBehavior = new CalculateBySquareSide(_side);
        }

        public double CalculateArea()
        {
            return _calculateAreaBehavior.Area;
        }
    }
}
