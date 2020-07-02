using ProjetoIA.Apresentacao.Controllers;
using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjetoIA.Apresentacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource tokenSource;
        private readonly InformacoesDaTela _informacoesDaTela;
        private readonly IServicoDeAtualizacaoDeInterface _servicoDeAtualizacaoDeInterface;
        private readonly AlgoritimoGenetico _algoritimoGenetico;
        private readonly IPonto _ponto;
        private readonly IServicoDeAlgoritimoGenetico _servicoDeAlgoritimoGenetico;

        public MainWindow(InformacoesDaTela informacoesDaTela, 
                          IServicoDeAtualizacaoDeInterface servicoDeAtualizacaoDeInterface, 
                          AlgoritimoGenetico algoritimoGenetico, 
                          IPonto ponto, 
                          IServicoDeAlgoritimoGenetico servicoDeAlgoritimoGenetico)
        {
            _servicoDeAtualizacaoDeInterface = servicoDeAtualizacaoDeInterface;
            _algoritimoGenetico = algoritimoGenetico;
            _ponto = ponto;
            _servicoDeAlgoritimoGenetico = servicoDeAlgoritimoGenetico;
            _informacoesDaTela = informacoesDaTela;
            ((ServicoDeAtualizacaoDeInterface)_servicoDeAtualizacaoDeInterface).DefineMainWindow(this);

            InitializeComponent();
            DataContext = informacoesDaTela;
            tokenSource = new CancellationTokenSource();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            btnCancelar.IsEnabled = true;
            btnIniciar.IsEnabled = false;


            await _servicoDeAtualizacaoDeInterface.LimparInformacoes();

            _algoritimoGenetico.DefinirAlgoritimo(
                new AlgoritimoGenetico()
                {
                    Inicio = EnumeradorDeLocalizacaoDoIndividuo.Local0x3,
                    Solucao = EnumeradorDeLocalizacaoDoIndividuo.Local3x0,
                    TaxaDeCrossover = _informacoesDaTela.TaxaDeCrossover,
                    TaxaDeMutacao = _informacoesDaTela.TaxaDeMutacao,
                    NumeroDeGenes = 6,
                    MaximoDeGeracoes = _informacoesDaTela.MaximoDeGeracoes,
                    Elitismo = _informacoesDaTela.Elitismo,
                    TamanhoDaPopulacao = _informacoesDaTela.TamanhoDaPopulacao
                }
            );

            await _ponto.CriarPonto();
            grdLabirinto.Children.Remove((Ponto)_ponto);
            grdLabirinto.Children.Add((Ponto)_ponto);

            await Task.Run(async () =>
            {
                await _servicoDeAlgoritimoGenetico.Processar(tokenSource.Token);
            }, tokenSource.Token);

            tokenSource = new CancellationTokenSource();

            btnCancelar.IsEnabled = false;
            btnIniciar.IsEnabled = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }
    }
}
