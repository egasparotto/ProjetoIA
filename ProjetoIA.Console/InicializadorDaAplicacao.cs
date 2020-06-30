using Microsoft.Extensions.DependencyInjection;

using ProjetoIA.Dominio.Individuos.Servicos;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Penalidades.Servico;
using ProjetoIA.Dominio.Populacoes.Servicos;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;

namespace ProjetoIA.Console
{
    public static class InicializadorDaAplicacao
    {
        public static IServiceCollection Executar(this IServiceCollection services)
        {
            services.AddSingleton<IServicoDeAtualizacaoDeInterface, ServicoDeAtualizacaoDeInterface>();
            services.AddTransient<IServicoDeMovimentacaoDoIndividuo, ServicoDeMovimentacaoDoIndividuo>();
            services.AddTransient<IServicoDePenalidade, ServicoDePenalidade>();
            services.AddTransient<IServicoDeAlgoritimoGenetico, ServicoDeAlgoritimoGenetico>();
            services.AddTransient<IServicoDeIndividuo, ServicoDeIndividuo>();
            services.AddTransient<IServicoDePopulacao, ServicoDePopulacao>();

            services.AddSingleton<AlgoritimoGenetico>();

            return services;
        }
    }
}
