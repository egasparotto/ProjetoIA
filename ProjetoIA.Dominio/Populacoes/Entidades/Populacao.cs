using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;

using System.Collections.Generic;

namespace ProjetoIA.Dominio.Populacoes.Entidades
{
    public class Populacao
    {
        public IList<Individuo> Individuos { get; private set; }
        public int TamanhoDaPopulacao => Individuos?.Count ?? 0;

        public Populacao()
        {
            Individuos = new List<Individuo>();
        }

        public Populacao(int numGenes, int tamanhoPopulacao, EnumeradorDeLocalizacaoDoIndividuo localizacaoInicial) : this()
        {
            for (int i = 0; i < tamanhoPopulacao; i++)
            {
                Individuos.Add(new Individuo(numGenes, localizacaoInicial));
            }
        }
    }
}
