using BankStatementParser.Data;
using iTextSharp.text.pdf;

namespace BankStatementParser.Interface
{
    /// <summary>
    /// Exposes methods for a parser that parses page by page.
    /// </summary>
    public interface IPageParser
    {
        /// <summary>
        /// Parses the page.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <returns><c>true</c> to continue parsing next page; <c>false</c> to stop parsing.</returns>
        bool ParsePage(int pageNumber);

        /// <summary>
        /// Gets parsed data.
        /// </summary>
        /// <remarks>
        /// This method must not be called before <see cref="ParsePage(int, PdfDictionary)"/> did not return <c>false</c>.
        /// </remarks>
        /// <returns>The parsed data.</returns>
        BankStatement GetResult();
    }
}
