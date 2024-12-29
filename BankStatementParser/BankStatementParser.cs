using BankStatementParser.Data;
using BankStatementParser.Interface;
using iTextSharp.text.pdf;
using System.IO;

namespace BankStatementParser
{

    /// <summary>
    /// Base class for a parser of bank statements that go page by page.
    /// </summary>
    public abstract class BankStatementByPageParser
    {
        /// <summary>
        /// Parses the file.
        /// </summary>
        /// <returns><c>true</c> if successfully parsed; otherwise <c>false</c>.</returns>
        public BankStatement Parse(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Cannot find file.", path);

            using (var reader = new PdfReader(path))
            {
                var parser = CreatePageParser(reader);

                for (var i = 1; i <= reader.NumberOfPages; ++i)
                {
                    parser.ParsePage(i);
                    if (!parser.ParsePage(i))
                        break;
                }

                // This will throw the exception when not yet finished with parsing.
                return parser.GetResult();
            }
        }

        /// <summary>
        /// Gets the name of the parser.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Creates the page parser.
        /// </summary>
        /// <returns>The page parser.</returns>
        protected abstract IPageParser CreatePageParser(PdfReader reader);
    }
}
