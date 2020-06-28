using ProjetoIA.Dominio.Enumeradores;
using ProjetoIA.Dominio.Interfaces;
using ProjetoIA.Dominio.Servicos;

using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Entidades
{
    public interface IPonto
    {
        EnumeradorDeLocalizacaoDoPonto ObterLocalizacao();
        void DefinirLocalizacao(EnumeradorDeLocalizacaoDoPonto localizacaoDoPonto);
    }
}
