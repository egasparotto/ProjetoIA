using ProjetoIA.Dominio.Entidades;
using ProjetoIA.Dominio.Enumeradores;
using ProjetoIA.Dominio.Interfaces;
using ProjetoIA.Dominio.Servicos;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjetoIA.Apresentacao.Models
{
    public class Ponto : Label, IPonto
    {
        private EnumeradorDeLocalizacaoDoPonto local;

        public EnumeradorDeLocalizacaoDoPonto ObterLocalizacao()
        {
            return local;
        }

        public void DefinirLocalizacao(EnumeradorDeLocalizacaoDoPonto value)
        {
            local = value;
        }

        public Ponto(string nome, Grid grid)
        {
            Name = nome;
            Content = "P";
            Width = 30;
            Height = 30;
            Margin = new Thickness(0, 21, 0, 0);
            Foreground = new SolidColorBrush(Colors.White);
            Background = new SolidColorBrush(Colors.Black);
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;

            DefinirLocalizacao(EnumeradorDeLocalizacaoDoPonto.Local0x3);

            IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);

            grid.Children.Add(this);
        }
    }
}
