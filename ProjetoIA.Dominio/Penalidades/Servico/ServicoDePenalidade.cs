using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Penalidade.Enumeradores;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoIA.Dominio.Penalidades.Servico
{
    public class ServicoDePenalidade : IServicoDePenalidade
    {
        protected readonly IDictionary<EnumeradorDeMovimentoDoIndividuo, IDictionary<EnumeradorDeLocalizacaoDoIndividuo, EnumeradorDeResultadoDaMovimentacao>> movimentosInvalidos = new Dictionary<EnumeradorDeMovimentoDoIndividuo, IDictionary<EnumeradorDeLocalizacaoDoIndividuo, EnumeradorDeResultadoDaMovimentacao>>()
        {
            {
                EnumeradorDeMovimentoDoIndividuo.Norte, new Dictionary<EnumeradorDeLocalizacaoDoIndividuo, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoIndividuo.Local0x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local1x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local2x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local1x1, EnumeradorDeResultadoDaMovimentacao.AtravessaParede },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
            {
                EnumeradorDeMovimentoDoIndividuo.Sul, new Dictionary<EnumeradorDeLocalizacaoDoIndividuo, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoIndividuo.Local0x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local1x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local2x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local1x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
            {
                EnumeradorDeMovimentoDoIndividuo.Leste, new Dictionary<EnumeradorDeLocalizacaoDoIndividuo, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x1, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x2, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local1x1, EnumeradorDeResultadoDaMovimentacao.AtravessaParede },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local1x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
            {
                EnumeradorDeMovimentoDoIndividuo.Oeste, new Dictionary<EnumeradorDeLocalizacaoDoIndividuo, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoIndividuo.Local0x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local0x1, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local0x2, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local0x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoIndividuo.Local3x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
        };

        public EnumeradorDeResultadoDaMovimentacao CalcularPenalidade(EnumeradorDeMovimentoDoIndividuo movimentoDoPonto, EnumeradorDeLocalizacaoDoIndividuo localizacaoAtual)
        {
            var localizacoesInvalidas = movimentosInvalidos[movimentoDoPonto];
            if (localizacoesInvalidas.TryGetValue(localizacaoAtual, out EnumeradorDeResultadoDaMovimentacao resultado))
            {
                return resultado;
            }
            else
            {
                return EnumeradorDeResultadoDaMovimentacao.Valido;
            }
        }
    }
}
