using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Penalidade.Enumeradores;

namespace ProjetoIA.Dominio.Penalidades.Servico
{
    public interface IServicoDePenalidade
    {
        EnumeradorDeResultadoDaMovimentacao CalcularPenalidade(EnumeradorDeMovimentoDoIndividuo movimentoDoPonto, EnumeradorDeLocalizacaoDoIndividuo localizacaoAtual);
    }
}