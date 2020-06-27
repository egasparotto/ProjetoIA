using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ProjetoIA.Apresentacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ponto ponto;

        InformacoesDaTela InformacoesDaTela { get; }


        public MainWindow()
        {
            InitializeComponent();
            InformacoesDaTela = new InformacoesDaTela();
            DataContext = InformacoesDaTela;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ponto = new Ponto("Ponto1", grdLabirinto);
        }

        private async void btnProximo_Click(object sender, RoutedEventArgs e)
        {

            ponto.Norte();
            await AtualizaTela(true);

            ponto.Norte();
            await AtualizaTela(true);

            ponto.Leste();
            await AtualizaTela(true);

            ponto.Leste();
            await AtualizaTela();
            InformacoesDaTela.IncrementarGeracao();
        }


        private async Task AtualizaTela(bool aguardar = false)
        {

            Action funcao = delegate () { 
                UpdateLayout();
                if (aguardar)
                {
                    Thread.Sleep(500);
                }
            };
            await Dispatcher.BeginInvoke(DispatcherPriority.Render, funcao);
        }
    }
}
