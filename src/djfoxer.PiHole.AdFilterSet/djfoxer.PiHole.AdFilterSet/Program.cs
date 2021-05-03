using djfoxer.PiHole.AdFilterSet.Checker;
using djfoxer.PiHole.AdFilterSet.Configure;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.set
{
    public class Program
    {
        static async Task<int> Main(string[] args)
        {
            var command = CommandLineFactory.Setup();
            command.Handler = CommandHandler.Create<string>(async (adPath) =>
            {
                using (var scope = ServiceProviderFactory.SetupScope())
                {
                    await scope.ServiceProvider.GetService<IAdFilterSetChecker>().ValidAndUpdate(adPath);
                }
            });


            return await command.InvokeAsync(args);
        }
    }
}
