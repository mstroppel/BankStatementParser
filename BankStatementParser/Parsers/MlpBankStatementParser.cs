using iTextSharp.text.pdf;
using BankStatementParser.Interface;
using BankStatementParser.Parsers.Mlp;

namespace BankStatementParser.Parsers
{
    /// <summary>
    /// Represents a parser that parses MLP bank statements.
    /// </summary>
    /// <seealso cref="BankStatementByPageParser.BankStatementByPageParser" />
    public class MlpBankStatementParser : BankStatementByPageParser
    {
        /// <summary>
        /// Gets the name of the parser.
        /// </summary>
        public override string Name => "MLP";

        /// <summary>
        /// Creates the page parser.
        /// </summary>
        /// <param name="bankStatement">The bank statement.</param>
        /// <returns>The page parser.</returns>
        protected override IPageParser CreatePageParser(PdfReader reader)
        {
            return new MlpPageParser(reader);
        }
    }
}
