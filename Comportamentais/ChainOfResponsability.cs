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
        public bool Aprovado { get; set; }
        public string Revisor { get; set; }
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
                Revisor = "TicketAtendimento Analista Nível 1"
            };

            if (!string.IsNullOrWhiteSpace(document.Conteudo))
            {
                if (document.Conteudo.Length > 777)
                    return Proximo.Resultado(document);
                if (document.Conteudo.Length <= 777)
                    resultado.Aprovado = true;
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
                Revisor = "TicketAtendimento Especialista Técnico Nível 2"
            };
            resultado.Aprovado = !string.IsNullOrWhiteSpace(document.Conteudo) && document.Conteudo.Length > 1000;
            return resultado;
        }
    }
}
