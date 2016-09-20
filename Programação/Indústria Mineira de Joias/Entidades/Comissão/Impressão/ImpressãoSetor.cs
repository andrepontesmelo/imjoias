using Acesso.Comum;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Comissão.Impressão
{
    public class ImpressãoSetor : ImpressãoResumo
    {
        [DbRelacionamento("codigo", "setor")]
        private Setor setor;

        public new Setor Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public static new List<ImpressãoSetor> Obter(Comissão c, Filtro filtro)
        {
            StringBuilder str = new StringBuilder();

            str.Append(" select setor, nomecomissaopara, sum(valorv) as valorv, sum(valorc) as valorc, sum(valore) as valore from ");
            str.Append(" (select distinct v.codigo, cv.setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as valorc, 0 as valore from comissao_venda cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join pessoa cp on cp.codigo=cv.vendedor ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.comissao=");
            str.Append(DbTransformar(c.Código));

            str.Append(" WHERE v.codigo IN ");
            str.Append(ObterSqlVendasData(filtro.DataInicial, filtro.DataFinal));

            str.Append(" UNION ALL select v.codigo, cv.setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, 0 as valorv, valorc, 0 as valore from comissao_venda cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=");
            str.Append(DbTransformar(c.Código));

            str.Append(" WHERE v.codigo IN ");
            str.Append(ObterSqlVendasData(filtro.DataInicial, filtro.DataFinal));

            str.Append(" UNION ALL select v.codigo, cv.setor, cp.nome as nomecomissaopara, cp.codigo as codigocomissaopara, valorv, 0 as valorc, valorc as valore from comissao_venda  cv ");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=");
            str.Append(DbTransformar(c.Código));

            str.Append(" WHERE v.codigo IN ");
            str.Append(ObterSqlVendasData(filtro.DataInicial, filtro.DataFinal));

            str.Append(" ) ee ");

            if (filtro.Funcionário != null)
            {
                str.Append(" WHERE codigocomissaopara = ");
                str.Append(DbTransformar(filtro.Funcionário.Código));
            }

            str.Append(" group by setor, nomecomissaopara order by setor, (sum(valorc)-sum(valore)) desc ");

            return Mapear<ImpressãoSetor>(str.ToString());
        }
    }
}
