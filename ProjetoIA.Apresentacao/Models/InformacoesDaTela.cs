﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjetoIA.Apresentacao.Models
{
    public class InformacoesDaTela : INotifyPropertyChanged
    {
        private int numeroDeGeracoes;

        public Int32 NumeroDeGeracoes
        {
            get
            {
                return numeroDeGeracoes;
            }
            set
            {
                numeroDeGeracoes = value;
                NotifyPropertyChanged();
            }
        }

        private int? aptidao;

        public Int32? Aptidao
        {
            get
            {
                return aptidao;
            }
            set
            {
                aptidao = value;
                NotifyPropertyChanged();
            }
        }

        private string melhorCaminho;

        public string MelhorCaminho
        {
            get
            {
                return melhorCaminho;
            }
            set
            {
                melhorCaminho = value;
                NotifyPropertyChanged();
            }
        }

        public int MaximoDeGeracoes { get; set; }
        public int TamanhoDaPopulacao { get; set; }
        public bool AtrasoNaAtualizacao { get; set; }
        public bool Elitismo { get; set; }
        public decimal TaxaDeMutacao { get; set; }
        public decimal TaxaDeCrossover { get; set; }
        public int PontosDeCorte { get; set; }

        public InformacoesDaTela()
        {
            Aptidao = null;
            NumeroDeGeracoes = 0;
            MaximoDeGeracoes = 600;
            TamanhoDaPopulacao = 100;
            AtrasoNaAtualizacao = false;
            Elitismo = true;
            TaxaDeMutacao = 0.9m;
            TaxaDeCrossover = 0.8m;
            PontosDeCorte = 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
