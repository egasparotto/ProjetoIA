using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Populacoes.Entidades;
using ProjetoIA.Dominio.Populacoes.Servicos;
using ProjetoIA.Dominio.Processamento.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Processamento.Servicos
{
    public class ServicoDeAlgoritimoGenetico : IServicoDeAlgoritimoGenetico
    {
        private readonly AlgoritimoGenetico algoritimo;

        public ServicoDeAlgoritimoGenetico(AlgoritimoGenetico algoritimo)
        {
            this.algoritimo = algoritimo;
        }

        public async Task Processar()
        {
            var servicoDePopulacao = IoC.ObterServico<IServicoDePopulacao>();

            var temSolucao = false;

            var populacao = new Populacao(algoritimo.NumeroDeGenes, algoritimo.TamanhoDaPopulacao, algoritimo.Inicio);

            await servicoDePopulacao.CalculaAptidaoDaPopulacao(populacao);

            var melhorAptidao = 60;

            for (int i = 1; !temSolucao && i <= algoritimo.MaximoDeGeracoes; i++)
            {
                await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().IncrementarGeracao();

                populacao = await servicoDePopulacao.NovaGeracao(populacao);

                var aptidao = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault().Aptidao;

                if(aptidao == 0)
                {
                    temSolucao = true;
                }
                if(melhorAptidao > aptidao)
                {
                    melhorAptidao = aptidao;
                    await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().DefinirAptidao(melhorAptidao);
                }
            }

            var melhorIndividuo = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

            await IoC.ObterServico<IPonto>().DefinirLocalizacao(melhorIndividuo);
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().DefinirAptidao(melhorIndividuo.Aptidao);
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().FinalizaExecucao();
        }
    }
}
