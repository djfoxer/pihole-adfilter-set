using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.Configure
{
    public static class CommandLineFactory
    {
        public static async Task<int> Setup(string[] args, Func<string, bool, Task<bool>> handler)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(
                   alias: "--ad-path",
                   description: "Path to file with Ad lists")
                {
                    IsRequired = true
                },
                new Option<bool>(
                   alias: "--clean-file",
                   getDefaultValue: () => false,
                   description: "Remove bad (incorrect format, missing data) and duplicated urls")
                {
                    IsRequired = true
                },
            };

            rootCommand.Description = "Checks filter sets in file and removes invalid entries";

            rootCommand.Handler = CommandHandler.Create(handler);

            return await rootCommand.InvokeAsync(args);
        }
    }
}
