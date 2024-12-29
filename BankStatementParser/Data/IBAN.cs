using System;

namespace BankStatementParser.Data
{
    /// <summary>
    /// Base class for all IBAN implementations.
    /// </summary>
    public abstract class IBAN
    {
        /// <summary>
        /// Creates the IBAN object from the passed string.
        /// </summary>
        /// <param name="iban">The IBAN as string.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Country code of IBAN '" + iban + "' not supported.</exception>
        public static IBAN Create(string iban)
        {
            var withoutWhitespaces = iban.Replace(" ", "").Trim();
            // The logic inside this class can later by replaced by e.g. dependency injection of the
            // available IBAN implementations.
            if (iban.StartsWith("DE"))
                return new GermanIBAN(withoutWhitespaces);

            throw new NotImplementedException("Country code of IBAN '" + iban + "' not supported.");
        }

        /// <summary>
        /// Gets or sets the full IBAN value without whitespaces (e.g. DExxbbbbbbbbaaaaaaaaaa).
        /// </summary>
        public string Value { get; protected set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; protected set; }

        /// <summary>
        /// Gets or sets the check digits.
        /// </summary>
        public string CheckDigits { get; protected set; }

        /// <summary>
        /// Gets or sets the national bank code.
        /// </summary>
        public string BankCode { get; protected set; }

        /// <summary>
        /// Gets or sets the bank account number.
        /// </summary>
        public string BankAccountNumber { get; protected set; }
    }
}
