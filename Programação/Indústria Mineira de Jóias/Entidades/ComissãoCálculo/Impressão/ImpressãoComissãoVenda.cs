using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entidades.ComissãoCálculo.Impressão
{
    public class ImpressãoComissãoVenda : DbManipulaçãoAutomática
    {
        private bool comissaoparavendedor;

        public bool ComissaoParaVendedor
        {
            get { return comissaoparavendedor; }
            set { comissaoparavendedor = value; }
        }

        protected DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        protected EnumRegra regra;

        public EnumRegra Regra
        {
            get { return regra; }
            set { regra = value; }
        }
        protected string nomecomissaopara;

        public string Nomecomissaopara
        {
            get { return nomecomissaopara; }
            set { nomecomissaopara = value; }
        }
        protected long venda;

        public long Venda
        {
            get { return venda; }
            set { venda = value; }
        }
        protected long cliente;

        public long Cliente
        {
            get { return cliente; }
            set { cliente = value; }
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


        public ImpressãoComissãoVenda()
        {
        }

        public static List<ImpressãoComissãoVenda> Obter(Comissão c)
        {
            StringBuilder str = new StringBuilder();


//select * from 
//            (select v.vendedor=cv.comissaopara as comissaoparavendedor,v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv) as valorv, sum(valorc) as valorc, 0 as valore from comissao_venda  cv
//join venda v on cv.venda=v.codigo
//join pessoa cp on cp.codigo=cv.comissaopara
//join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
//group by cv.venda, cv.comissaopara) aa
//            UNION (select v.vendedor=cv.comissaopara as comissaoparavendedor, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv), 0 as valorc, sum(valorc) as valore from comissao_venda  cv
//join venda v on cv.venda=v.codigo
//join pessoa cp on cp.codigo=cv.comissaopara
//join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=3
//group by cv.venda, cv.comissaopara) order by data, nomecomissaopara


            str.Append("select * from (select v.vendedor=cv.comissaopara as comissaoparavendedor, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv) as valorv, sum(valorc) as valorc, 0 as valore from comissao_venda  cv ");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cp on cp.codigo=cv.comissaopara join comissaovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=");
            str.Append(DbTransformar(c.Código));
            str.Append(" group by cv.venda, cv.comissaopara) aa UNION (select v.vendedor=cv.comissaopara as comissaoparavendedor, v.data as data, v.cliente, regra, cp.nome as nomecomissaopara, cv.venda, sum(valorv), 0 as valorc, sum(valorc) as valore from comissao_venda  cv ");
            str.Append(" join venda v on cv.venda=v.codigo join pessoa cp on cp.codigo=cv.comissaopara join comissaoestornovenda cve on cve.venda=cv.venda and cve.pessoa=cv.comissaopara and cve.comissao=");
            str.Append(DbTransformar(c.Código));
            str.Append(" group by cv.venda, cv.comissaopara) order by data, nomecomissaopara ");

            return Mapear<ImpressãoComissãoVenda>(str.ToString());
        }

        public double APagar
        {
            get
            {
                return Valorc - valore;
            }
        }

        public virtual void ObterImpressão(DataTable tabelaItens)
        {
            DataRow item = tabelaItens.NewRow();
            item["comissaoparavendedor"] = comissaoparavendedor;
            item["codVenda"] = Venda.ToString();
            item["codCliente"] = Cliente.ToString();
            item["valorv"] = Valorv;
            item["valorc"] = Valorc;
            item["valore"] = Valore;
            item["apagar"] = APagar;
            item["data"] = Data.ToShortDateString();
            item["regra"] = Entidades.ComissãoCálculo.Regra.ObterNome(Regra);
            item["nomecomissaopara"] = Entidades.Pessoa.Pessoa.ReduzirNome(Nomecomissaopara);

            tabelaItens.Rows.Add(item);
        }

    }
}
