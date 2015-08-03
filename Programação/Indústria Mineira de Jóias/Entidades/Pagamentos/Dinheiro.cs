using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Acesso.Comum;
using System.Data;
using Entidades.Relacionamento.Venda;

namespace Entidades.Pagamentos
{
    [DbTabela("dinheiro")]
    public class Dinheiro : Pagamento
    {
        public static readonly int totalAtributos = 1;

        public Dinheiro()
        { }

        public Dinheiro(ulong cliente, int código, double valor, DateTime data, bool pendente, bool cadastrado, bool cobrarJuros)
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
            get { return TipoEnum.Dinheiro; }
        }

        public new static List<Dinheiro> ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            string cmd = "select * from dinheiro join pagamento on dinheiro.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código);

            if (somentePendente)
                cmd += " AND (pendente = 1 OR devolvido = 1)";

            return Mapear<Dinheiro>(cmd);
        }

        public new static Pagamento ObterPagamento(long código)
        {
            return MapearÚnicaLinha<Dinheiro>("select * from pagamento, dinheiro where dinheiro.pagamento=pagamento.codigo");
        }

        public new static List<Dinheiro> ObterPagamentos(IDadosVenda venda)
        {
            string cmd = "select cobrarJuros, pagamento.codigo, descricao, cliente, valor, data, pendente, registradopor from dinheiro "
            + " join pagamento on dinheiro.codigo=pagamento.codigo where "
            + " venda=" + DbTransformar(venda.Código);

            return Mapear<Dinheiro>(cmd);
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO dinheiro (codigo) "
            + " VALUES (" +DbTransformar(Código) + ")";

            cmd.ExecuteNonQuery();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM dinheiro WHERE codigo = " + DbTransformar(Código);
            cmd.ExecuteNonQuery();

            if (Transacionando)
                base.Descadastrar(cmd);

        }

        protected override Pagamento CriarEntidade()
        {
            return new Dinheiro();
        }

        protected override void PreencherAtributos(IDataReader leitor, int inicioAtributosPagamento, int inicioAtributosEspecifico)
        {
            base.PreencherAtributos(leitor, inicioAtributosPagamento, inicioAtributosEspecifico);
        }    
    }
}
