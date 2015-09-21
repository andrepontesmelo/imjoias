using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Acerto.Sumário
{
    public class SumárioTotalAcertoItem : SumárioTotalAcertoItemValores
    {
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private bool depeso;

        public bool Depeso
        {
            get { return depeso; }
            set { depeso = value; }
        }
        
        public SumárioTotalAcertoItem()
        {

        }

        public static List<SumárioTotalAcertoItem> Obter(AcertoConsignado entidade)
        {
            StringBuilder cmd = new StringBuilder();

            double cotação = entidade.Cotação.HasValue ? entidade.Cotação.Value : 0;
            ulong códigoAcerto = entidade.Código;
            
            cmd.Append(" select 'Saida' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice,   round(sum(i.peso*quantidade),2) as peso,  round(sum(indice*quantidade* ");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" ),2) as preco,  sum(quantidade) as qtd   from saida s   join saidaitem i on s.codigo=i.saida  join mercadoria m on i.referencia=m.referencia  where acerto=");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" group by m.depeso  UNION   select 'Retorno' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice,   round(sum(i.peso*quantidade),2) as peso,  round(sum(indice*quantidade*");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" ),2) as preco,  sum(quantidade) as qtd    from retorno r   join retornoitem i on r.codigo=i.retorno  join mercadoria m on i.referencia=m.referencia  where acerto=");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" group by m.depeso  UNION   select 'Venda' as tipo, depeso, round(sum(indice),2) as indice, round(sum(peso),2) as peso, round(sum(preco),2) as preco, sum(qtd) as qtd from   (select m.depeso as depeso, indice*quantidade as indice,  i.peso*quantidade as peso, indice*quantidade*");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" as preco, quantidade as qtd   from venda v   join vendaitem i on v.codigo=i.venda  join mercadoria m on i.referencia=m.referencia  where acerto=");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" UNION  select m.depeso as depeso, -1*indice*quantidade as indice,  -1*i.peso*quantidade as peso, -1*indice*quantidade*");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" as preco, -1*quantidade as qtd   from venda v   join vendadevolucao i on v.codigo=i.venda  join mercadoria m on i.referencia=m.referencia  where acerto=");
            cmd.Append(DbTransformar(códigoAcerto));            
            cmd.Append(" ) cc   group by depeso     ");
            
            return Mapear<SumárioTotalAcertoItem>(cmd.ToString());
        }

    }
}
