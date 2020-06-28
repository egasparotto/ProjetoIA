using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Entidades;
using ProjetoIA.Dominio.Enumeradores;
using ProjetoIA.Dominio.Interfaces;
using ProjetoIA.Dominio.Servicos;

using System.Windows;

namespace ProjetoIA.Apresentacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPonto ponto;

        public MainWindow(InformacoesDaTela informacoesDaTela)
        {
            InitializeComponent();
            DataContext = informacoesDaTela;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ponto = new Ponto("Ponto1", grdLabirinto);
        }

        private async void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            var servicoDeMovimentacao = IoC.ObterServico<IServicoDeMovimentacaoDoPonto>();

            await servicoDeMovimentacao.Mover(ponto,EnumeradorDeMovimentoDoPonto.Norte);
            await servicoDeMovimentacao.Mover(ponto, EnumeradorDeMovimentoDoPonto.Leste);
            await servicoDeMovimentacao.Mover(ponto, EnumeradorDeMovimentoDoPonto.Sul);
            await servicoDeMovimentacao.Mover(ponto, EnumeradorDeMovimentoDoPonto.Oeste);
            IoC.ObterServico<InformacoesDaTela>().IncrementarGeracao();
        }
    }
}
