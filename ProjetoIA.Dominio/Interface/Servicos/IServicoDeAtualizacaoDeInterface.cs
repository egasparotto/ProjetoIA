using ProjetoIA.Dominio.Ponto.Entidades;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Interface.Servicos
{
    public interface IServicoDeAtualizacaoDeInterface
    {
        Task AtualizarLocalizacao(IPonto ponto);
    }
}
