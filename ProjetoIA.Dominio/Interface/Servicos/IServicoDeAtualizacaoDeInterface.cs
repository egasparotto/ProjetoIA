using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Ponto.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Interface.Servicos
{
    public interface IServicoDeAtualizacaoDeInterface
    {
        Task LimparInformacoes();
        Task AtualizarLocalizacao(IPonto ponto);
        Task AtualizaTela(bool aguardar = false);
        Task IncrementarGeracao();
        Task DefinirMelhorAptidaoGeral(int aptidao);
        Task DefinirMelhorAptidaoDaGeracao(int aptidao);
        Task FinalizaExecucao();
        Task DefineMelhorCaminhoGeral(IList<EnumeradorDeMovimentoDoIndividuo> genes);
        Task DefineMelhorCaminhoDaGeracao(IList<EnumeradorDeMovimentoDoIndividuo> genes);
    }
}
