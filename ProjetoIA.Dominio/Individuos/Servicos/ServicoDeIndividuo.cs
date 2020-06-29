using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Servicos;
using ProjetoIA.Dominio.Ponto.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Individuos.Servicos
{
    public class ServicoDeIndividuo : IServicoDeIndividuo
    {
        private IDictionary<EnumeradorDeLocalizacaoDoIndividuo, int> distanciaDaChegada = new Dictionary<EnumeradorDeLocalizacaoDoIndividuo, int>()
        {
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x0, 30 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x1, 40 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x2, 50 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local0x3, 60 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x0, 20 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x1, 50 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x2, 60 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local1x3, 50 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x0, 10 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x1, 20 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x2, 30 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local2x3, 40 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x0, 0 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x1, 10 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x2, 60 },
            { EnumeradorDeLocalizacaoDoIndividuo.Local3x3, 50 }
        };

        public async Task CalcularAptidao(Individuo individuo)
        {
            int aptidao = 0;
            await IoC.ObterServico<IPonto>().DefinirLocalizacao(individuo);
            foreach (var movivento in individuo.Genes)
            {
                aptidao += await IoC.ObterServico<IServicoDeMovimentacaoDoIndividuo>().Mover(individuo, movivento);
            }
            individuo.Aptidao = aptidao + distanciaDaChegada[individuo.Localizacao];
        }
    }
}
