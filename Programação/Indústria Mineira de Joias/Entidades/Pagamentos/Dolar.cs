using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Relacionamento.Venda;
using System.Data;

namespace Entidades.Pagamentos
{
    [DbTabela("dolar")]
    public class Dolar : Pagamento
    {
        public static readonly int totalAtributos = 3;

        [DbColuna("valorEmDolar")]
        private double valorEmDolar;
        private double cotacao;

        public double ValorEmDolar
        {
            get { return valorEmDolar; }
            set
            {
                valorEmDolar = value;
                RecalcularValor();
                DefinirDesatualizado();
            }
        }


        public double Cotação
        {
            get { return cotacao; }
            set
            {
                cotacao = value;

                RecalcularValor();
                DefinirDesatualizado();
            }
        }

        public Dolar()
        { }

        public Dolar(ulong cliente, int código, double valor, DateTime data, bool pendente, bool cadastrado, bool cobrarJuros)
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
            get { return TipoEnum.Dolar; }
        }

        public new static List<Dolar> ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            string cmd = "select * from dolar join pagamento on dolar.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código);

            if (somentePendente)
                cmd += " AND (pendente = 1 OR devolvido = 1)";

            return Mapear<Dolar>(cmd);
        }

        public new static List<Dolar> ObterPagamentos(IDadosVenda venda)
        {
            string cmd = "select dolar.*, pagamento.* from dolar "
            + " join pagamento on dolar.codigo=pagamento.codigo where "
            + " venda=" + DbTransformar(venda.Código);

            return Mapear<Dolar>(cmd);
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO dolar (codigo, valoremdolar, cotacao) "
            + " VALUES (" + DbTransformar(Código) + ", "
            + DbTransformar(valorEmDolar) + ", "
            + DbTransformar(cotacao) + ")";

            cmd.ExecuteNonQuery();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Atualizar(cmd);

            cmd.CommandText = "UPDATE dolar SET " +
            " valoremdolar = " + DbTransformar(valorEmDolar) +
            ", cotacao = " + DbTransformar(Cotação) +
            " WHERE codigo = " + DbTransformar(Código);

            cmd.ExecuteNonQuery();

        }

        protected override void ClonarAtributos(Pagamento p)
        {
            base.ClonarAtributos(p);

            Dolar c = (Dolar) p;

            c.ValorEmDolar = valorEmDolar;
            c.cotacao = cotacao;
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM dolar WHERE codigo = " + DbTransformar(Código);
            cmd.ExecuteNonQuery();

            if (Transacionando)
                base.Descadastrar(cmd);

        }

        protected override Pagamento CriarEntidade()
        {
            return new Dolar();
        }

        /// <summary>
        /// Recalcula valor do Pagamento. 
        /// </summary>
        public void RecalcularValor()
        {
            Valor = valorEmDolar * cotacao;
        }


        public override string DescriçãoAdicional
        {
            get
            {
                return "\tUS$ " + valorEmDolar.ToString() + " à cotação " + cotacao.ToString() + "; " + base.DescriçãoAdicional;
            }
        }

        protected override void PreencherAtributos(IDataReader leitor, int inicioAtributosPagamento, int inicioAtributosEspecifico)
        {
            base.PreencherAtributos(leitor, inicioAtributosPagamento, inicioAtributosEspecifico);
            valorEmDolar = leitor.GetDouble(inicioAtributosEspecifico + 1);
            cotacao = leitor.GetDouble(inicioAtributosEspecifico + 2);
        }
    }
}