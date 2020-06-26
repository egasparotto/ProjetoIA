using ProjetoIA.Dominio;
using System;
using System.Threading;
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

        private static readonly Action EmptyDelegate = delegate { };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ponto = new Ponto("Ponto1", grdLabirinto);
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            ponto.Norte();
            ponto.Norte();
            ponto.Leste();
            ponto.Oeste();
        }
    }
}
