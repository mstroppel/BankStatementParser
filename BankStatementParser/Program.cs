using BankStatementParser.Parsers;
using CommandLine;
using Serilog;

namespace BankStatementParser
{
    /// <summary>
    /// Contains the main entry point of the application.
    /// </summary>
    public class Program
    {
        private static readonly ILogger _logger = new LoggerConfiguration()
            .WriteTo.ColoredConsole()
            .CreateLogger();

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns><c>0</c> on successful execution; otherwise a value defined in <see cref="ReturnCodes"/>.</returns>
        public static int Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (!Parser.Default.ParseArguments(args, options))
                return (int)ReturnCodes.CommandLineOptionsFailed;

            var fileName = @"D:\Sonstiges\Finanzen\MLP\09-Kontoauszuege\CampusGirokonto_4012342151\2017\4012342151_2017_Nr.007_Kontoauszug_vom_01.07.2017_20170704045235.pdf";
            var file = new MlpBankStatementParser();
            var result = file.Parse(fileName);
            

            return (int)ReturnCodes.Success;
        }
    }
}
