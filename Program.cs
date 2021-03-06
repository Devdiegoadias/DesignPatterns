using System;
using System.Collections.Generic;
using DesignPatterns.Comportamentais.ChainOfResponsability;
using DesignPatterns.Comportamentais.Strategy;


namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             /////// PADRÃO STRATEGY

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
            */

            /// PADRÃO CHAIN OF RESPONSABILITY
            /// 
            List<TicketAtendimento> chamados = new List<TicketAtendimento>()
                {
                    new TicketAtendimento() { Id = 1, Conteudo = new string('*', 500)},
                    new TicketAtendimento() { Id = 2, Conteudo = new string('*', 850)},
                    new TicketAtendimento() { Id = 3, Conteudo = new string('*', 1500)}
                };

            IAtendente vAtendente = new Analista(new EspecialistaTecnico(new GerenteArea()));
            
            chamados.ForEach(x =>
            {
                var resultado = vAtendente.Resultado(x);
                Console.WriteLine(resultado.Resolvido ? "Ticket {0} Aceito por {1}"
                    : "Ticket {0} Não aceito Por {1}",x.Id, resultado.Atendente);
            });

        }
    }
}
