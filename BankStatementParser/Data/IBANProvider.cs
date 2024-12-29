namespace BankStatementParser.Data
{
    /// <summary>
    /// Exposes properties and methods of an IBAN provider.
    /// </summary>
    public interface IBANProvider
    {
        /// <summary>
        /// Gets the pefix of the concrete IBAN. It represents the country code (e.g. DE = german).
        /// </summary>
        string Pefix { get; }

        /// <summary>
        /// Creates the specified IBAN.
        /// </summary>
        /// <param name="iban">The string representation of the IBAN.</param>
        /// <returns>The IBAN.</returns>
        IBAN Create(string iban);
    }
}
