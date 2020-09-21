using System;
using System.Collections.Generic;

namespace DesignPatterns.Comportamentais.Strategy
{

    public class Pagamento
    {
        private IStrategy _strategy;

        public Pagamento()
        { }

        public Pagamento(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetImposto(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public double AplicarImposto(Double salario)
        {
            Console.WriteLine("Aplicando imposto...");

            return (this._strategy.AplicandoDesconto(salario));
        }
    }

    public interface IStrategy
    {
        double AplicandoDesconto(double data);
    }

    public class PessoaFisica : IStrategy
    {
        public double AplicandoDesconto(double data)
        {
            Console.WriteLine("Para Pessoa Física");

            Console.WriteLine(data * 73 / 100);

            return data * 73 / 100; //Fictício
        }
    }

    public class PessoaJuridica : IStrategy
    {
        public double AplicandoDesconto(double data)
        {
            Console.WriteLine("Para Pessoa Jurídica");

            Console.WriteLine(data * 80 / 100);

            return data * 80 / 100; //Fictício
        }
    }
}