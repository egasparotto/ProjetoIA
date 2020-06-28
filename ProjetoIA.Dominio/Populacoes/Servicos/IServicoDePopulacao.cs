using ProjetoIA.Dominio.Populacoes.Entidades;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Populacoes.Servicos
{
    public interface IServicoDePopulacao
    {
        Task<Populacao> NovaGeracao(Populacao populacao);
        Task CalculaAptidaoDaPopulacao(Populacao populacao);
    }
}