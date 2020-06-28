using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;

using System.Windows;

namespace ProjetoIA.Apresentacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(InformacoesDaTela informacoesDaTela)
        {
            InitializeComponent();
            DataContext = informacoesDaTela;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            IoC.ObterServico<AlgoritimoGenetico>().DefinirAlgoritimo(
                new AlgoritimoGenetico()
                {
                    Inicio = EnumeradorDeLocalizacaoDoIndividuo.Local0x3,
                    Solucao = EnumeradorDeLocalizacaoDoIndividuo.Local3x0,
                    TaxaDeCrossover = 0.6m,
                    TaxaDeMutacao = 0.3m,
                    NumeroDeGenes = 6,
                    MaximoDeGeracoes = 600,
                    Elitismo = true,
                    TamanhoDaPopulacao = 20
                }
            );

            var ponto = IoC.ObterServico<IPonto>();
            await ponto.CriarPonto();
            grdLabirinto.Children.Add((Ponto)ponto);

            await IoC.ObterServico<IServicoDeAlgoritimoGenetico>().Processar();
        }
    }
}
