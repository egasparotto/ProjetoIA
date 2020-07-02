using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Ponto.Entidades;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProjetoIA.Apresentacao.Controllers
{
    class ServicoDeAtualizacaoDeInterface : IServicoDeAtualizacaoDeInterface
    {
        private MainWindow mainWindow;
        private readonly InformacoesDaTela _informacoesDaTela;

        public ServicoDeAtualizacaoDeInterface(InformacoesDaTela informacoesDaTela)
        {
            _informacoesDaTela = informacoesDaTela;
        }

        public async Task AtualizarLocalizacao(IPonto ponto)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Render,
            new Action(async () =>
            {
                if ((int)ponto.ObterLocalizacao() <= 3)
                {
                    Grid.SetColumn((Ponto)ponto, 0);
                }
                else if ((int)ponto.ObterLocalizacao() <= 7)
                {
                    Grid.SetColumn((Ponto)ponto, 1);
                }
                else if ((int)ponto.ObterLocalizacao() <= 11)
                {
                    Grid.SetColumn((Ponto)ponto, 2);
                }
                else
                {
                    Grid.SetColumn((Ponto)ponto, 3);
                }
                Grid.SetRow((Ponto)ponto, (int)ponto.ObterLocalizacao() % 4);
          
                await AtualizaTela(true);
            }));
        }

        public async Task AtualizaTela(bool aguardar = false)
        {

            Action funcao = delegate ()
            {
                mainWindow.UpdateLayout();
                if (aguardar)
                {
                    if (_informacoesDaTela.AtrasoNaAtualizacao)
                    {
                        Thread.Sleep(100);
                    }
                }
            };
            await mainWindow.Dispatcher.BeginInvoke(DispatcherPriority.Render, funcao);
        }

        public void DefineMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public async Task FinalizaExecucao()
        {
            Action funcao = delegate ()
            {
                mainWindow.UpdateLayout();
                MessageBox.Show("Finalizado");
            };
            await mainWindow.Dispatcher.BeginInvoke(DispatcherPriority.Send, funcao);
        }

        public async Task IncrementarGeracao()
        {
            _informacoesDaTela.NumeroDeGeracoes++;
            await AtualizaTela();
        }

        public async Task DefinirMelhorAptidaoGeral(int aptidao)
        {
            _informacoesDaTela.Aptidao = aptidao;
            await AtualizaTela();
        }

        public async Task DefineMelhorCaminhoGeral(IList<EnumeradorDeMovimentoDoIndividuo> genes)
        {
            _informacoesDaTela.MelhorCaminho = String.Join("-",genes.Select(x => Enum.GetName(typeof(EnumeradorDeMovimentoDoIndividuo),x)));
            await AtualizaTela();
        }

        public Task DefinirMelhorAptidaoDaGeracao(int aptidao)
        {
            return Task.CompletedTask;
        }

        public Task DefineMelhorCaminhoDaGeracao(IList<EnumeradorDeMovimentoDoIndividuo> genes)
        {
            return Task.CompletedTask;
        }

        public async Task LimparInformacoes()
        {
            _informacoesDaTela.NumeroDeGeracoes = 0;
            _informacoesDaTela.Aptidao = null;
            _informacoesDaTela.MelhorCaminho = null;

            await AtualizaTela();
        }
    }
}
