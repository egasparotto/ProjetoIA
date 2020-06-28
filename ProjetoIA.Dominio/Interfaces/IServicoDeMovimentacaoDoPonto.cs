using ProjetoIA.Dominio.Entidades;
using ProjetoIA.Dominio.Enumeradores;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Interfaces
{
    public interface IServicoDeMovimentacaoDoPonto
    {
        Task<int> Mover(IPonto ponto, EnumeradorDeMovimentoDoPonto movimento);
    }
}
