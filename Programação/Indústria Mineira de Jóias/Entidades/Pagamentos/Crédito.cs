/*
using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Relacionamento.Venda;
using System.Data;

namespace Entidades.Pagamentos
{
    [DbTabela("credito")]
    public class Crédito : Pagamento
    {
        public Crédito()
        { }

        public Crédito(Entidades.Pessoa.Pessoa cliente, int código, double valor, DateTime data, bool pendente, bool cadastrado, bool cobrarJuros)
            : base(cliente, código, valor, data, pendente, cadastrado, cobrarJuros)
        {
        }

        public override DateTime ÚltimoVencimento
        {
            get { return data; }
            set { data = value; }
        }

        public override Pagamento.TipoEnum Tipo
        {
            get { return TipoEnum.Crédito; }
        }

        public new static List<Crédito> ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            string cmd = "select * from credito join pagamento on credito.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código);

            if (somentePendente)
                cmd += " AND (pendente = 1 OR devolvido = 1)";

            return Mapear<Crédito>(cmd);
        }

        public new static List<Crédito> ObterCréditosNãoUtilizados(Entidades.Pessoa.Pessoa cliente)
        {
            string cmd = "select * from credito join pagamento on credito.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código)
            + " AND pagamento.codigo not in (select pagamento from vendacredito)";

            return Mapear<Crédito>(cmd);
        }


        public new static List<Crédito> ObterPagamentos(IDadosVenda venda)
        {
            string cmd = "select cobrarJuros, pagamento.codigo, descricao, cliente, valor, data, pendente, registradopor from vinculovendapagamento, credito "
            + " join pagamento on credito.codigo=pagamento.codigo where vinculovendapagamento.pagamento=pagamento.codigo "
            + " AND vinculovendapagamento.venda=" + DbTransformar(venda.Código);

            return Mapear<Crédito>(cmd);
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO credito (codigo) "
            + " VALUES (" + DbTransformar(Código) + ")";

            cmd.ExecuteNonQuery();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Atualizar(cmd);

            //cmd.CommandText = "UPDATE credito SET " +
            //    " identificacao = " + DbTransformar(identificação) +
            //    " WHERE codigo = " + DbTransformar(Código);

            //cmd.ExecuteNonQuery();
        }

        protected override void ClonarAtributos(Pagamento p)
        {
            base.ClonarAtributos(p);

            Crédito c = (Crédito) p;
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM credito WHERE codigo = " + DbTransformar(Código);
            cmd.ExecuteNonQuery();

            if (Transacionando)
                base.Descadastrar(cmd);

        }

        protected override Pagamento CriarEntidade()
        {
            return new Crédito();
        }
    }
}
*/
