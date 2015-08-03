using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Acesso.Comum;
using System.Data;
using Entidades.Relacionamento.Venda;

namespace Entidades.Pagamentos
{
    [DbTabela("cheque")]
    public class Cheque : Pagamento, IProrrogável, IVencível
    {
        public static readonly int totalAtributos = 5;
        private DateTime? prorrogadopara;
        private DateTime vencimento;
        private string cpf;
       
        private bool deTerceiro;

        

        public Cheque()
        {
        }

        public Cheque(ulong cliente, int código, double valor, DateTime data, bool pendente, DateTime vencimento, DateTime? prorrogadopara, string cpf, bool cadastrado, bool cobrarJuros)
            : base(cliente, código, valor, data, pendente, cadastrado, cobrarJuros)
        {
            this.vencimento = vencimento;
            this.prorrogadopara = prorrogadopara;
            this.cpf = cpf;
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
                throw new NotSupportedException();
            }
        }

        public string Cpf
        {
            get { return cpf; }
            set 
            {
                if (String.IsNullOrEmpty(value)) 
                    value = null;

                if (cpf != value)
                    DefinirDesatualizado();

                cpf = value; 
            }
        }

        /// <summary>
        /// Se o cheque é de terceiro.
        /// </summary>
        public bool DeTerceiro { get { return deTerceiro; } set { deTerceiro = value; DefinirDesatualizado(); } }


        public override Pagamento.TipoEnum Tipo
        {
            get { return TipoEnum.Cheque; }
        }

        public new static List<Cheque> ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            string cmd = "select * from cheque join pagamento on cheque.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código);

            if (somentePendente)
                cmd += " AND (pendente = 1 OR devolvido = 1)";

            return Mapear<Cheque>(cmd);
        }

        public new static List<Cheque> ObterPagamentos(IDadosVenda venda)
        {
            ArrayList lista = new ArrayList();
            string cmd = "select cheque.*, pagamento.* from cheque  "
            + " join pagamento on cheque.codigo=pagamento.codigo where "
            + " venda=" + DbTransformar(venda.Código);

            return Mapear<Cheque>(cmd);
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO cheque (codigo, cpf, vencimento, prorrogadopara, deTerceiro) "
            + " VALUES (" +
                DbTransformar(Código) + ", " +
                DbTransformar(Cpf) + ", " +
                DbTransformar(vencimento) + ", " +
                DbTransformar(prorrogadopara) + ", " +
                DbTransformar(deTerceiro) + ") ";


            cmd.ExecuteNonQuery();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Atualizar(cmd);

            cmd.CommandText = "UPDATE cheque SET " +
                " vencimento = " + DbTransformar(vencimento) +
                ", prorrogadopara = " + DbTransformar(prorrogadopara) +
                ", cpf = " + DbTransformar(Cpf) +
                ", deTerceiro = " + DbTransformar(deTerceiro) + 
                " WHERE codigo = " + DbTransformar(Código);

            cmd.ExecuteNonQuery();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM cheque WHERE codigo = " + DbTransformar(Código);
            cmd.ExecuteNonQuery();

            if (Transacionando)
                base.Descadastrar(cmd);

        }

        protected override void ClonarAtributos(Pagamento p)
        {
            base.ClonarAtributos(p);

            Cheque c = (Cheque) p;

            c.cpf = cpf;
            c.vencimento = vencimento;
            c.deTerceiro = deTerceiro;
            c.prorrogadopara = prorrogadopara;
            c.pagoNaVenda = pagoNaVenda;
        }

        protected override Pagamento CriarEntidade()
        {
            return new Cheque();
        }

        public new static Pagamento ObterPagamento(long código)
        {
            return MapearÚnicaLinha<Cheque>("select * from pagamento, cheque where cheque.pagamento=pagamento.codigo");
        }

        protected override void PreencherAtributos(IDataReader leitor, int inicioAtributosPagamento, int inicioAtributosEspecifico)
        {
            base.PreencherAtributos(leitor, inicioAtributosPagamento, inicioAtributosEspecifico);
            vencimento = leitor.GetDateTime(inicioAtributosEspecifico + 1);

            if (!leitor.IsDBNull(inicioAtributosEspecifico + 2))
                cpf = leitor.GetString(inicioAtributosEspecifico + 2);

            deTerceiro = leitor.GetBoolean(inicioAtributosEspecifico + 3);

            if (!leitor.IsDBNull(inicioAtributosEspecifico + 4))
                prorrogadopara = leitor.GetDateTime(inicioAtributosEspecifico + 4);
        }
    }
}