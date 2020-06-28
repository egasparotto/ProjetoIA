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

        public async Task Norte()
        {
            DefinirLocalizacao((EnumeradorDeLocalizacaoDoPonto)((int)ObterLocalizacao() - 1));
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);
        }
        public async Task Sul()
        {
            DefinirLocalizacao((EnumeradorDeLocalizacaoDoPonto)((int)ObterLocalizacao() + 1));
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);
        }
        public async Task Leste()
        {
            DefinirLocalizacao((EnumeradorDeLocalizacaoDoPonto)((int)ObterLocalizacao() + 4));
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);
        }
        public async Task Oeste()
        {
            DefinirLocalizacao((EnumeradorDeLocalizacaoDoPonto)((int)ObterLocalizacao() - 4));
            await IoC.ObterServico<IServicoDeAtualizacaoDeInterface>().AtualizarLocalizacao(this);
        }
    }
}
