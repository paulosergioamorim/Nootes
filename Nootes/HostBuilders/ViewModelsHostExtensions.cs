using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nootes.ViewModels;

namespace Nootes.HostBuilders
{
    public static partial class HostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices(
            services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<AddSubjectViewModel>();
            });
    }
}
