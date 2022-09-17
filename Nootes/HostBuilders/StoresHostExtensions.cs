using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nootes.Stores;

namespace Nootes.HostBuilders
{
    public static partial class HostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<INavigationStore, NavigationStore>();
            services.AddSingleton<ISubjectsStore, SubjectsStore>();
        });
    }
}
