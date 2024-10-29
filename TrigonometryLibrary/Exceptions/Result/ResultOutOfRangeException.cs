using TrigonometryLibrary.Constants;

namespace TrigonometryLibrary.Exceptions.Result
{
    public class ResultOutOfRangeException : Exception
    {
        public ResultOutOfRangeException(string message = DefaultExceptionMessage.ResultOutOfRange) : base(message) { }
    }
}
