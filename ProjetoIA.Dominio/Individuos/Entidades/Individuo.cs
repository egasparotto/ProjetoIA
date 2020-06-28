using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;

using System;
using System.Collections.Generic;

namespace ProjetoIA.Dominio.Individuos.Entidades
{
    public class Individuo
    {
        public IList<EnumeradorDeMovimentoDoIndividuo> Genes { get; }

        public EnumeradorDeLocalizacaoDoIndividuo Localizacao { get; set; }

        public int Aptidao { get; set; }

        public Individuo(int numeroDeGenes, EnumeradorDeLocalizacaoDoIndividuo localizacao)
        {
            Localizacao = localizacao;
            Genes = new List<EnumeradorDeMovimentoDoIndividuo>();
            for (int i = 0; i < numeroDeGenes; i++)
            {

                var valoresPossiveis = Enum.GetValues(typeof(EnumeradorDeMovimentoDoIndividuo));
                Random random = new Random();
                Genes.Add((EnumeradorDeMovimentoDoIndividuo)valoresPossiveis.GetValue(random.Next(valoresPossiveis.Length)));
            }
        }

        public Individuo(IList<EnumeradorDeMovimentoDoIndividuo> genes, EnumeradorDeLocalizacaoDoIndividuo localizacao, decimal taxaDeMutacao)
        {
            Localizacao = localizacao;
            Genes = genes;

            if (new Random().NextDouble() <= (double)taxaDeMutacao)
            {
                var valoresPossiveis = Enum.GetValues(typeof(EnumeradorDeMovimentoDoIndividuo));
                int geneAleatorio = new Random().Next(0, 5);
                Genes[geneAleatorio] = (EnumeradorDeMovimentoDoIndividuo)valoresPossiveis.GetValue(new Random().Next(valoresPossiveis.Length));
            }
        }
    }
}
