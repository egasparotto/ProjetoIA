using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Servicos;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Populacoes.Entidades;
using ProjetoIA.Dominio.Processamento.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Populacoes.Servicos
{
    public class ServicoDePopulacao : IServicoDePopulacao
    {
        private readonly AlgoritimoGenetico algoritimo;

        public ServicoDePopulacao(AlgoritimoGenetico algoritimo)
        {
            this.algoritimo = algoritimo;
        }

        public async Task<Populacao> NovaGeracao(Populacao populacao)
        {
            var tamanhoPopulacao = populacao.TamanhoDaPopulacao;
            var novaPopulacao = new Populacao();

            if (algoritimo.Elitismo)
            {
                novaPopulacao.Individuos.Add(populacao.Individuos.OrderBy(x => x.Aptidao).FirstOrDefault());
            }

            while (novaPopulacao.TamanhoDaPopulacao < tamanhoPopulacao)
            {
                var pais = SelecaoPorTorneio(populacao);

                if (new Random().NextDouble() <= (double)algoritimo.TaxaDeCrossover)
                {
                    novaPopulacao.Individuos.Add(Crossover(pais[0], pais[1]));
                }
                else
                {
                    novaPopulacao.Individuos.Add(new Individuo(pais[0].Genes, algoritimo.Inicio, algoritimo.TaxaDeMutacao));
                    novaPopulacao.Individuos.Add(new Individuo(pais[1].Genes, algoritimo.Inicio, algoritimo.TaxaDeMutacao));
                }
            }

            await CalculaAptidaoDaPopulacao(novaPopulacao);

            return novaPopulacao;
        }

        public async Task CalculaAptidaoDaPopulacao(Populacao populacao)
        {
            foreach (var individuo in populacao.Individuos)
            {
                await IoC.ObterServico<IServicoDeIndividuo>().CalcularAptidao(individuo);
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
            IList<EnumeradorDeMovimentoDoIndividuo> genes = new List<EnumeradorDeMovimentoDoIndividuo>();
            foreach (var movimento in individuo1.Genes.Take(2))
            {
                genes.Add(movimento);
            }
            foreach (var movimento in individuo2.Genes.Skip(2).Take(2))
            {
                genes.Add(movimento);
            }
            foreach (var movimento in individuo1.Genes.Skip(4).Take(2))
            {
                genes.Add(movimento);
            }
            return new Individuo(genes, algoritimo.Inicio, algoritimo.TaxaDeMutacao);
        }

    }
}
