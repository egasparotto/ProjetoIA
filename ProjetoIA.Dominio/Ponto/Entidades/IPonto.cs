using ProjetoIA.Dominio.Ponto.Enumeradores;

namespace ProjetoIA.Dominio.Ponto.Entidades
{
    public interface IPonto
    {
        EnumeradorDeLocalizacaoDoPonto ObterLocalizacao();
        void DefinirLocalizacao(EnumeradorDeLocalizacaoDoPonto localizacaoDoPonto);
    }
}
