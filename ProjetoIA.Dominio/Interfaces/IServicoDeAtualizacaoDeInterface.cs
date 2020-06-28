using ProjetoIA.Dominio.Entidades;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Interfaces
{
    public interface IServicoDeAtualizacaoDeInterface
    {
        Task AtualizarLocalizacao(IPonto ponto);
    }
}
