using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nootes.ViewModels;

namespace Nootes.HostBuilders
{
    public static partial class HostBuilderExtensions
    {
        public static IHostBuilder AddMainWindow(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices(
            services => services.AddSingleton(s =>
                new MainWindow { DataContext = s.GetRequiredService<MainViewModel>() }));
    }
}
