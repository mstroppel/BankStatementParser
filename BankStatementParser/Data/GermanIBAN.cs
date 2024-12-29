using System;

namespace BankStatementParser.Data
{
    /// <summary>
    /// Implements a German <see cref="IBAN"/>.
    /// </summary>
    /// <seealso cref="IBAN" />
    internal class GermanIBAN : IBAN
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GermanIBAN"/> class.
        /// </summary>
        /// <param name="ibanWithoutWhitespaces">The IBAN without whitespaces.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="ibanWithoutWhitespaces"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="ibanWithoutWhitespaces"/> dose not start with 'DE' and or has a different length than 22.</exception>
        public GermanIBAN(string ibanWithoutWhitespaces)
        {
            if (ibanWithoutWhitespaces == null)
                throw new ArgumentNullException("iban");

            if (!ibanWithoutWhitespaces.StartsWith("DE") || ibanWithoutWhitespaces.Length != 22)
                throw new ArgumentException("A German IBAN must start with 'DE' and have the length of 22. Provided value'" + ibanWithoutWhitespaces + "'");

            Value = ibanWithoutWhitespaces;
            CountryCode = ibanWithoutWhitespaces.Substring(0, 2);
            CheckDigits = ibanWithoutWhitespaces.Substring(2, 2);
            BankCode = ibanWithoutWhitespaces.Substring(4, 8);
            BankAccountNumber = ibanWithoutWhitespaces.Substring(12);
        }
    }
}
