using TrigonometryLibrary.Constants;

namespace TrigonometryLibrary.Exceptions.Triangle
{
    public class NotATriangleException : Exception
    {
        public NotATriangleException(string message = DefaultExceptionMessage.NotATriangle) : base(message) { }
    }
}
