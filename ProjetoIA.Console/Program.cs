using Microsoft.Extensions.DependencyInjection;
using ProjetoIA.Dominio.Individuos.Enumeradores;
using ProjetoIA.Dominio.Interface.Servicos;
using ProjetoIA.Dominio.Processamento.Entidades;
using ProjetoIA.Dominio.Processamento.Servicos;

using System;
using System.Threading;
using System.Threading.Tasks;

using static System.Console;

namespace ProjetoIA.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Configura DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var repetir = true;
            while (repetir)
            {
                await serviceProvider.GetService<IServicoDeAtualizacaoDeInterface>().LimparInformacoes();

                Clear();

                await Executar(serviceProvider);

                var aux = true ? "S" : "N";

                WriteLine($"Repetir Execucao[{aux}]? ");
                aux = ReadLine();
                if (!string.IsNullOrEmpty(aux))
                {
                    if (aux.ToUpper() == "S")
                    {
                        repetir = true;
                    }
                    else
                    {
                        repetir = false;
                    }
                }
            }

        }

        private static async Task Executar(IServiceProvider serviceProvider)
        {
            decimal taxaDeCrossover = 0.6m;
            decimal taxaDeMutacao = 0.3m;
            int maximoDeGeracoes = 600;
            bool elitismo = true;
            int tamanhoDaPopulacao = 200;

            WriteLine($"Qual a taxa de Crossover[{taxaDeCrossover}]: ");
            string aux = ReadLine();
            if (!string.IsNullOrEmpty(aux) && decimal.TryParse(aux, out decimal saidaDecimal))
            {
                taxaDeCrossover = saidaDecimal;
            }

            WriteLine($"Qual a taxa de Mutacao[{taxaDeMutacao}]: ");
            aux = ReadLine();
            if (!string.IsNullOrEmpty(aux) && decimal.TryParse(aux, out saidaDecimal))
            {
                taxaDeMutacao = saidaDecimal;
            }

            WriteLine($"Qual o máximo de gerações[{maximoDeGeracoes}]: ");
            aux = ReadLine();
            if (!string.IsNullOrEmpty(aux) && int.TryParse(aux, out int saidaInt))
            {
                maximoDeGeracoes = saidaInt;
            }

            WriteLine($"Qual o tamanho da populacao[{tamanhoDaPopulacao}]: ");
            aux = ReadLine();
            if (!string.IsNullOrEmpty(aux) && int.TryParse(aux, out saidaInt))
            {
                tamanhoDaPopulacao = saidaInt;
            }

            aux = elitismo ? "S" : "N";

            WriteLine($"Ativar elitismo[{aux}]: ");
            aux = ReadLine();
            if (!string.IsNullOrEmpty(aux))
            {
                if (aux.ToUpper() == "S")
                {
                    elitismo = true;
                }
                else
                {
                    elitismo = false;
                }
            }

            serviceProvider.GetService<AlgoritimoGenetico>().DefinirAlgoritimo(
            new AlgoritimoGenetico()
            {
                Inicio = EnumeradorDeLocalizacaoDoIndividuo.Local0x3,
                Solucao = EnumeradorDeLocalizacaoDoIndividuo.Local3x0,
                TaxaDeCrossover = taxaDeCrossover,
                TaxaDeMutacao = taxaDeMutacao,
                NumeroDeGenes = 6,
                MaximoDeGeracoes = maximoDeGeracoes,
                Elitismo = elitismo,
                TamanhoDaPopulacao = tamanhoDaPopulacao
            });

            var tokenSource = new CancellationTokenSource();

            await serviceProvider.GetService<IServicoDeAlgoritimoGenetico>().Processar(tokenSource.Token);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.Executar();
        }
    }
}
