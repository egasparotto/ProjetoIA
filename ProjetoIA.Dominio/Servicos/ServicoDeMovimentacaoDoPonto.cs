using ProjetoIA.Dominio.Entidades;
using ProjetoIA.Dominio.Enumeradores;
using ProjetoIA.Dominio.Interfaces;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Servicos
{
    public class ServicoDeMovimentacaoDoPonto : IServicoDeMovimentacaoDoPonto
    {
        public async Task<int> Mover(IPonto ponto, EnumeradorDeMovimentoDoPonto movimento)
        {
            int novoLocal;
            if(movimento == EnumeradorDeMovimentoDoPonto.Norte)
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

            return 0;
        }
    }
}
