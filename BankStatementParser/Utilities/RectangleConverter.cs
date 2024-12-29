using iTextSharp.text;

namespace BankStatementParser.Utilities
{
    /// <summary>
    /// This class can be use to convert a <see cref="Rectangle"/> in one unit (e.g. cm) to
    /// a <see cref="Rectangle"/> in another unit (e.g. of a PDF page).
    /// </summary>
    public class RectangleConverter
    {
        private readonly LengthConverter _widthConverter;
        private readonly LengthConverter _heightConvert;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleConverter"/> class.
        /// </summary>
        /// <param name="totalWidthUnit1">The total width in the unit 1.</param>
        /// <param name="totalHeightUnit1">The total height in unit 1.</param>
        public RectangleConverter(float totalWidthUnit1, float totalHeightUnit1)
        {
            _widthConverter = new LengthConverter(totalWidthUnit1);
            _heightConvert = new LengthConverter(totalHeightUnit1);
        }

        /// <summary>
        /// Converts the rectangle defined by <paramref name="llxUnit1"/>, <paramref name="llyUnit1"/>, <paramref name="urxUnit1"/>
        /// and <paramref name="uryUnit1"/> into unit 2 by the measurement of <paramref name="rectangleUnit2"/>.
        /// </summary>
        /// <param name="rectangleUnit2">The rectangle with the total lenghts in unit 2.</param>
        /// <param name="llxUnit1">The lower left x in unit 1.</param>
        /// <param name="llyUnit1">The lower left y in unit 1.</param>
        /// <param name="urxUnit1">The upper right x in unit 1.</param>
        /// <param name="uryUnit1">The upper right y in unit 1.</param>
        /// <returns></returns>
        public Rectangle Convert(Rectangle rectangleUnit2, float llxUnit1, float llyUnit1, float urxUnit1, float uryUnit1)
        {
            return new Rectangle(
                _widthConverter.Convert(rectangleUnit2.Width, llxUnit1),
                _heightConvert.Convert(rectangleUnit2.Height, llyUnit1),
                _widthConverter.Convert(rectangleUnit2.Width, urxUnit1),
                _heightConvert.Convert(rectangleUnit2.Height, uryUnit1));
        }
    }
}
