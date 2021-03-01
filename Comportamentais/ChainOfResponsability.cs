using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Comportamentais.ChainOfResponsability
{
    public class TicketAtendimento
    {
        public string Conteudo { get; set; }
        public long Id { get; set; }
    }

    public class ResultadoDaAnalise
    {
        public bool Resolvido { get; set; }
        public string Atendente { get; set; }
    }

    public interface IAtendente
    {
        ResultadoDaAnalise Resultado(TicketAtendimento ticket);
    }

    public class Analista : IAtendente
    {
        public IAtendente Proximo { get; private set; }
        public Analista(IAtendente proximo)
        {
            Proximo = proximo;
        }

        public ResultadoDaAnalise Resultado(TicketAtendimento document)
        {
            ResultadoDaAnalise resultado = new ResultadoDaAnalise()
            {
                Atendente = "TicketAtendimento Analista Nível 1"
            };

            if (!string.IsNullOrWhiteSpace(document.Conteudo))
            {
                if (document.Conteudo.Length > 777)
                    return Proximo.Resultado(document);
                else
                    resultado.Resolvido = true;
            }
            return resultado;
        }
    }

    public class EspecialistaTecnico : IAtendente
    {
        public ResultadoDaAnalise Resultado(TicketAtendimento document)
        {
            ResultadoDaAnalise resultado = new ResultadoDaAnalise()
            {
                Atendente = "TicketAtendimento Especialista Técnico Nível 2"
            };
            resultado.Resolvido = !string.IsNullOrWhiteSpace(document.Conteudo) && document.Conteudo.Length > 1000;
            return resultado;
        }
    }
}
