using TrigonometryLibrary.Constants;

namespace TrigonometryLibrary.Exceptions.Triangle
{
    public class NotAEquilateralTriangleException : Exception
    {
        public NotAEquilateralTriangleException(string message = DefaultExceptionMessage.NotAEquilateralTriangle) : base(message) { }
    }
}
