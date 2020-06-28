using Microsoft.Extensions.DependencyInjection;

using ProjetoIA.Apresentacao.Controllers;
using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Individuos.Servicos;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Penalidades.Servico;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Populacoes.Servicos;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;

namespace ProjetoIA.Apresentacao
{
    public static class InicializadorDaAplicacao
    {
        public static IServiceCollection Executar(this IServiceCollection services)
        {
            services.AddTransient<IServicoDeAtualizacaoDeInterface, ServicoDeAtualizacaoDeInterface>();
            services.AddTransient<IServicoDeMovimentacaoDoIndividuo, ServicoDeMovimentacaoDoIndividuo>();
            services.AddTransient<IServicoDePenalidade, ServicoDePenalidade>();
            services.AddTransient<IServicoDeAlgoritimoGenetico, ServicoDeAlgoritimoGenetico>();
            services.AddTransient<IServicoDeIndividuo, ServicoDeIndividuo>();
            services.AddTransient<IServicoDePopulacao, ServicoDePopulacao>();

            services.AddSingleton<IPonto, Ponto>();
            services.AddSingleton<InformacoesDaTela>();
            services.AddSingleton<AlgoritimoGenetico>();

            return services;
        }
    }
}
