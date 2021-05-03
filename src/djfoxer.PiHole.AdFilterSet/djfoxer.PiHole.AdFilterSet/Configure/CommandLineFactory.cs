using System.CommandLine;

namespace djfoxer.PiHole.AdFilterSet.Configure
{
    public static class CommandLineFactory
    {
        public static RootCommand Setup()
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(
                   alias: "--ad-path",
                   description: "Path to file with Ad lists")
                {
                    IsRequired = true
                }
            };

            rootCommand.Description = "Checks filter sets in file and removes invalid entries";

            return rootCommand;
        }
    }
}
