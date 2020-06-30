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
using System.Threading;
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

        public async Task Processar(CancellationToken token)
        {
            var servicoDePopulacao = IoC.ObterServico<IServicoDePopulacao>();

            var temSolucao = false;

            var populacao = new Populacao(algoritimo.NumeroDeGenes, algoritimo.TamanhoDaPopulacao, algoritimo.Inicio);

            await servicoDePopulacao.CalculaAptidaoDaPopulacao(populacao);

            var melhorAptidao = 60;

            for (int i = 1; !temSolucao && i <= algoritimo.MaximoDeGeracoes && !token.IsCancellationRequested ; i++)
            {
                await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().IncrementarGeracao();

                populacao = await servicoDePopulacao.NovaGeracao(populacao);

                var melhorIndividuoLocal = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

                if(melhorIndividuoLocal.Aptidao == 0)
                {
                    temSolucao = true;
                }
                if(melhorAptidao > melhorIndividuoLocal.Aptidao)
                {
                    melhorAptidao = melhorIndividuoLocal.Aptidao;
                    await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().DefinirAptidao(melhorAptidao);
                    await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().DefineMelhorCaminho(melhorIndividuoLocal.Genes);
                }
            }

            var melhorIndividuo = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

            await IoC.ObterServico<IPonto>().DefinirLocalizacao(melhorIndividuo);
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().DefinirAptidao(melhorIndividuo.Aptidao);
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().DefineMelhorCaminho(melhorIndividuo.Genes);
            if (!token.IsCancellationRequested)
            {
                await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().FinalizaExecucao();
            }
        }
    }
}
