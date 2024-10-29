using TrigonometryLibrary.Constants;

namespace TrigonometryLibrary.Exceptions.Triangle
{
    public class NotARectangularTriangleException : Exception
    {
        public NotARectangularTriangleException(string message = DefaultExceptionMessage.NotARectangularTriangle) : base(message) { }
    }
}
