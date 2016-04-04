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

        
        public static List<SumárioTotalAcertoItem> Obter(Entidades.Pessoa.Pessoa pessoa)
        {
            StringBuilder cmd = new StringBuilder();

            ulong códigoPessoa = pessoa.Código;

            cmd.Append(" select 'Saida' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice, ");
            cmd.Append(" round(sum(i.peso*quantidade),2) as peso, ");
            cmd.Append(" round(sum(indice*quantidade*a.cotacao),2) as preco, ");
            cmd.Append(" sum(quantidade) as qtd from saida s ");
            cmd.Append(" join saidaitem i on s.codigo=i.saida ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" join acertoconsignado a on s.acerto=a.codigo AND dataEfetiva is null ");
            cmd.Append(" WHERE a.cliente= ");
            cmd.Append(DbTransformar(códigoPessoa));

            cmd.Append(" group by m.depeso ");
            cmd.Append(" UNION  ");
            cmd.Append(" select 'Retorno' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice, ");
            cmd.Append(" round(sum(i.peso*quantidade),2) as peso, ");
            cmd.Append(" round(sum(indice*quantidade*a.cotacao),2) as preco, ");
            cmd.Append(" sum(quantidade) as qtd ");
            cmd.Append(" from retorno r ");
            cmd.Append(" join retornoitem i on r.codigo=i.retorno ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" join acertoconsignado a on r.acerto=a.codigo AND dataEfetiva is null ");
            cmd.Append(" WHERE a.cliente= ");
            cmd.Append(DbTransformar(códigoPessoa));

            cmd.Append(" group by m.depeso ");
            cmd.Append(" UNION ");
            cmd.Append(" select 'Venda' as tipo, depeso, round(sum(indice),2) as indice, round(sum(peso),2) as peso, round(sum(preco),2) as preco, sum(qtd) as qtd from ");
            cmd.Append(" (select m.referencia, m.depeso as depeso, round(sum(indice*quantidade),2) as indice,  round(sum(i.peso*quantidade),2) as peso, round(sum(indice*quantidade*a.cotacao),2) as preco, sum(quantidade) as qtd ");
            cmd.Append(" from venda v ");
            cmd.Append(" join vendaitem i on v.codigo=i.venda ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" join acertoconsignado a on v.acerto=a.codigo AND dataEfetiva is null ");
            cmd.Append(" WHERE a.cliente= ");
            cmd.Append(DbTransformar(códigoPessoa));

            cmd.Append(" group by m.referencia ");
            cmd.Append(" UNION ");
            cmd.Append(" select m.referencia, m.depeso as depeso, round(sum(-1*indice*quantidade),2) as indice,  round(sum(-1*i.peso*quantidade),2) as peso, round(sum(-1*indice*quantidade*a.cotacao),2) as preco, round(sum(-1*quantidade),2) as qtd ");
            cmd.Append(" from venda v ");
            cmd.Append(" join vendadevolucao i on v.codigo=i.venda ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" join acertoconsignado a on v.acerto=a.codigo AND dataEfetiva is null ");
            cmd.Append(" WHERE a.cliente= ");
            cmd.Append(DbTransformar(códigoPessoa));

            cmd.Append(" group by m.referencia) cc ");
            cmd.Append(" group by depeso ");
            

            return Mapear<SumárioTotalAcertoItem>(cmd.ToString());
        }

        public static List<SumárioTotalAcertoItem> Obter(AcertoConsignado entidade)
        {
            StringBuilder cmd = new StringBuilder();

            double cotação = entidade.Cotação.HasValue ? entidade.Cotação.Value : 0;
            ulong códigoAcerto = entidade.Código;


/*
set @acerto := 18762;
set @cotacao := (select cotacao from acertoconsignado where codigo = @acerto);

select 'Saida' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice,
round(sum(i.peso*quantidade),2) as peso,
round(sum(indice*quantidade*@cotacao),2) as preco,
sum(quantidade) as qtd from saida s
join saidaitem i on s.codigo=i.saida
join mercadoria m on i.referencia=m.referencia
where acerto=@acerto
group by m.depeso

UNION

select 'Retorno' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice,
round(sum(i.peso*quantidade),2) as peso,
round(sum(indice*quantidade*@cotacao),2) as preco,
sum(quantidade) as qtd
 from retorno r
join retornoitem i on r.codigo=i.retorno
join mercadoria m on i.referencia=m.referencia
where acerto=@acerto
group by m.depeso

UNION

select 'Venda' as tipo, depeso, round(sum(indice),2) as indice, round(sum(peso),2) as peso, round(sum(preco),2) as preco, sum(qtd) as qtd from
(select m.referencia, m.depeso as depeso, round(sum(indice*quantidade),2) as indice,  round(sum(i.peso*quantidade),2) as peso, round(sum(indice*quantidade*@cotacao),2) as preco, sum(quantidade) as qtd
from venda v
join vendaitem i on v.codigo=i.venda
join mercadoria m on i.referencia=m.referencia
where acerto=@acerto
group by m.referencia
UNION
select m.referencia, m.depeso as depeso, round(sum(-1*indice*quantidade),2) as indice,  round(sum(-1*i.peso*quantidade),2) as peso, round(sum(-1*indice*quantidade*@cotacao),2) as preco, round(sum(-1*quantidade),2) as qtd
from venda v
join vendadevolucao i on v.codigo=i.venda
join mercadoria m on i.referencia=m.referencia
where acerto=@acerto
group by m.referencia) cc
group by depeso
*/

            cmd.Append(" select 'Saida' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice,  ");
            cmd.Append(" round(sum(i.peso*quantidade),2) as peso, ");
            cmd.Append(" round(sum(indice*quantidade* ");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" ),2) as preco, ");
            cmd.Append(" sum(quantidade) as qtd from saida s  ");
            cmd.Append(" join saidaitem i on s.codigo=i.saida ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" where acerto= ");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" group by m.depeso UNION  select 'Retorno' as tipo, m.depeso, round(sum(indice*quantidade),2) as indice,  ");
            cmd.Append(" round(sum(i.peso*quantidade),2) as peso, ");
            cmd.Append(" round(sum(indice*quantidade* ");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" ),2) as preco, ");
            cmd.Append(" sum(quantidade) as qtd  ");
            cmd.Append("  from retorno r  ");
            cmd.Append(" join retornoitem i on r.codigo=i.retorno ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" where acerto= ");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" group by m.depeso UNION select 'Venda' as tipo, depeso, round(sum(indice),2) as indice, round(sum(peso),2) as peso, round(sum(preco),2) as preco, sum(qtd) as qtd from  ");
            cmd.Append(" (select m.referencia, m.depeso as depeso, round(sum(indice*quantidade),2) as indice,  round(sum(i.peso*quantidade),2) as peso, round(sum(indice*quantidade* ");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" ),2) as preco, sum(quantidade) as qtd  ");
            cmd.Append(" from venda v  ");
            cmd.Append(" join vendaitem i on v.codigo=i.venda ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" where acerto= ");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" group by m.referencia ");
            cmd.Append(" UNION ");
            cmd.Append(" select m.referencia, m.depeso as depeso, round(sum(-1*indice*quantidade),2) as indice,  round(sum(-1*i.peso*quantidade),2) as peso, round(sum(-1*indice*quantidade* ");
            cmd.Append(DbTransformar(cotação));
            cmd.Append(" ),2) as preco, round(sum(-1*quantidade),2) as qtd  ");
            cmd.Append(" from venda v  ");
            cmd.Append(" join vendadevolucao i on v.codigo=i.venda ");
            cmd.Append(" join mercadoria m on i.referencia=m.referencia ");
            cmd.Append(" where acerto= ");
            cmd.Append(DbTransformar(códigoAcerto));
            cmd.Append(" group by m.referencia) cc ");
            cmd.Append(" group by depeso ");



            return Mapear<SumárioTotalAcertoItem>(cmd.ToString());
        }

    }
}
