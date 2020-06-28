using System;
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

        public InformacoesDaTela()
        {
            NumeroDeGeracoes = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void IncrementarGeracao()
        {
            NumeroDeGeracoes++;
        }

    }
}
