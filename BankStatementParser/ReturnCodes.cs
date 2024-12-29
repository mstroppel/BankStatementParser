namespace BankStatementParser
{
    /// <summary>
    /// Defines the return values of the application.
    /// </summary>
    public enum ReturnCodes
    {
        /// <summary>
        /// Application successfully exited.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Parsing the command line options failed. See console output for more details
        /// </summary>
        CommandLineOptionsFailed = 1
    }
}
