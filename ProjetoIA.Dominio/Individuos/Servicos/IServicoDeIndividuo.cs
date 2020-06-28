using ProjetoIA.Dominio.Individuos.Entidades;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA.Dominio.Individuos.Servicos
{
    public interface IServicoDeIndividuo
    {
        Task CalcularAptidao(Individuo individuo);
    }
}
