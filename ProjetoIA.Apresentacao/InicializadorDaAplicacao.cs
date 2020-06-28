using Microsoft.Extensions.DependencyInjection;

using ProjetoIA.Apresentacao.Controllers;
using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Servicos;

namespace ProjetoIA.Apresentacao
{
    public static class InicializadorDaAplicacao
    {
        public static IServiceCollection Executar(this IServiceCollection services)
        {
            services.AddTransient<IServicoDeAtualizacaoDeInterface, ServicoDeAtualizacaoDeInterface>();
            services.AddTransient<IServicoDeMovimentacaoDoPonto, ServicoDeMovimentacaoDoPonto>();
            services.AddSingleton<InformacoesDaTela>();
            return services;
        }
    }
}
