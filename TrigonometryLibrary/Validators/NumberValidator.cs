namespace TrigonometryLibrary.Validators
{
    public static class NumberValidator
    {
        public static double ValidatePositiveRange(double number)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(number, double.NegativeZero);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(number, double.MaxValue);

            return number;
        }
    }
}
