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
        private readonly AlgoritimoGenetico _algoritimo;
        private readonly IServicoDeAtualizacaoDeInterface _servicoDeAtualizacaoDeInterface;
        private readonly IServicoDePopulacao _servicoDePopulacao;
        private readonly IPonto _ponto;

        public ServicoDeAlgoritimoGenetico(AlgoritimoGenetico algoritimo,
                                           IServicoDeAtualizacaoDeInterface servicoDeAtualizacaoDeInterface,
                                           IServicoDePopulacao servicoDePopulacao,
                                           IPonto ponto)
        {
            _algoritimo = algoritimo;
            _servicoDeAtualizacaoDeInterface = servicoDeAtualizacaoDeInterface;
            _servicoDePopulacao = servicoDePopulacao;
            _ponto = ponto;
        }

        public async Task Processar(CancellationToken token)
        {

            var temSolucao = false;

            var populacao = new Populacao(_algoritimo.NumeroDeGenes, _algoritimo.TamanhoDaPopulacao, _algoritimo.Inicio);

            await _servicoDePopulacao.CalculaAptidaoDaPopulacao(populacao);

            int? melhorAptidao = null;

            for (int i = 1; !temSolucao && i <= _algoritimo.MaximoDeGeracoes && !token.IsCancellationRequested ; i++)
            {
                await _servicoDeAtualizacaoDeInterface.IncrementarGeracao();

                populacao = await _servicoDePopulacao.NovaGeracao(populacao);

                var melhorIndividuoLocal = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

                await _servicoDeAtualizacaoDeInterface.DefinirMelhorAptidaoDaGeracao(melhorIndividuoLocal.Aptidao);
                await _servicoDeAtualizacaoDeInterface.DefineMelhorCaminhoDaGeracao(melhorIndividuoLocal.Genes);

                if (melhorIndividuoLocal.Localizacao == _algoritimo.Solucao)
                {
                    temSolucao = true;
                }
                if(melhorAptidao >= melhorIndividuoLocal.Aptidao || melhorAptidao == null)
                {
                    melhorAptidao = melhorIndividuoLocal.Aptidao;
                    await _servicoDeAtualizacaoDeInterface.DefinirMelhorAptidaoGeral(melhorAptidao.Value);
                    await _servicoDeAtualizacaoDeInterface.DefineMelhorCaminhoGeral(melhorIndividuoLocal.Genes);
                }
            }

            var melhorIndividuo = populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault();

            if (_ponto != null)
            {
                await _ponto.DefinirLocalizacao(melhorIndividuo);
                await _servicoDeAtualizacaoDeInterface.DefinirMelhorAptidaoGeral(melhorIndividuo.Aptidao);
                await _servicoDeAtualizacaoDeInterface.DefineMelhorCaminhoGeral(melhorIndividuo.Genes);
            }

            if (!token.IsCancellationRequested)
            {
                await _servicoDeAtualizacaoDeInterface.FinalizaExecucao();
            }
        }
    }
}
