using ProjetoIA.Dominio.Penalidade.Enumeradores;
using ProjetoIA.Dominio.Ponto.Enumeradores;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoIA.Dominio.Penalidades.Servico
{
    public class ServicoDePenalidade : IServicoDePenalidade
    {
        protected readonly IDictionary<EnumeradorDeMovimentoDoPonto, IDictionary<EnumeradorDeLocalizacaoDoPonto, EnumeradorDeResultadoDaMovimentacao>> movimentosInvalidos = new Dictionary<EnumeradorDeMovimentoDoPonto, IDictionary<EnumeradorDeLocalizacaoDoPonto, EnumeradorDeResultadoDaMovimentacao>>()
        {
            {
                EnumeradorDeMovimentoDoPonto.Norte, new Dictionary<EnumeradorDeLocalizacaoDoPonto, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoPonto.Local0x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local1x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local2x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local1x1, EnumeradorDeResultadoDaMovimentacao.AtravessaParede },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
            {
                EnumeradorDeMovimentoDoPonto.Sul, new Dictionary<EnumeradorDeLocalizacaoDoPonto, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoPonto.Local0x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local1x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local2x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local1x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
            {
                EnumeradorDeMovimentoDoPonto.Leste, new Dictionary<EnumeradorDeLocalizacaoDoPonto, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoPonto.Local3x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x1, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x2, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local1x1, EnumeradorDeResultadoDaMovimentacao.AtravessaParede },
                    { EnumeradorDeLocalizacaoDoPonto.Local1x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
            {
                EnumeradorDeMovimentoDoPonto.Oeste, new Dictionary<EnumeradorDeLocalizacaoDoPonto, EnumeradorDeResultadoDaMovimentacao>()
                {
                    { EnumeradorDeLocalizacaoDoPonto.Local0x0, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local0x1, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local0x2, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local0x3, EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto },
                    { EnumeradorDeLocalizacaoDoPonto.Local3x2, EnumeradorDeResultadoDaMovimentacao.AtravessaParede }
                }
            },
        };

        public EnumeradorDeResultadoDaMovimentacao CalcularPenalidade(EnumeradorDeMovimentoDoPonto movimentoDoPonto, EnumeradorDeLocalizacaoDoPonto localizacaoAtual)
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
