using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Interface.Servicos;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

        private int aptidao;

        public Int32 Aptidao
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

        public InformacoesDaTela()
        {
            Aptidao = 60;
            NumeroDeGeracoes = 0;
            MaximoDeGeracoes = 600;
            TamanhoDaPopulacao = 200;
            AtrasoNaAtualizacao = false;
            Elitismo = true;
            TaxaDeMutacao = 0.3m;
            TaxaDeCrossover = 0.6m;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
