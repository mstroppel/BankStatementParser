using System;

namespace BankStatementParser.Data
{
    /// <summary>
    /// Represents the data of a parsed bank statement.
    /// </summary>
    public class BankStatement
    {
        /// <summary>
        /// Gets the IBAN.
        /// </summary>
        public IBAN IBAN { get; internal set; }
    }
}
