using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Individuos.Servicos
{
    public class ServicoDeIndividuo : IServicoDeIndividuo
    {
        private readonly IPonto _ponto;
        private readonly IServicoDeMovimentacaoDoIndividuo _servicoDeMovimentacaoDoIndividuo;

        public ServicoDeIndividuo(IPonto ponto, IServicoDeMovimentacaoDoIndividuo servicoDeMovimentacaoDoIndividuo)
        {
            _ponto = ponto;
            _servicoDeMovimentacaoDoIndividuo = servicoDeMovimentacaoDoIndividuo;
        }

        private IDictionary<EnumeradorDeLocalizacaoDoIndividuo, int> distanciaDaChegada = new Dictionary<EnumeradorDeLocalizacaoDoIndividuo, int>()
        {
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x0, 3 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x1, 4 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x2, 5 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x3, 6 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x0, 2 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x1, 5 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x2, 6 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x3, 5 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x0, 1 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x1, 2 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x2, 3 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x3, 4 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x0, 0 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x1, 1 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x2, 6 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x3, 5 }
        };

        public async Task CalcularAptidao(Individuo individuo)
        {
            int aptidao = -15;
            if (_ponto != null)
            {
                await _ponto.DefinirLocalizacao(individuo);
            }
            foreach (var movivento in individuo.Genes)
            {
                aptidao += await _servicoDeMovimentacaoDoIndividuo.Mover(individuo, movivento) + distanciaDaChegada[individuo.Localizacao];
            }
            individuo.Aptidao = aptidao;
        }
    }
}
