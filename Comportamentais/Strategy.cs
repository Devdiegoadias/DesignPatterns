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
        public string Nome => throw new NotImplementedException();

        public double AplicarImposto(double data)
        {
            Console.WriteLine("Para Pessoa Física");

            Console.WriteLine(data * 0.32);

            return data * 0.32; //Fictício
        }
    }

    class PessoaJuridica : IEstrategiaImposto
    {
        public string Nome => nameof(PessoaJuridica);

        public double AplicarImposto(double data)
        {
            Console.WriteLine("Para Pessoa Jurídica");

            Console.WriteLine(data * 0.22);

            return data * 0.22; //Fictício
        }
    }

    class PagamentoContexto
    {
       IEstrategiaImposto _strategy;
              
        public PagamentoContexto(IEstrategiaImposto strategyImposto)
        {
            this._strategy = strategyImposto;
        }

        public void SetEstrategiaImposto(IEstrategiaImposto strategy)
        {
            this._strategy = strategy;
        }

        public double AplicarImposto(Double salario)
        {
            Console.WriteLine("Aplicando imposto...");

            return (this._strategy.AplicarImposto(salario));
        }
    }



}