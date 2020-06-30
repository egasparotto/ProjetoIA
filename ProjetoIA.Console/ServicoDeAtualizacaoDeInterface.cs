using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Ponto.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA.Console
{
    public class ServicoDeAtualizacaoDeInterface : IServicoDeAtualizacaoDeInterface
    {
        private int geracao;

        public ServicoDeAtualizacaoDeInterface()
        {
            geracao = 0;
        }

        public Task AtualizarLocalizacao(IPonto ponto)
        {
            return Task.CompletedTask;
        }

        public Task AtualizaTela(bool aguardar = false)
        {
            return Task.CompletedTask;
        }

        public Task DefineMelhorCaminhoDaGeracao(IList<EnumeradorDeMovimentoDoIndividuo> genes)
        {
            System.Console.WriteLine($"Melhor Trajeto: {String.Join("-", genes.Select(x => Enum.GetName(typeof(EnumeradorDeMovimentoDoIndividuo), x)))}");
            return Task.CompletedTask;
        }

        public Task DefineMelhorCaminhoGeral(IList<EnumeradorDeMovimentoDoIndividuo> genes)
        {
            return Task.CompletedTask;
        }

        public Task DefinirMelhorAptidaoDaGeracao(int aptidao)
        {
            System.Console.WriteLine($"Melhor Aptidão: {aptidao}");
            return Task.CompletedTask;
        }

        public Task DefinirMelhorAptidaoGeral(int aptidao)
        {
            return Task.CompletedTask;
        }

        public Task FinalizaExecucao()
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"Execução Finalizada");
            return Task.CompletedTask;
        }

        public Task IncrementarGeracao()
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"Geracao: {++geracao}");
            return Task.CompletedTask;
        }

        public Task LimparInformacoes()
        {
            geracao = 0;
            return Task.CompletedTask;
        }
    }
}
