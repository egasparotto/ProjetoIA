using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Movimentacao.Servicos
{
    public interface IServicoDeMovimentacaoDoIndividuo
    {
        Task<int> Mover(Individuo individuo, EnumeradorDeMovimentoDoIndividuo movimento);
    }
}
