using System;

namespace ProjetoIA.Dominio.Servicos
{
    public static class IoC
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static T ObterServico<T>()
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }
    }
}
