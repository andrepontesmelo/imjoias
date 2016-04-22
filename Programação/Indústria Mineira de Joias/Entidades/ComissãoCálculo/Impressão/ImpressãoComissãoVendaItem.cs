using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ComissãoCálculo.Impressão
{
    public class ImpressãoComissãoVendaItem : ImpressãoComissãoVenda
    {

        private string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }
        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private Boolean depeso;

        public Boolean Depeso
        {
            get { return depeso; }
            set { depeso = value; }
        }
        private double quantidade;

        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        private double indice;

        public double Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        private string faixa;

        public string Faixa
        {
            get { return faixa; }
            set { faixa = value; }
        }
        private int? grupo;

        public int? Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }


        public static new List<ImpressãoComissãoVendaItem> Obter(Comissão c, Filtro filtro)
        {
            StringBuilder str = new StringBuilder();

            //select * from 
            //(select vi.referencia, m.faixa, m.grupo,  vi.peso, m.depeso, vi.quantidade, vi.indice, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv) as valorv, sum(valorc) as valorc, 0 as valore from comissao_valor  cv
            //join venda v on cv.venda=v.codigo
            //join vendaitem vi on vi.codigo=cv.vendaitem
            //join mercadoria m on vi.referencia=m.referencia
            //join pessoa cp on cp.codigo=cv.comissaopara
            //join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
            //group by cv.venda, cv.comissaopara, vi.referencia, vi.peso) aa
            //UNION (select vi.referencia, m.faixa, m.grupo, vi.peso, m.depeso, vi.quantidade, vi.indice, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv), 0 as valorc, sum(valorc) as valore from comissao_valor  cv
            //join venda v on cv.venda=v.codigo
            //join vendaitem vi on vi.codigo=cv.vendaitem
            //join mercadoria m on vi.referencia=m.referencia
            //join pessoa cp on cp.codigo=cv.comissaopara
            //join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
            //group by cv.venda, cv.comissaopara, vi.referencia, vi.peso) 
            // UNION
            //(select vd.referencia, m.faixa, m.grupo, vd.peso, m.depeso, -1*vd.quantidade as quantidade, vd.indice, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv) as valorv, sum(valorc) as valorc, 0 as valore from comissao_valor  cv
            //join venda v on cv.venda=v.codigo
            //join vendadevolucao vd on vd.codigo=cv.vendadevolucao
            //join mercadoria m on vd.referencia=m.referencia
            //join pessoa cp on cp.codigo=cv.comissaopara
            //join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
            //group by cv.venda, cv.comissaopara, vd.referencia, vd.peso) 
            //UNION (select vd.referencia, m.faixa, m.grupo, vd.peso, m.depeso, -1*vd.quantidade as quantidade, vd.indice, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv), 0 as valorc, sum(valorc) as valore from comissao_valor  cv
            //join venda v on cv.venda=v.codigo
            //join vendadevolucao vd on vd.codigo=cv.vendadevolucao
            //join mercadoria m on vd.referencia=m.referencia
            //join pessoa cp on cp.codigo=cv.comissaopara
            //join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
            //group by cv.venda, cv.comissaopara, vd.referencia, vd.peso) 

            //order by data, nomecomissaopara


            str.Append(" select * from ");
            str.Append(" (select v.desconto, vi.referencia, m.faixa, m.grupo, vi.peso, m.depeso, sum(vi.quantidade) as quantidade, sum(vi.indice) as indice, v.data as data, ");
            str.Append(" v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv) as valorv, sum(valorc) as valorc, 0 as valore from comissao_valor  cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join vendaitem vi on vi.codigo=cv.vendaitem ");
            str.Append(" join mercadoria m on vi.referencia=m.referencia ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" group by cv.venda, cv.comissaopara, vi.referencia, vi.peso, regra) aa ");
            str.Append(" UNION (select v.desconto, vi.referencia, m.faixa, m.grupo, vi.peso, m.depeso, sum(vi.quantidade) as quantidade, sum(vi.indice) as indice, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara,  ");
            str.Append(" cv.venda, sum(valorv), 0 as valorc, sum(valorc) as valore from comissao_valor  cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join vendaitem vi on vi.codigo=cv.vendaitem ");
            str.Append(" join mercadoria m on vi.referencia=m.referencia ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" group by cv.venda, cv.comissaopara, vi.referencia, vi.peso, regra)  UNION ");
            str.Append(" (select v.desconto, vd.referencia, m.faixa, m.grupo, vd.peso, m.depeso, sum(-1*vd.quantidade) as quantidade, sum(vd.indice) as indice, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv) as valorv, sum(valorc) as valorc, 0 as valore from comissao_valor  cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join vendadevolucao vd on vd.codigo=cv.vendadevolucao ");
            str.Append(" join mercadoria m on vd.referencia=m.referencia ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" group by cv.venda, cv.comissaopara, vd.referencia, vd.peso, regra)  ");
            str.Append(" UNION (select v.desconto, vd.referencia, m.faixa, m.grupo, vd.peso, m.depeso, sum(-1*vd.quantidade) as quantidade, sum(vd.indice) as indice, v.data as data, v.cliente, regra, ");
            str.Append(" cp.nome as nomecomissaopara, cv.venda, sum(valorv), 0 as valorc, sum(valorc) as valore from comissao_valor  cv ");
            str.Append(" join venda v on cv.venda=v.codigo ");
            str.Append(" join vendadevolucao vd on vd.codigo=cv.vendadevolucao ");
            str.Append(" join mercadoria m on vd.referencia=m.referencia ");
            str.Append(" join pessoa cp on cp.codigo=cv.comissaopara ");
            str.Append(" join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao= ");
            str.Append(DbTransformar(c.Código));
            AplicarFiltro(str, filtro);
            str.Append(" group by cv.venda, cv.comissaopara, vd.referencia, vd.peso, regra)  ");
            str.Append(" order by data, nomecomissaopara ");
             
            return Mapear<ImpressãoComissãoVendaItem>(str.ToString());
        }

        public override void ObterImpressão(System.Data.DataTable tabelaItens)
        {
            base.ObterImpressão(tabelaItens);

            int indice = tabelaItens.Rows.Count - 1;
            tabelaItens.Rows[indice]["referencia"] = Entidades.Mercadoria.Mercadoria.MascararReferência(Referencia, true);
            tabelaItens.Rows[indice]["depeso"] = Depeso;
            tabelaItens.Rows[indice]["peso"] = Peso;
            tabelaItens.Rows[indice]["quantidade"] = Quantidade;
            tabelaItens.Rows[indice]["indice"] = Indice;
            tabelaItens.Rows[indice]["faixa"] = Faixa;
            tabelaItens.Rows[indice]["grupo"] = Grupo;
        }
    }
}

