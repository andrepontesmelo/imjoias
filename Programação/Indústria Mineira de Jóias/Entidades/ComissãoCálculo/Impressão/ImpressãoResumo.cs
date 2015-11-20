using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.ComissãoCálculo.Impressão
{
    public class ImpressãoResumo : DbManipulaçãoAutomática
    {
        protected string nomecomissaopara;

        private string setor;

        public string Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public string Nomecomissaopara
        {
            get { return nomecomissaopara; }
            set { nomecomissaopara = value; }
        }
        protected double valorv;

        public double Valorv
        {
            get { return valorv; }
            set { valorv = value; }
        }
        protected double valorc;

        public double Valorc
        {
            get { return valorc; }
            set { valorc = value; }
        }
        protected double valore;

        public double Valore
        {
            get { return valore; }
            set { valore = value; }
        }

        public ImpressãoResumo()
        {
        }

        public static List<ImpressãoResumo> Obter(Comissão c, Filtro filtro)
        {
            StringBuilder str = new StringBuilder();

//select nomecomissaopara, setor, sum(valorv) as valorv, sum(valorc) as valorc, sum(valore) as valore from 
//(select distinct v.codigo, s.nome as setor, cp.nome as nomecomissaopara, valorv, 0 as valorc, 0 as valore from comissao_venda cv
//join venda v on cv.venda=v.codigo
//join pessoa cp on cp.codigo=cv.vendedor
//join setor s on cp.setor = s.codigo
//join comissaovenda cve on cve.venda=cv.venda and cve.comissao=3
//UNION ALL
//select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, 0 as valorv, valorc, 0 as valore from comissao_venda cv
//join venda v on cv.venda=v.codigo
//join pessoa cp on cp.codigo=cv.comissaopara
//join setor s on cp.setor = s.codigo
//join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
//UNION ALL 
//select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda  cv
//join venda v on cv.venda=v.codigo 
//join pessoa cp on cp.codigo=cv.comissaopara
//join setor s on cp.setor = s.codigo
//join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3) 
//            ee group by nomecomissaopara order by (sum(valorc)-sum(valore)) desc


            str.Append(" select nomecomissaopara, setor, sum(valorv) as valorv, sum(valorc) as valorc, sum(valore) as valore from ");
            str.Append(" (select distinct v.codigo, s.nome as setor, cp.nome as nomecomissaopara, valorv, 0 as valorc, 0 as valore from comissao_venda cv  ");
            str.Append(" join venda v on cv.venda=v.codigo  ");
            str.Append(" join pessoa cp on cp.codigo=cv.vendedor  ");
            str.Append(" join setor s on cp.setor = s.codigo  ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.comissao=  ");
            str.Append(DbTransformar(c.Código));

            str.Append(" UNION ALL  ");
            str.Append(" select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, 0 as valorv, valorc, 0 as valore from comissao_venda cv  ");
            str.Append(" join venda v on cv.venda=v.codigo  ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara  ");
            str.Append(" join setor s on cp.setor = s.codigo  ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=  ");
            str.Append(DbTransformar(c.Código));


            str.Append(" UNION ALL   ");
            str.Append(" select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda  cv  ");
            str.Append(" join venda v on cv.venda=v.codigo   ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara  ");
            str.Append(" join setor s on cp.setor = s.codigo  ");
            str.Append(" join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=  ");
            str.Append(DbTransformar(c.Código));


            str.Append(" ) ee group by nomecomissaopara, setor order by (sum(valorc)-sum(valore)) desc   ");


            return Mapear<ImpressãoResumo>(str.ToString());
        }

        public double APagar
        {
            get
            {
                return Valorc - Valore;
            }
        }
    }
}
