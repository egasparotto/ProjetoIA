using ProjetoIA.Dominio.Base;
using ProjetoIA.Dominio.Individuos.Entidades;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Movimentacao.Enumeradores;
using ProjetoIA.Dominio.Penalidade.Enumeradores;
using ProjetoIA.Dominio.Penalidades.Servico;
using ProjetoIA.Dominio.Ponto.Entidades;

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Movimentacao.Servicos
{
    public class ServicoDeMovimentacaoDoIndividuo : IServicoDeMovimentacaoDoIndividuo
    {


        public async Task<int> Mover(Individuo individuo, EnumeradorDeMovimentoDoIndividuo movimento)
        {
            var penalidade = IoC.ObterServico<IServicoDePenalidade>().CalcularPenalidade(movimento, individuo.Localizacao);

            if(penalidade == EnumeradorDeResultadoDaMovimentacao.ForaDoLabirinto)
            {
                return 200;
            }
            if (penalidade == EnumeradorDeResultadoDaMovimentacao.AtravessaParede)
            {
                return 100;
            }

            int novoLocal;
            if (movimento == EnumeradorDeMovimentoDoIndividuo.Norte)
            {
                novoLocal = (int)individuo.Localizacao - 1;
            }
            else if (movimento == EnumeradorDeMovimentoDoIndividuo.Sul)
            {
                novoLocal = (int)individuo.Localizacao + 1;
            }
            else if (movimento == EnumeradorDeMovimentoDoIndividuo.Leste)
            {
                novoLocal = (int)individuo.Localizacao + 4;
            }
            else
            {
                novoLocal = (int)individuo.Localizacao - 4;
            }

            individuo.Localizacao = (EnumeradorDeLocalizacaoDoIndividuo)novoLocal;
            await IoC.ObterServico<IPonto>().DefinirLocalizacao(individuo);

            return 0;
        }
    }
}
