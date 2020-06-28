using ProjetoIA.Dominio.Individuos.Enumeradores;

namespace ProjetoIA.Dominio.Ponto.Entidades
{
    public interface IPonto
    {
        EnumeradorDeLocalizacaoDoIndividuo ObterLocalizacao();
        void DefinirLocalizacao(EnumeradorDeLocalizacaoDoIndividuo localizacaoDoPonto);
    }
}
