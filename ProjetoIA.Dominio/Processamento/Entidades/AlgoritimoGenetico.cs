﻿using ProjetoIA.Dominio.Individuos.Enumeradores;

namespace ProjetoIA.Dominio.Processamento.Entidades
{
    public class AlgoritimoGenetico
    {
        public EnumeradorDeLocalizacaoDoIndividuo Inicio { get; set; }
        public EnumeradorDeLocalizacaoDoIndividuo Solucao { get; set; }
        public decimal TaxaDeCrossover { get; set; }
        public decimal TaxaDeMutacao { get; set; }
        public int NumeroDeGenes { get; set; }
        public int MaximoDeGeracoes { get; set; }
        public bool Elitismo { get; set; }
        public int TamanhoDaPopulacao { get; set; }
        public int PontosDeCorte { get; set; }

        public void DefinirAlgoritimo(AlgoritimoGenetico algoritimo)
        {
            Inicio = algoritimo.Inicio;
            Solucao = algoritimo.Solucao;
            TaxaDeCrossover = algoritimo.TaxaDeCrossover;
            TaxaDeMutacao = algoritimo.TaxaDeMutacao;
            NumeroDeGenes = algoritimo.NumeroDeGenes;
            MaximoDeGeracoes = algoritimo.MaximoDeGeracoes;
            Elitismo = algoritimo.Elitismo;
            TamanhoDaPopulacao = algoritimo.TamanhoDaPopulacao;
            PontosDeCorte = algoritimo.PontosDeCorte;
            
        }
    }
}
