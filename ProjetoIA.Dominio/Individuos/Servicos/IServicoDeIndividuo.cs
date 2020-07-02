using ProjetoIA.Dominio.Individuos.Entidades;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Individuos.Servicos
{
    public interface IServicoDeIndividuo
    {
        Task CalcularAptidao(Individuo individuo);
    }
}
