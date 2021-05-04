using djfoxer.PiHole.AdFilterSet.Checker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace djfoxer.PiHole.AdFilterSet.Configure
{
    public class ServiceProviderFactory : IDisposable
    {
        private ServiceProviderFactory() =>
            ServiceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddConsole())
            .AddSingleton<IAdFilterSetChecker, AdFilterSetChecker>()
            .AddHttpClient()
            .BuildServiceProvider();

        private static ServiceProviderFactory _serviceProviderFactory;

        public IServiceProvider ServiceProvider { get; private set; }

        public static IServiceScope SetupScope() =>
            (_serviceProviderFactory ??= new ServiceProviderFactory())
                 .ServiceProvider.CreateScope();

        public void Dispose() =>
            ((IDisposable)ServiceProvider)?.Dispose();
    }
}
