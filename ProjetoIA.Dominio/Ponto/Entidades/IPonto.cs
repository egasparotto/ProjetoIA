using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Ponto.Entidades
{
    public interface IPonto
    {
        EnumeradorDeLocalizacaoDoIndividuo ObterLocalizacao();
        Task DefinirLocalizacao(Individuo individuo);
        Task CriarPonto();
    }
}
