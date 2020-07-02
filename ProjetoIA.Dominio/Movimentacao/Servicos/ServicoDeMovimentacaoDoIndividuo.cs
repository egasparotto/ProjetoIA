using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Penalidade.Enumeradores;
using ProjetoIA.Dominio.Penalidades.Servico;
using ProjetoIA.Dominio.Ponto.Entidades;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Movimentacao.Servicos
{
    public class ServicoDeMovimentacaoDoIndividuo : IServicoDeMovimentacaoDoIndividuo
    {

        private readonly IPonto _ponto;
        private readonly IServicoDePenalidade _servicoDePenalidade;

        public ServicoDeMovimentacaoDoIndividuo(IPonto ponto, IServicoDePenalidade servicoDePenalidade)
        {
            _ponto = ponto;
            _servicoDePenalidade = servicoDePenalidade;
        }

        public async Task<int> Mover(Individuo individuo, EnumeradorDeMovimentoDoIndividuo movimento)
        {
            var penalidade = _servicoDePenalidade.CalcularPenalidade(movimento, individuo.Localizacao);

            if (penalidade == EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto)
            {
                return 200;
            }
            if (penalidade == EnumeradorDeResultadoDaMovimentacao.AtravessaParede)
            {
                return 100;
            }

            int novoLocal;
            if (movimento == EnumeradorDeMovimentoDoIndividuo.N)
            {
                novoLocal = (int)individuo.Localizacao - 1;
            }
            else if (movimento == EnumeradorDeMovimentoDoIndividuo.S)
            {
                novoLocal = (int)individuo.Localizacao + 1;
            }
            else if (movimento == EnumeradorDeMovimentoDoIndividuo.L)
            {
                novoLocal = (int)individuo.Localizacao + 4;
            }
            else
            {
                novoLocal = (int)individuo.Localizacao - 4;
            }

            individuo.Localizacao = (EnumeradorDeLocalizacaoDoIndividuo)novoLocal;

            if (_ponto != null)
            {
                await _ponto.DefinirLocalizacao(individuo);
            }

            return 0;
        }
    }
}
