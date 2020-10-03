using System;
using DesignPatterns.Comportamentais.Strategy;


namespace DesignPatterns
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            IEstrategiaImposto iTipoPessoaStrategia;
            
            iTipoPessoaStrategia = new PessoaFisica();

            PagamentoContexto pagamento = new PagamentoContexto(iTipoPessoaStrategia);
            Console.WriteLine("Imposto: Estratégia para Pessoa Física");

            pagamento.AplicarImposto(10000);

            Console.WriteLine("Imposto: Estratégia para Pessoa Jurídica.");

            iTipoPessoaStrategia = new PessoaJuridica();

            pagamento.SetEstrategiaImposto(iTipoPessoaStrategia);
            
            pagamento.AplicarImposto(10000);

            Console.ReadLine();
        }
    }
}
