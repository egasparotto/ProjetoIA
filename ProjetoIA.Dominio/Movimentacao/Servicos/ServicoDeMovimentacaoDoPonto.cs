using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Penalidade.Enumeradores;
using ProjetoIA.Dominio.Penalidades.Servico;
using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Ponto.Enumeradores;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Movimentacao.Servicos
{
    public class ServicoDeMovimentacaoDoPonto : IServicoDeMovimentacaoDoPonto
    {
        public async Task<int> Mover(IPonto ponto, EnumeradorDeMovimentoDoPonto movimento)
        {
            var penalidade = IoC.ObterServico<IServicoDePenalidade>().CalcularPenalidade(movimento, ponto.ObterLocalizacao());

            if(penalidade == EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto)
            {
                return 200;
            }
            int novoLocal;
            if (movimento == EnumeradorDeMovimentoDoPonto.Norte)
            {
                novoLocal = (int)ponto.ObterLocalizacao() - 1;
            }
            else if (movimento == EnumeradorDeMovimentoDoPonto.Sul)
            {
                novoLocal = (int)ponto.ObterLocalizacao() + 1;
            }
            else if (movimento == EnumeradorDeMovimentoDoPonto.Leste)
            {
                novoLocal = (int)ponto.ObterLocalizacao() + 4;
            }
            else
            {
                novoLocal = (int)ponto.ObterLocalizacao() - 4;
            }

            ponto.DefinirLocalizacao((EnumeradorDeLocalizacaoDoPonto)novoLocal);
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(ponto);

            if (penalidade == EnumeradorDeResultadoDaMovimentacao.AtravessaParede)
            {
                return 100;
            }

            return 0;
        }
    }
}
