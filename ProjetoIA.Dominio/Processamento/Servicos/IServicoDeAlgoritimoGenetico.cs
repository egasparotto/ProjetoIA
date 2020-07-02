using System.Threading;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Processamento.Servicos
{
    public interface IServicoDeAlgoritimoGenetico
    {
        Task Processar(CancellationToken token);
    }
}