using System;

namespace BankStatementParser
{
    /// <summary>
    /// An exception that is thrown by the bank statement parser.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class BankStatementParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementParserException"/> class.
        /// </summary>
        public BankStatementParserException(string message)
            : base(message)
        {

        }
    }
}
