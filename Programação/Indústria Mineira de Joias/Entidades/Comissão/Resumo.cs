using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Comissão
{
    public class Resumo : DbManipulaçãoAutomática
    {
        ulong pessoa;

        public ulong Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }
        double comissaoaberta;

        public double Comissaoaberta
        {
            get { return comissaoaberta; }
            set { comissaoaberta = value; }
        }
        double comissaofechada;

        public double Comissaofechada
        {
            get { return comissaofechada; }
            set { comissaofechada = value; }
        }
        double estorno;

        public double Estorno
        {
            get { return estorno; }
            set { estorno = value; }
        }

        public double AReceber
        {
            get
            {
                return comissaofechada - estorno;
            }
        }

        public Resumo()
        {

            //select codigo as pessoa, a.comissaoaberta, b.comissaofechada, ce.estorno as estorno from pessoa vcp 

            //left JOIN (
            //    select comissaopara, sum(c.valorc) as comissaoaberta from comissao_venda c 
            //    left join comissaovenda v on c.venda=v.venda and c.comissaopara=v.pessoa
            //    where v.comissao is null  group by comissaopara) a
            //ON vcp.codigo=a.comissaopara

            //left JOIN (
            //    select comissaopara, sum(c.valorc) as comissaofechada from comissao_venda c 
            //    join comissaovenda v on c.venda=v.venda and c.comissaopara=v.pessoa and v.comissao=2
            //    group by comissaopara) b    
            //ON vcp.codigo=b.comissaopara

            //LEFT JOIN (
            //    select comissaopara, sum(c.valorc) as estorno from comissao_venda c 
            //    join comissaoestornovenda v on c.venda=v.venda and c.comissaopara=v.pessoa and v.comissao=2
            //    group by comissaopara) ce    
            //ON vcp.codigo=ce.comissaopara 

            //where (a.comissaoaberta is not null OR b.comissaofechada is not null OR ce.estorno is not null)
        }

        public static List<Resumo> Obter(int códigoComissão)
        {
            string códigoComissãoTransformada = DbTransformar(códigoComissão);

            string consulta = " select codigo as pessoa, a.comissaoaberta, b.comissaofechada, ce.estorno as estorno from pessoa vcp left JOIN ( select comissaopara, sum(c.valorc) as comissaoaberta from comissao_venda c " +
                " left join comissaovenda v on c.venda=v.venda and c.comissaopara=v.pessoa where v.comissao is null  group by comissaopara) a ON vcp.codigo=a.comissaopara left JOIN ( " +
                " select comissaopara, sum(c.valorc) as comissaofechada from comissao_venda c join comissaovenda v on c.venda=v.venda and c.comissaopara=v.pessoa and v.comissao= " + códigoComissãoTransformada +
                " group by comissaopara) b ON vcp.codigo=b.comissaopara LEFT JOIN ( select comissaopara, sum(c.valorc) as estorno from comissao_venda c " +
                " join comissaoestornovenda v on c.venda=v.venda and c.comissaopara=v.pessoa and v.comissao = " + códigoComissãoTransformada +
                " group by comissaopara) ce ON vcp.codigo=ce.comissaopara where (a.comissaoaberta is not null OR b.comissaofechada is not null OR ce.estorno is not null) ";

            return Mapear<Resumo>(consulta);
        }
    }
}
