using System.Collections.Generic;
using System.Text;

namespace Entidades.Comissão.Impressão
{
    public class ImpressãoRegraPessoa : Impressão
    {
        private string nomecomissaopara;

        public string Nomecomissaopara
        {
            get { return nomecomissaopara; }
            set { nomecomissaopara = value; }
        }
        private double valorc;

        public double Valorc
        {
            get { return valorc; }
            set { valorc = value; }
        }
        private double valorv;

        public double Valorv
        {
            get { return valorv; }
            set { valorv = value; }
        }
        private double apagar;

        public double Apagar
        {
            get { return apagar; }
            set { apagar = value; }
        }
        private double valore;

        public double Valore
        {
            get { return valore; }
            set { valore = value; }
        }

        private EnumRegra regra;

        public EnumRegra Regra
        {
            get { return regra; }
            set { regra = value; }
        }

        public ImpressãoRegraPessoa() { }

        public static List<ImpressãoRegraPessoa> Obter(Comissão c, Filtro filtro)
        {
            StringBuilder str = new StringBuilder();


//select regra, nomecomissaopara, sum(valorv) as valorv, sum(valorc) as valorc, sum(valore) as valore from 
//(
//select regra, cp.nome as nomecomissaopara, valorv, valorc, 0 as valore from comissao_venda cv
//join venda v on cv.venda=v.codigo
//join pessoa cp on cp.codigo=cv.comissaopara
//join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=7
//UNION ALL select regra, cp.nome as nomecomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda  cv
//join venda v on cv.venda=v.codigo
//join pessoa cp on cp.codigo=cv.comissaopara
//join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=7
//) vvv group by regra, nomecomissaopara


            str.Append(" select regra, nomecomissaopara, sum(valorv) as valorv, sum(valorc) as valorc, sum(valore) as valore from ( select regra, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, valorc, 0 as valore from comissao_venda  cv ");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cp on cp.codigo=cv.comissaopara join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" UNION ALL select regra, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda  cv ");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cp on cp.codigo=cv.comissaopara join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" ) vvv ");

            str.Append(" group by regra, nomecomissaopara having abs( sum(valorc)-sum(valore) ) > 0.01 order by regra, sum(valorc)-sum(valore) desc");

            return Mapear<ImpressãoRegraPessoa>(str.ToString());
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
