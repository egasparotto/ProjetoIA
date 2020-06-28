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
        private int numeroDeGeracoes = 1;

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

        private int penalidade;

        public Int32 Penalidade
        {
            get
            {
                return penalidade;
            }
            set
            {
                penalidade = value;
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
    }
}
