using BankStatementParser.Interface;
using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text;
using System.Text.RegularExpressions;
using BankStatementParser.Utilities;
using BankStatementParser.Data;

namespace BankStatementParser.Parsers.Mlp
{
    internal class MlpIBANParser
    {
        private const float IBANLowerLeftXCm = 11.5f;
        private const float IBANLowerLeftYCm = 22.2f;
        private const float IBANUpperLeftXCm = 21f;
        private const float IBANUpperLeftYCm = 23.5f;
        private static readonly Regex ibanRegex = new Regex(".*IBAN:.*([A-Z]{2}[0-9 ]+)BIC: MLPBDE61.*", RegexOptions.Compiled);

        public MlpIBANParser(PdfReader reader)
        {

        }


    }
    /// <summary>
    /// <see cref="IPageParser"/> implementation for MLP bank statements.
    /// </summary>
    /// <seealso cref="IPageParser" />
    internal class MlpPageParser : IPageParser
    {
        private const float PageHeightCm = 29.7f;
        private const float PageWidthCm = 21;
        private const float PageHeightPdf = 840;
        private const float PageWidthPdf = 597.6f;

        private const float IBANLowerLeftXCm = 11.5f;
        private const float IBANLowerLeftYCm = 22.2f;
        private const float IBANUpperLeftXCm = 21f;
        private const float IBANUpperLeftYCm = 23.5f;

        private static readonly float horizontalCmFactor = (PageWidthPdf / PageWidthCm);
        private static readonly float verticalCmFactor = (PageHeightPdf / PageHeightCm);

        private static readonly Rectangle ibanRectangle = new Rectangle(
            horizontalCmFactor * IBANLowerLeftXCm,
            verticalCmFactor * IBANLowerLeftYCm,
            horizontalCmFactor * IBANUpperLeftXCm,
            verticalCmFactor * IBANUpperLeftYCm);
        private static readonly RegionTextRenderFilter ibanRegionFilter = new RegionTextRenderFilter(ibanRectangle);
        private static readonly FilteredTextRenderListener ibanFilteredReader = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), ibanRegionFilter);
        private static readonly Regex ibanRegex = new Regex(".*IBAN:.*([A-Z]{2}[0-9 ]+)BIC: MLPBDE61.*", RegexOptions.Compiled);

        private readonly PdfReader _reader;
        private readonly BankStatement _result = new BankStatement();
        private readonly RectangleConverter _rectConverter;
        private bool _done;

        /// <summary>
        /// Initializes a new instance of the <see cref="MlpPageParser"/> class.
        /// </summary>
        /// <param name="reader">The PDF reader.</param>
        public MlpPageParser(PdfReader reader)
        {
            _reader = reader;
            _rectConverter = new RectangleConverter(21, 29.7f);
        }
        
        /// <summary>
        /// Parses the page.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="page">The page.</param>
        /// <returns><c>true</c> to continue parsing next page; <c>false</c> to stop parsing.</returns>
        public bool ParsePage(int pageNumber)
        {
            if (_done)
                throw new InvalidOperationException("Already finished parsing! Create a new parser.");

            if (pageNumber == 1)
            {
                ParseIBAN();
            }

            _done = true;
            return true;
        }

        /// <summary>
        /// Gets parsed data.
        /// </summary>
        /// <remarks>
        /// This method must not be called before <see cref="ParsePage(int, PdfDictionary)"/> did not return <c>false</c>.
        /// </remarks>
        /// <returns>The parsed data.</returns>
        public BankStatement GetResult()
        {
            if (!_done)
                throw new InvalidOperationException("Parsing not finished!");

            return _result;
        }

        /// <summary>
        /// Parses the IBAN.
        /// </summary>
        private void ParseIBAN()
        {
            
            var pageSize = _reader.GetPageSize(1);

            var text = PdfTextExtractor.GetTextFromPage(_reader, 1, ibanFilteredReader);
            var lines = text.Split('\n');
            foreach (var line in lines)
            {
                var matchResult = ibanRegex.Match(line);
                if (!matchResult.Success)
                    continue;

                var iban = matchResult.Groups[1].Value;
                var ibanPacked = iban.Replace(" ", "");
                if (ibanPacked.Length != 22)
                    throw new BankStatementParserException("Parsed IBAN '" + iban + "' does not have the length of 22 (without whitespaces).");
                _result.IBAN = ibanPacked;
                return;
            }
            throw new BankStatementParserException("Cannot parse IBAN from MLP string:" + Environment.NewLine + text);
        }
    }
}
