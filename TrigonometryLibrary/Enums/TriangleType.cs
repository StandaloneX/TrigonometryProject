namespace TrigonometryLibrary.Enums
{
    public enum TriangleType
    {
        /// <summary>
        /// Indicates that no triangle type is specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents a triangle that has passed only the triangle inequality test,
        /// indicating that it is a valid triangle but does not meet the criteria for 
        /// being rectangular or equilateral.
        /// </summary>
        Default = 1,

        /// <summary>
        /// Indicates that the triangle is rectangular (has one 90-degree angle).
        /// </summary>
        Rectangular = 2,

        /// <summary>
        /// Represents an equilateral triangle, where all sides are of equal length.
        /// </summary>
        Equilateral = 3
    }
}
