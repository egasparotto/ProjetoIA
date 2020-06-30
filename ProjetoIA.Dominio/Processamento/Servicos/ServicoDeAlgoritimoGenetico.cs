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
        private IServicoDeAtualizacaoDeInterface servicoDeAtualizacaoDeInterface;

        public ServicoDeAlgoritimoGenetico(AlgoritimoGenetico algoritimo, IServicoDeAtualizacaoDeInterface servicoDeAtualizacaoDeInterface)
        {
            this.algoritimo = algoritimo;
            this.servicoDeAtualizacaoDeInterface = servicoDeAtualizacaoDeInterface;
        }

        public async Task Processar(CancellationToken token)
        {
            var servicoDePopulacao = IoC.ObterServico<IServicoDePopulacao>();

            var temSolucao = false;

            var populacao = new Populacao(algoritimo.NumeroDeGenes, algoritimo.TamanhoDaPopulacao, algoritimo.Inicio);

            await servicoDePopulacao.CalculaAptidaoDaPopulacao(populacao);

            int? melhorAptidao = null;

            for (int i = 1; !temSolucao && i <= algoritimo.MaximoDeGeracoes && !token.IsCancellationRequested ; i++)
            {
                await servicoDeAtualizacaoDeInterface.IncrementarGeracao();

                populacao = await servicoDePopulacao.NovaGeracao(populacao);

                var melhorIndividuoLocal = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

                await servicoDeAtualizacaoDeInterface.DefinirMelhorAptidaoDaGeracao(melhorIndividuoLocal.Aptidao);
                await servicoDeAtualizacaoDeInterface.DefineMelhorCaminhoDaGeracao(melhorIndividuoLocal.Genes);

                if (melhorIndividuoLocal.Localizacao == algoritimo.Solucao)
                {
                    temSolucao = true;
                }
                if(melhorAptidao >= melhorIndividuoLocal.Aptidao || melhorAptidao == null)
                {
                    melhorAptidao = melhorIndividuoLocal.Aptidao;
                    await servicoDeAtualizacaoDeInterface.DefinirMelhorAptidaoGeral(melhorAptidao.Value);
                    await servicoDeAtualizacaoDeInterface.DefineMelhorCaminhoGeral(melhorIndividuoLocal.Genes);
                }
            }

            var melhorIndividuo = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

            var ponto = IoC.ObterServico<IPonto>();
            if (ponto != null)
            {
                await ponto.DefinirLocalizacao(melhorIndividuo);
                await servicoDeAtualizacaoDeInterface.DefinirMelhorAptidaoGeral(melhorIndividuo.Aptidao);
                await servicoDeAtualizacaoDeInterface.DefineMelhorCaminhoGeral(melhorIndividuo.Genes);
            }

            if (!token.IsCancellationRequested)
            {
                await servicoDeAtualizacaoDeInterface.FinalizaExecucao();
            }
        }
    }
}
