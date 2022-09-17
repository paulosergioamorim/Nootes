using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nootes.HostBuilders;
using Nootes.Services;
using Nootes.ViewModels;

namespace Nootes
{
    public partial class App
    {
        private readonly IHost _host;

        public App() => _host = Host.CreateDefaultBuilder()
                                    .AddViewModels()
                                    .AddFactories()
                                    .AddServices()
                                    .AddStores()
                                    .AddMainWindow()
                                    .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();

            _host.Services.GetRequiredService<INavigateService<HomeViewModel>>().Navigate();

            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
