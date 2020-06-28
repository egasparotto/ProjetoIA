using Microsoft.Extensions.DependencyInjection;

using ProjetoIA.Dominio.Servicos;

using System.Windows;
using System.Windows.Navigation;

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
