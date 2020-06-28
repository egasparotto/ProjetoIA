using ProjetoIA.Dominio.Ponto.Entidades;
using ProjetoIA.Dominio.Ponto.Enumeradores;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Movimentacao.Servicos
{
    public interface IServicoDeMovimentacaoDoPonto
    {
        Task<int> Mover(IPonto ponto, EnumeradorDeMovimentoDoPonto movimento);
    }
}
