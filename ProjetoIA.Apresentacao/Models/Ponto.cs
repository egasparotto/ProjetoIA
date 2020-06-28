﻿using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjetoIA.Apresentacao.Models
{
    public class Ponto : Label, IPonto
    {
        private EnumeradorDeLocalizacaoDoIndividuo local;

        public EnumeradorDeLocalizacaoDoIndividuo ObterLocalizacao()
        {
            return local;
        }

        public async Task DefinirLocalizacao(Individuo individuo)
        {
            local = individuo.Localizacao;
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);
        }

        public async Task CriarPonto()
        {
            Name = "Ponto";
            Content = "P";
            Width = 30;
            Height = 30;
            Margin = new Thickness(0, 21, 0, 0);
            Foreground = new SolidColorBrush(Colors.White);
            Background = new SolidColorBrush(Colors.Black);
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;

            local = IoC.ObterServico<AlgoritimoGenetico>().Inicio;
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);
        }
    }
}
