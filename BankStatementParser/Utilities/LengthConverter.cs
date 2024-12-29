namespace BankStatementParser.Utilities
{
    /// <summary>
    /// This class can be used to convert from a length in one unit (e.g. cm) to the
    /// lenght in another unit (e.g. of a PDF page.)
    /// </summary>
    public class LengthConverter
    {
        private readonly float _totalLengthUnit1;

        /// <summary>
        /// Initializes a new instance of the <see cref="LengthConverter"/> class.
        /// </summary>
        /// <param name="totalLengthUnit1">The total length in unit 1 (e.g. the page width in cm).</param>
        public LengthConverter(float totalLengthUnit1)
        {
            _totalLengthUnit1 = totalLengthUnit1;
        }

        /// <summary>
        /// Converts the length in unit 1 to the length in unit 2.
        /// </summary>
        /// <param name="totalLengthUnit2">The total length in unit 2 (e.g. the page width of a PDF page).</param>
        /// <param name="lengthUnit1">The length unit 1 to convert.</param>
        /// <returns>The length of <paramref name="lengthUnit1"/> in unit 2.</returns>
        public float Convert(float totalLengthUnit2, float lengthUnit1)
        {
            return (totalLengthUnit2 / _totalLengthUnit1) + lengthUnit1;
        }
    }
}
