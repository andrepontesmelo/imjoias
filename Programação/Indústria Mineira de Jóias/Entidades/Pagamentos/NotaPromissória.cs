using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Acesso.Comum;
using System.Data;
using Entidades.Relacionamento.Venda;
using Entidades.Configuração;

namespace Entidades.Pagamentos
{
    [DbTabela("notapromissoria"), DbTransação]
    public class NotaPromissória : Pagamento, IProrrogável, IVencível
    {
        public static int totalAtributos = 3;

        private DateTime? prorrogadopara;
        private DateTime vencimento;

        public NotaPromissória()
        {
            vencimento = DadosGlobais.Instância.HoraDataAtual;
            data = vencimento;

            //// Toda nota promissória é pendente.
            //pendente = true;
        }

        public NotaPromissória(ulong cliente, int código, double valor, DateTime data, DateTime? prorrogadopara, bool pendente, DateTime vencimento, bool cadastrado, bool cobrarJuros)
            : base(cliente, código, valor, data, pendente, cadastrado, cobrarJuros)
        {
            this.prorrogadopara = prorrogadopara;
            this.vencimento = vencimento;
        }

        public override Pagamento.TipoEnum Tipo
        {
            get { return TipoEnum.NotaPromissória; }
        }

        public override DateTime ÚltimoVencimento
        {
            get
            {
                if (prorrogadopara.HasValue)
                    return prorrogadopara.Value;
                else
                    return vencimento;
            }

            set
            {
                if (prorrogadopara.HasValue)
                    prorrogadopara = value;
                else
                    vencimento = value;

                DefinirDesatualizado();
            }
        }

        public DateTime? ProrrogadoPara
        {
            get { return prorrogadopara; }
            set
            {
                prorrogadopara = value;
                DefinirDesatualizado();
            }
        }

        public DateTime Vencimento
        {
            get { return vencimento; }
            set
            {
                vencimento = value;
                DefinirDesatualizado();
            }
        }


        public new static List<NotaPromissória> ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            string cmd = "select * from notapromissoria join pagamento on notapromissoria.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código);

            if (somentePendente)
                cmd += " AND (pendente = 1 OR devolvido = 1)";

            return Mapear<NotaPromissória>(cmd);
        }

        public new static List<NotaPromissória> ObterPagamentos(IDadosVenda venda)
        {
            string cmd = "select cobrarJuros, pagamento.codigo, descricao, cliente, valor, data, pendente, registradopor, vencimento, prorrogadopara from notapromissoria "
            + " join pagamento on notapromissoria.codigo=pagamento.codigo where "
            + " venda=" + DbTransformar(venda.Código);

            return Mapear<NotaPromissória>(cmd);
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO notapromissoria (codigo, prorrogadopara, vencimento) "
            + " VALUES (" +
                DbTransformar(Código) + ", " +
                DbTransformar(ProrrogadoPara) + ", " +
                DbTransformar(vencimento) + ")";

            cmd.ExecuteNonQuery();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Atualizar(cmd);

            cmd.CommandText = "UPDATE notapromissoria SET " +
                " vencimento = " + DbTransformar(vencimento) + ", " + 
                " prorrogadopara = " + DbTransformar(ProrrogadoPara) +
                " WHERE codigo = " + DbTransformar(Código);

            cmd.ExecuteNonQuery();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM notapromissoria WHERE codigo = " + DbTransformar(Código);
            cmd.ExecuteNonQuery();

            if (Transacionando)
                base.Descadastrar(cmd);
        }

        protected override Pagamento CriarEntidade()
        {
            return new NotaPromissória();
        }

        protected override void ClonarAtributos(Pagamento p)
        {
            base.ClonarAtributos(p);

            NotaPromissória np = (NotaPromissória) p;

            np.vencimento = vencimento;
            np.prorrogadopara = prorrogadopara;
        }

        public new static Pagamento ObterPagamento(long código)
        {
            return MapearÚnicaLinha<NotaPromissória>("select * from notapromissoria, dinheiro where notapromissoria.pagamento=pagamento.codigo");
        }

        protected override void  PreencherAtributos(IDataReader leitor, int inicioAtributosPagamento, int inicioAtributosEspecifico)
        {
 	        base.PreencherAtributos(leitor, inicioAtributosPagamento, inicioAtributosEspecifico);
            vencimento = leitor.GetDateTime(inicioAtributosEspecifico + 1);

            if (!leitor.IsDBNull(inicioAtributosEspecifico + 2))
                prorrogadopara = leitor.GetDateTime(inicioAtributosEspecifico + 2);

        }

        public static List<NotaPromissória> FiltrarNotasPromissórias(List<Pagamento> pagamentos)
        {
            return FiltrarNotasPromissórias(pagamentos, false);
        }

        public static List<NotaPromissória> FiltrarNotasPromissórias(List<Pagamento> pagamentos, bool sóPendentes)
        {
            List<NotaPromissória> lst = new List<NotaPromissória>();

            foreach (Pagamento p in pagamentos)
            {
                if (p is NotaPromissória && p.Pendente)
                    lst.Add((NotaPromissória)p);
            }

            return lst;
        }
    }
}
