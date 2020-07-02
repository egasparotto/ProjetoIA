using Microsoft.Extensions.DependencyInjection;

using System.Windows;

namespace ProjetoIA.Apresentacao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var provider = serviceCollection.BuildServiceProvider();

            provider.GetService<MainWindow>().Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.Executar();
        }
    }
}
