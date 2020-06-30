﻿using ProjetoIA.Apresentacao.Models;
using ProjetoIA.Dominio.Base;
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
                IoC.ObterServico<MainWindow>().UpdateLayout();
                if (aguardar)
                {
                    if (IoC.ObterServico<InformacoesDaTela>().AtrasoNaAtualizacao)
                    {
                        Thread.Sleep(100);
                    }
                }
            };
            await IoC.ObterServico<MainWindow>().Dispatcher.BeginInvoke(DispatcherPriority.Render, funcao);
        }

        public async Task FinalizaExecucao()
        {
            Action funcao = delegate ()
            {
                IoC.ObterServico<MainWindow>().UpdateLayout();
                MessageBox.Show("Finalizado");
            };
            await IoC.ObterServico<MainWindow>().Dispatcher.BeginInvoke(DispatcherPriority.Send, funcao);
        }

        public async Task IncrementarGeracao()
        {
            IoC.ObterServico<InformacoesDaTela>().NumeroDeGeracoes++;
            await AtualizaTela();
        }

        public async Task DefinirAptidao(int aptidao)
        {
            IoC.ObterServico<InformacoesDaTela>().Aptidao = aptidao;
            await AtualizaTela();
        }

        public async Task DefineMelhorCaminho(IList<EnumeradorDeMovimentoDoIndividuo> genes)
        {
            IoC.ObterServico<InformacoesDaTela>().MelhorCaminho = String.Join("-",genes.Select(x => Enum.GetName(typeof(EnumeradorDeMovimentoDoIndividuo),x)));
            await AtualizaTela();
        }

    }
}
