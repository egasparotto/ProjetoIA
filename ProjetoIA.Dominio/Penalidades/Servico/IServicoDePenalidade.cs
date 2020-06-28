using ProjetoIA.Dominio.Penalidade.Enumeradores;
using ProjetoIA.Dominio.Ponto.Enumeradores;

namespace ProjetoIA.Dominio.Penalidades.Servico
{
    public interface IServicoDePenalidade
    {
        EnumeradorDeResultadoDaMovimentacao CalcularPenalidade(EnumeradorDeMovimentoDoPonto movimentoDoPonto, EnumeradorDeLocalizacaoDoPonto localizacaoAtual);
    }
}