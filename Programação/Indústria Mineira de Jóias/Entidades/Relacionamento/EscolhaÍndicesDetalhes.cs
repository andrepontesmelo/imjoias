using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acesso.Comum;

namespace Entidades.Relacionamento
{
    public class EscolhaÍndicesDetalhes : DbManipulaçãoSimples
    {
#pragma warning disable 0649
        private DateTime data;
        private int codigoSaida;
        [DbRelacionamento("Código", "funcionario")]
        private Entidades.Pessoa.Pessoa funcionario;
        private double indice;

#pragma warning restore 0649
        public static List<EscolhaÍndicesDetalhes> Obter(ulong acerto, 
            Entidades.Mercadoria.Mercadoria mercadoria)
        {
            return Mapear<EscolhaÍndicesDetalhes>(
             "select saidaitem.data as data, saida.codigo as codigoSaida, " + 
             " funcionario,  indice from saida, saidaitem " + 
             " where saida.codigo=saidaitem.saida " + 
             " and referencia=" + DbTransformar(mercadoria.ReferênciaNumérica) + 
             " and acerto=" + DbTransformar(acerto) + 
             " group by indice, saidaitem.data, saida.codigo, funcionario;");
        }

        public override string ToString()
        {
            return "Em " + data.ToShortDateString() + " às " + data.ToShortTimeString() + ", " +
                funcionario.Nome + " relacionou esta referência na saida #" + codigoSaida.ToString() +
                " com índice " + indice.ToString();
        }
    }
}
