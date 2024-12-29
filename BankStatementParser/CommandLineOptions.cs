using CommandLine;
using CommandLine.Text;

namespace BankStatementParser
{
    /// <summary>
    /// Represents the command line options of the application.
    /// </summary>
    internal class CommandLineOptions
    {
        /// <summary>
        /// Gets or sets the base path where to search for the bank statement files.
        /// </summary>
        [Option('p', "path", Required = true, DefaultValue = @"""C:\Users\MyName\My Documents\Finance\BankStatemens""", HelpText = "Defines the base path where all te bank statements are stored.")]
        public string BasePath { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var assemblyName = GetType().Assembly.GetName();
            var help = new HelpText()
            {
                Heading = new HeadingInfo(assemblyName.Name, assemblyName.Version.ToString()),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("GNU Affero General Public License");
            help.AddPreOptionsLine("Version 3, 19 November 2007");
            help.AddPreOptionsLine("Copyright © 2007 Free Software Foundation, Inc. <http://fsf.org/>");
            help.AddOptions(this);
            return help;
        }
    }
}
