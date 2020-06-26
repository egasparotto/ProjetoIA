using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ProjetoIA.Dominio
{
    public class Ponto : Label
    {
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

            Grid.SetRow(this, 3);
            Grid.SetColumn(this, 0);
            grid.Children.Add(this);
        }

        private void Refresh(Action funcao)
        {
            Dispatcher.Invoke(DispatcherPriority.Background, funcao);
        }

        public void Norte()
        {
            Refresh(() =>
            {
                Grid.SetRow(this, Grid.GetRow(this) - 1);
            });
            Thread.Sleep(1000);
        }
        public void Sul()
        {
            Refresh(() =>
            {
                Grid.SetRow(this, Grid.GetRow(this) + 1);
            });
            Thread.Sleep(1000);
        }
        public void Leste()
        {
            Refresh(() =>
            {
                Grid.SetColumn(this, Grid.GetColumn(this) + 1);
            });
            Thread.Sleep(1000);
        }
        public void Oeste()
        {
            Refresh(() =>
            {
                Grid.SetColumn(this, Grid.GetColumn(this) - 1);
            });
            Thread.Sleep(1000);
        }
    }
}
