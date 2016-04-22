using System.Collections.Generic;
using System.Text;

namespace Entidades.ComissãoCálculo.Impressão
{
    public class ImpressãoCompartilhada : Impressão
    {
        private string nomerepresentante;

        public string Representante
        {
            get { return nomerepresentante; }
            set { nomerepresentante = value; }
        }
        private string nomevendedor;

        public string Vendedor
        {
            get { return nomevendedor; }
            set { nomevendedor = value; }
        }
        private string nomecomissaopara;

        public string Comissaopara
        {
            get { return nomecomissaopara; }
            set { nomecomissaopara = value; }
        }
        private double valorv;

        public double Valorv
        {
            get { return valorv; }
            set { valorv = value; }
        }
        private double valorc;

        public double Valorc
        {
            get { return valorc; }
            set { valorc = value; }
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

        public ImpressãoCompartilhada()
        { }

        public static List<ImpressãoCompartilhada> Obter(Comissão c, Filtro filtro)
        {
            StringBuilder str = new StringBuilder();

//select nomerepresentante, nomevendedor, nomecomissaopara, sum(valorv)  as valorv, sum(valorc) as valorc, sum(valore) as valore from 
//(
//select vdor.nome as nomevendedor, rep.nome as nomerepresentante, cp.nome as nomecomissaopara,valorv, valorc, 0 as valore from comissao_venda  cv
//join venda v on cv.venda=v.codigo
//join pessoa cli on cli.codigo=v.cliente
//join regiao r on cli.regiao=r.codigo
//join representante re on re.codigo=r.representante
//join pessoa rep on rep.codigo=r.representante
//join pessoa vdor on vdor.codigo=v.vendedor
//join pessoa cp on cp.codigo=cv.comissaopara
//join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=7
//where regra = 7 
//UNION ALL select vdor.nome as nomevendedor, rep.nome as nomerepresentante, cp.nome as nomecomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda  cv
//join venda v on cv.venda=v.codigo
//join pessoa cli on cli.codigo=v.cliente
//join regiao r on cli.regiao=r.codigo
//join representante re on re.codigo=r.representante
//join pessoa rep on rep.codigo=r.representante
//join pessoa vdor on vdor.codigo=v.vendedor
//join pessoa cp on cp.codigo=cv.comissaopara
//join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=7
//where regra = 7 
//) vvv group by nomerepresentante, nomevendedor, nomecomissaopara order by nomerepresentante, nomevendedor, valore desc


            str.Append(" select nomerepresentante, nomevendedor, nomecomissaopara, sum(valorv)  as valorv, sum(valorc) as valorc, sum(valore) as valore from ( select vdor.nome as nomevendedor, rep.nome as nomerepresentante, cp.nome as nomecomissaopara,valorv, valorc, 0 as valore from comissao_venda cv");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cli on cli.codigo=v.cliente join regiao r on cli.regiao=r.codigo join representante re on re.codigo=r.representante join pessoa rep on rep.codigo=r.representante join pessoa vdor on vdor.codigo=v.vendedor join pessoa cp on cp.codigo=cv.comissaopara join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" AND regra=7 ");
            str.Append(" UNION ALL select vdor.nome as nomevendedor, rep.nome as nomerepresentante, cp.nome as nomecomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda cv ");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cli on cli.codigo=v.cliente join regiao r on cli.regiao=r.codigo join representante re on re.codigo=r.representante join pessoa rep on rep.codigo=r.representante ");
            str.Append(" join pessoa vdor on vdor.codigo=v.vendedor join pessoa cp on cp.codigo=cv.comissaopara join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" AND regra =7 ");
            str.Append(" ) vvv group by nomerepresentante, nomevendedor, nomecomissaopara order by nomerepresentante, nomevendedor, sum(valorc)-sum(valore)  " );
            return Mapear<ImpressãoCompartilhada>(str.ToString());
        }

        public double APagar
        {
            get
            {
                return Valorc - valore;
            }
        }
    }
}
