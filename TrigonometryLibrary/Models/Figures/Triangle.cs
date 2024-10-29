using TrigonometryLibrary.Abstractions;
using TrigonometryLibrary.Enums;
using TrigonometryLibrary.Exceptions.Triangle;
using TrigonometryLibrary.Interfaces.Figures;
using TrigonometryLibrary.Models.CalculationArea.Triangle;
using TrigonometryLibrary.Validators;

namespace TrigonometryLibrary.Models.Figures
{
    public class Triangle : ITriangle
    {
        private readonly CalculateAreaBehavior _calculateAreaBehavior;
        private readonly TriangleType _type = TriangleType.None;
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public Triangle(double sideA, double sideB, double sideC) 
        {
            _type = TriangleValidator.DetermineTriangleType(sideA, sideB, sideC);
            if (_type == TriangleType.None)
            {
                throw new NotATriangleException();
            }

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;

            _calculateAreaBehavior = _type switch
            {
                TriangleType.Default => new CalculateByTriangleThreeSides(sideA, sideB, sideC),
                TriangleType.Rectangular => new CalculateByTriangleHalfOfCathetus(sideA, sideB, sideC),
                TriangleType.Equilateral => new CalculateByTriangleSide(sideA, sideB, sideC),
                _ => throw new ArgumentException(),
            };
        }

        public double CalculateArea()
        {
            return _calculateAreaBehavior.Area;
        }
    }
}
