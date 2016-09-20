using System.Collections.Generic;
using System.Text;

namespace Entidades.Comissão.Impressão
{
    public class ImpressãoResumo : Impressão
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

        protected long codigocomissaopara;

        public long CódigoComissãoPara
        {
            get { return codigocomissaopara;  }
            set { codigocomissaopara = value; }
        }

        public double Valorv
        {
            get { return valorv; }
            set { valorv = value; }
        }

        private double faturamentocompartilhado;

        public double FaturamentoCompartilhado
        {
            get { return faturamentocompartilhado; }
            set { faturamentocompartilhado = value; }
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

            //select nomecomissaopara, codigocomissaopara, setor, sum(valorv) as valorv, sum(faturamentocompartilhado) as faturamentocompartilhado, sum(valorc) as valorc, sum(valore) as valore from
            //(select distinct v.codigo, s.nome as setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as faturamentocompartilhado, 0 as valorc, 0 as valore from comissao_venda cv
            //join venda v on cv.venda = v.codigo
            //join pessoa cp on cp.codigo = cv.vendedor
            //join setor s on cp.setor = s.codigo
            //join comissaovenda cve on cve.venda = cv.venda and cve.comissao = 19 AND cve.pessoa=v.vendedor
            //UNION ALL
            //select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, 0 as valorv, 0 as faturamentocompartilhado, valorc, 0 as valore from comissao_venda cv
            //join venda v on cv.venda = v.codigo
            //join pessoa cp on cp.codigo = cv.comissaopara
            //join setor s on cp.setor = s.codigo
            //join comissaovenda cve on cve.venda = cv.venda and cve.pessoa = v.vendedor and cve.comissao = 3
            //UNION ALL
            //select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as faturamentocompartilhado, 0 as valorc, valorc as valore from comissao_venda cv
            //join venda v on cv.venda = v.codigo
            //join pessoa cp on cp.codigo = cv.comissaopara
            //join setor s on cp.setor = s.codigo
            //join comissaoestornovenda cve on cve.venda = cv.venda and cve.pessoa = v.vendedor and cve.comissao = 3  AND cve.pessoa=v.vendedor
            //UNION ALL
            //select 0 as codigo, 'Representante' as setor, p.nome as nomecomissaopara, p.codigo as codigocomissaopara, 0 as valorv, sum(valorv) as faturamentocompartilhado, 0 as valorc, 0 as valore
            //from representante r join pessoa p on r.codigo = p.codigo join comissao_venda c_v on p.codigo = c_v.comissaopara

            //  WHERE c_v.comissaopara != c_v.vendedor and venda in (select venda from comissaovenda where comissao = 16)
            //group by p.nome)
            //            ee WHERE codigocomissaopara=29480 group by nomecomissaopara order by (sum(valorc) - sum(valore)) desc

            str.Append(" select nomecomissaopara, codigocomissaopara, setor, sum(valorv) as valorv, sum(faturamentocompartilhado) as faturamentocompartilhado, sum(valorc) as valorc, sum(valore) as valore from ");
            str.Append(" (select distinct v.codigo, s.nome as setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as faturamentocompartilhado, 0 as valorc, 0 as valore from comissao_venda cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join pessoa cp on cp.codigo=cv.vendedor ");
            str.Append(" join setor s on cp.setor = s.codigo ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            str.Append(" AND cve.pessoa=v.vendedor ");
            AplicarFiltro(str, filtro);
            str.Append(" UNION ALL ");
            str.Append(" select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, 0 as valorv, 0 as faturamentocompartilhado, valorc, 0 as valore from comissao_venda cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join setor s on cp.setor = s.codigo ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" UNION ALL ");
            str.Append(" select v.codigo, s.nome as setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as faturamentocompartilhado, 0 as valorc, valorc as valore from comissao_venda  cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join setor s on cp.setor = s.codigo ");
            str.Append(" join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=v.vendedor and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" UNION ALL ");
            str.Append(" select 0 as codigo,  'Representante' as setor, p.nome as nomecomissaopara, p.codigo as codigocomissaopara, 0 as valorv, sum(valorv) as faturamentocompartilhado, 0 as valorc, 0 as valore ");
            str.Append(" from representante r join pessoa p on r.codigo=p.codigo join comissao_venda c_v on p.codigo=c_v.comissaopara ");
            str.Append(" WHERE c_v.comissaopara != c_v.vendedor ");
            str.Append(" AND venda IN ");
            str.Append(ObterSqlVendasData(filtro.DataInicial, filtro.DataFinal));

            if (filtro.Funcionário != null)
            {
                str.Append(" AND comissaopara = ");
                str.Append(DbTransformar(filtro.Funcionário.Código));
            }

            str.Append(" AND venda in (select venda from comissaovenda where comissao=");
            str.Append(DbTransformar(c.Código));
            str.Append(") group by p.nome) ee ");

            if (filtro.Funcionário != null)
            {
                str.Append(" WHERE codigocomissaopara = ");
                str.Append(DbTransformar(filtro.Funcionário.Código));
            }

            str.Append(" group by nomecomissaopara order by (sum(valorc)-sum(valore)) desc ");
 
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
