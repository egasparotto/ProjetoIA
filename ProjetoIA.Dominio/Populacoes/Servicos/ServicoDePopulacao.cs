using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Servicos;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Populacoes.Entidades;
using ProjetoIA.Dominio.Processamento.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Populacoes.Servicos
{
    public class ServicoDePopulacao : IServicoDePopulacao
    {
        private readonly AlgoritimoGenetico _algoritimo;
        private readonly IServicoDeIndividuo _servicoDeIndividuo;

        public ServicoDePopulacao(AlgoritimoGenetico algoritimo, IServicoDeIndividuo servicoDeIndividuo)
        {
            _algoritimo = algoritimo;
            _servicoDeIndividuo = servicoDeIndividuo;
        }

        public async Task<Populacao> NovaGeracao(Populacao populacao)
        {
            var tamanhoPopulacao = populacao.TamanhoDaPopulacao;
            var novaPopulacao = new Populacao();

            if (_algoritimo.Elitismo)
            {
                novaPopulacao.Individuos.Add(populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault());
            }

            while (novaPopulacao.TamanhoDaPopulacao < tamanhoPopulacao)
            {
                var pais = SelecaoPorTorneio(populacao);

                if (new Random().NextDouble() <= (double)_algoritimo.TaxaDeCrossover)
                {
                    novaPopulacao.Individuos.Add(Crossover(pais[0], pais[1]));
                }
                else
                {
                    novaPopulacao.Individuos.Add(new Individuo(pais[0].Genes, _algoritimo.Inicio, _algoritimo.TaxaDeMutacao));
                    novaPopulacao.Individuos.Add(new Individuo(pais[1].Genes, _algoritimo.Inicio, _algoritimo.TaxaDeMutacao));
                }
            }

            await CalculaAptidaoDaPopulacao(novaPopulacao);

            return novaPopulacao;
        }

        public async Task CalculaAptidaoDaPopulacao(Populacao populacao)
        {
            foreach (var individuo in populacao.Individuos)
            {
                await _servicoDeIndividuo.CalcularAptidao(individuo);
            }
        }

        private Individuo[] SelecaoPorTorneio(Populacao populacao)
        {
            IList<Individuo> individuos = new List<Individuo>()
            {
                ObterIndividuoAleatorio(populacao),
                ObterIndividuoAleatorio(populacao),
                ObterIndividuoAleatorio(populacao)
            };

            return individuos.OrderBy(x => x.Aptidao).Take(2).ToArray();
        }


        private Individuo ObterIndividuoAleatorio(Populacao populacao)
        {
            Random rndElement = new Random();
            int index;
            if (populacao.Individuos.Count > 1)
            {
                index = rndElement.Next(0, populacao.Individuos.Count - 1);
                return populacao.Individuos[index];
            }
            else
            {
                return null;
            }
        }

        private Individuo Crossover(Individuo individuo1, Individuo individuo2)
        {
            var pontosDeCorte = GeraPontosDeCorteRandomicos();

            pontosDeCorte.Add(6);

            List<EnumeradorDeMovimentoDoIndividuo> genes = new List<EnumeradorDeMovimentoDoIndividuo>();
            var ultimoIndivuo = 2;
            var registrosInseridos = 0;
            foreach (var ponto in pontosDeCorte)
            {
                IEnumerable<EnumeradorDeMovimentoDoIndividuo> genesInseridos;
                if(ultimoIndivuo == 2)
                {
                    genesInseridos = individuo1.Genes.Skip(registrosInseridos).Take(ponto - registrosInseridos);
                    ultimoIndivuo = 1;
                }
                else
                {
                    genesInseridos = individuo2.Genes.Skip(registrosInseridos).Take(ponto - registrosInseridos);
                    ultimoIndivuo = 2;
                }
                registrosInseridos += genesInseridos.Count();
                genes.AddRange(genesInseridos);
            }

            return new Individuo(genes, _algoritimo.Inicio, _algoritimo.TaxaDeMutacao);
        }

        private IList<int> GeraPontosDeCorteRandomicos()
        {
            var rnd = new Random();
            return Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).Take(2).OrderBy(x => x).ToList();
        }
    }
}
