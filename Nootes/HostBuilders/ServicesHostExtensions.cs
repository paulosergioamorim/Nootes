using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nootes.Services;
using Nootes.ViewModels;

namespace Nootes.HostBuilders
{
    public static partial class HostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices((
            hostContext,
            services) =>
        {
            services.AddSingleton<INavigateService<HomeViewModel>, NavigateService<HomeViewModel>>();

            services.AddSingleton<INavigateService<AddSubjectViewModel>, NavigateService<AddSubjectViewModel>>();

            string filePath = hostContext.Configuration.GetValue<string>("FilePath");

            if (!File.Exists(filePath))
            {
                using FileStream stream = File.Create(filePath);
            }

            services.AddSingleton<ISubjectService, SubjectService>(_ => new SubjectService(filePath));
        });
    }
}
