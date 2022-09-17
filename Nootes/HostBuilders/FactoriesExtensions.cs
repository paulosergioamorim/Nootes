using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nootes.ViewModels;

namespace Nootes.HostBuilders
{
    public static partial class HostBuilderExtensions
    {
        public static IHostBuilder AddFactories(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices(
            services =>
            {
                services.AddSingleton<Func<HomeViewModel>>(s => s.GetRequiredService<HomeViewModel>);
                services.AddSingleton<Func<AddSubjectViewModel>>(s => s.GetRequiredService<AddSubjectViewModel>);
            });
    }
}
