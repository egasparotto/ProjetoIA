using ProjetoIA.Dominio.Processamento.Entidades;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Processamento.Servicos
{
    public interface IServicoDeAlgoritimoGenetico
    {
        Task Processar();
    }
}