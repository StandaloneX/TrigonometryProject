using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Interfaces.Figures;
using TrigonometryLibrary.Models.CalculationArea.Circle;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.Figures
{
    public class Circle : ICircle
    {
        private readonly CalculateAreaBehavior _calculateAreaBehavior;
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = NumberValidator.ValidatePositiveRange(radius);
            _calculateAreaBehavior = new CalculateByCircleRadius(radius);
        }

        public double CalculateArea()
        {
            return _calculateAreaBehavior.Area;
        }
    }
}
