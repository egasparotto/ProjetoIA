using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Ponto.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Interface.Servicos
{
    public interface IServicoDeAtualizacaoDeInterface
    {
        Task AtualizarLocalizacao(IPonto ponto);
        Task AtualizaTela(bool aguardar = false);
        Task IncrementarGeracao();
        Task DefinirAptidao(int aptidao);
        Task FinalizaExecucao();
        Task DefineMelhorCaminho(IList<EnumeradorDeMovimentoDoIndividuo> genes);
    }
}
