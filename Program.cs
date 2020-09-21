using System;
using DesignPatterns.Comportamentais.Strategy;


namespace DesignPatterns
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            IStrategy iPessoa;

            Pagamento pagamento = new Pagamento();
            Console.WriteLine("Imposto: Estratégia para Pessoa Física");

            iPessoa = new PessoaFisica();

            pagamento.SetImposto(iPessoa);
            pagamento.AplicarImposto(10000);

            Console.WriteLine("Imposto: Estratégia para Pessoa Jurídica.");

            iPessoa = new PessoaJuridica();

            pagamento.SetImposto(iPessoa);
            pagamento.AplicarImposto(10000);

            Console.ReadLine();
        }
    }
}
