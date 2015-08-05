using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Entidades.ComissãoCálculo
{
    public class ComissãoValor : DbManipulaçãoAutomática
    {
#pragma warning disable 0649

        private string clientenome;

        public string ClienteNome
        {
            get { return clientenome; }
            set { clientenome = value; }
        }

        private uint venda;

        public uint Venda
        {
            get { return venda; }
            set { venda = value; }
        }

        private uint clientecodigo;

        [DbRelacionamento("codigo", "vendedor")]
        private Pessoa.Pessoa vendedor;

        public Pessoa.Pessoa Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        [DbRelacionamento("codigo", "comissaopara")]
        private Pessoa.Pessoa comissaopara;

        public Pessoa.Pessoa ComissãoPara
        {
            get { return comissaopara; }
            set { comissaopara = value; }
        }

        [DbRelacionamento("codigo", "setor")]
        private Setor setor;

        public Setor Setor
        {
            get { return setor; }
            set { setor = value; }
        }
        private double valorv;

        public double ValorVenda
        {
            get { return valorv; }
            set { valorv = value; }
        }
        private double valorc;

        public double ValorComissão
        {
            get { return valorc; }
            set { valorc = value; }
        }

        private EnumRegra regra;

        public EnumRegra Regra
        {
            get { return regra; }
            set { regra = value; }
        }


#pragma warning restore 0649

        public ComissãoValor() { }

        public uint ClienteCódigo { get { return clientecodigo; } }


        /// <summary>
        /// Retorna valores de comissão calculados pelo banco de dados, agrupados no nível venda-pessoa-regra.
        /// aberto: para exibição no lado esquerdo da tela, ou seja, comissões em aberto.
        /// estorno: indica se é a tela de venda (estorno=falso) ou estorno. (estorno=true).
        /// 
        /// Pode-se filtrar ainda por dia inicial e final da data da venda,
        /// comissãoPara: Pessoa a receber a comissão. nulo para todas as pessoas.
        /// </summary>
        public static List<ComissãoValor> Obter(DateTime? diaInicial, DateTime? diaFinal, Pessoa.Pessoa comissãoPara, Comissão comissão, bool aberto, bool estorno)
        {
            StringBuilder cmd = new StringBuilder("select v.data as data, c.setor, p.nome as clientenome, p.codigo as clientecodigo, c.vendedor, c.comissaopara, ");
            cmd.Append(" c.venda, regra, valorc, valorv from comissao_venda c join pessoa p on c.cliente=p.codigo ");
            cmd.Append(" join venda v on c.venda=v.codigo ");

            if (!estorno)
            {
                // Não Estorno !
                if (aberto)
                    cmd.Append(" LEFT ");

                cmd.Append(" JOIN comissaovenda cv on ");

                if (!aberto)
                {
                    // Direito
                    cmd.Append(" cv.comissao=");
                    cmd.Append(DbTransformar(comissão.Código));
                    cmd.Append(" AND ");
                }

                cmd.Append(" cv.venda=c.venda AND cv.pessoa=c.comissaopara ");
            } else
            {
                // Estorno !
                cmd.Append(" LEFT JOIN comissaovenda cv on ");

                if (aberto)
                {
                    cmd.Append(" cv.comissao !=");
                    cmd.Append(DbTransformar(comissão.Código));
                    cmd.Append(" AND ");
                }

                cmd.Append(" cv.venda=c.venda AND cv.pessoa=c.comissaopara ");
            }

            cmd.Append(" LEFT JOIN comissao_saldo cs on cs.venda=v.codigo AND cs.pessoa=c.comissaopara ");

            if (estorno && !aberto)
            {
                cmd.Append(" JOIN comissaoestornovenda cve on cve.comissao=");
                cmd.Append(DbTransformar(comissão.Código));
                cmd.Append(" and cve.venda=v.codigo and cve.pessoa=c.comissaopara ");
            }

            cmd.Append(" WHERE 1=1 ");
            if (diaInicial.HasValue)
            {
                cmd.Append(" AND v.data > '");
                cmd.Append(diaInicial.Value.ToString("yyyy-MM-dd"));
                cmd.Append(" 00:00:00'");
            }

            if (diaFinal.HasValue)
            {
                cmd.Append(" AND v.data < '");
                cmd.Append(diaFinal.Value.AddDays(1).ToString("yyyy-MM-dd"));
                cmd.Append(" 00:00:00'");
            }


            if (comissãoPara != null)
            {
                cmd.Append(" AND c.comissaopara=");
                cmd.Append(DbTransformar(comissãoPara.Código));
            }

            if (estorno && aberto)
                cmd.Append(" AND ifnull(cs.saldo,0) != 0");

            if (!estorno && aberto)
                cmd.Append(" AND ifnull(cs.saldo,0) != 1");

            if (aberto)
            {
                cmd.Append("  AND (c.comissaopara,  c.venda) NOT in (select pessoa, venda from comissaovenda where comissao=");
                cmd.Append(DbTransformar(comissão.Código));
                cmd.Append(") ");

                cmd.Append("  AND (c.comissaopara,  c.venda) NOT in (select pessoa, venda from comissaoestornovenda where comissao=");
                cmd.Append(DbTransformar(comissão.Código));
                cmd.Append(") ");
            }
            
            cmd.Append(" order by v.data desc, v.codigo desc");

            List<ComissãoValor> retorno = Mapear<ComissãoValor>(cmd.ToString());

            return retorno;
        }
    }
}
