﻿using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;
using System.Text.RegularExpressions;
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
            var infoTela = IoC.ObterServico<InformacoesDaTela>();
            infoTela.Aptidao = 60;
            infoTela.NumeroDeGeracoes = 0;

            IoC.ObterServico<AlgoritimoGenetico>().DefinirAlgoritimo(
                new AlgoritimoGenetico()
                {
                    Inicio = EnumeradorDeLocalizacaoDoIndividuo.Local0x3,
                    Solucao = EnumeradorDeLocalizacaoDoIndividuo.Local3x0,
                    TaxaDeCrossover = infoTela.TaxaDeCrossover,
                    TaxaDeMutacao = infoTela.TaxaDeMutacao,
                    NumeroDeGenes = 6,
                    MaximoDeGeracoes = infoTela.MaximoDeGeracoes,
                    Elitismo = infoTela.Elitismo,
                    TamanhoDaPopulacao = infoTela.TamanhoDaPopulacao
                }
            );

            var ponto = IoC.ObterServico<IPonto>();
            await ponto.CriarPonto();
            grdLabirinto.Children.Remove((Ponto)ponto);
            grdLabirinto.Children.Add((Ponto)ponto);

            await IoC.ObterServico<IServicoDeAlgoritimoGenetico>().Processar();
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
