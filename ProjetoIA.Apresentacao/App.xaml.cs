using Microsoft.Extensions.DependencyInjection;

using ProjetoIA.Dominio.Base;

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

            IoC.ServiceProvider = serviceCollection.BuildServiceProvider();

            IoC.ObterServico<MainWindow>().Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.Executar();
            services.AddSingleton(typeof(MainWindow));
        }
    }
}
