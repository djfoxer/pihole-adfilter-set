using djfoxer.PiHole.AdFilterSet.Checker;
using djfoxer.PiHole.AdFilterSet.Configure;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace djfoxer.PiHole.AdFilterSet.set
{
    public class Program
    {
        static async Task<int> Main(string[] args) =>
            await CommandLineFactory.Setup(args, CheckAdFilterSet);

        public static async Task<bool> CheckAdFilterSet(string adPath, bool cleanFile)
        {
            using var scope = ServiceProviderFactory.SetupScope();
            return await scope.ServiceProvider.GetService<IAdFilterSetChecker>().CheckAdFilterSet(adPath, cleanFile);
        }
    }
}
