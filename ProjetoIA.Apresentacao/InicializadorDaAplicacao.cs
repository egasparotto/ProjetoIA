using Microsoft.Extensions.DependencyInjection;

using ProjetoIA.Apresentacao.Controllers;
using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Interfaces;

namespace ProjetoIA.Apresentacao
{
    public static class InicializadorDaAplicacao
    {
        public static IServiceCollection Executar(this IServiceCollection services)
        {
            services.AddTransient<IServicoDeAtualizacaoDeInterface, ServicoDeAtualizacaoDeInterface>();
            services.AddSingleton<InformacoesDaTela>();
            return services;
        }
    }
}
