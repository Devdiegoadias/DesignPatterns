using System;
using System.Collections.Generic;

namespace DesignPatterns.Comportamentais.Strategy
{
    interface IEstrategiaImposto
    {
        string Nome { get; }

        double AplicarImposto(double valor);
    }


   class PessoaFisica : IEstrategiaImposto
    {
        public string Nome => nameof(PessoaFisica);

        public double AplicarImposto(double valor)
        {
            Console.WriteLine("Para " + Nome);

            Console.WriteLine(valor * 0.32);

            return valor * 0.32; //Fictício
        }
    }

    class PessoaJuridica : IEstrategiaImposto
    {
        public string Nome => nameof(PessoaJuridica);

        public double AplicarImposto(double valor)
        {
            Console.WriteLine("Para " + Nome);

            Console.WriteLine(valor * 0.22);

            return valor * 0.22; //Fictício
        }
    }

    class PagamentoContexto
    {
       IEstrategiaImposto _strategy;
              
        public PagamentoContexto(IEstrategiaImposto strategyImposto)
        {
            this._strategy = strategyImposto;
        }

        public double AplicarImposto(Double salario)
        {
            Console.WriteLine("Aplicando imposto...");

            return (this._strategy.AplicarImposto(salario));
        }

        public void SetEstrategiaImposto(IEstrategiaImposto strategy)
        {
            this._strategy = strategy;
        }
    }
}