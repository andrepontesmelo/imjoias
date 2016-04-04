using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Relacionamento.Venda;
using System.Data;

namespace Entidades.Pagamentos
{
    /// <summary>.
    /// == Especificação IMJ == 
    /// Se é para fundir,
    ///     valor = peso * cotacao da venda * 0.750 * 0.9 
    /// Se é ouro mil,
    ///     valor = peso * cotacao da venda.
    /// 
    /// == Implementação == 
    /// Se é para fundir, multiplicador = 0,675
    ///    é ouro mil, multiplicador = 1;
    /// valor = peso * cotacao da venda * multiplicador sempre.
    /// * Trigger ao alterar cotação da venda, atualizar o valor do pagamento-ouro daquela venda.
    /// </summary>
    [DbTabela("ouro")]
    public class Ouro : Pagamento
    {
        public static readonly int totalAtributos = 5;

        private double peso;
        private double multiplicador = 0.675;
        private bool paraFundir = true;
        private double cotacao;

        public bool ParaFundir
        {
            get { return paraFundir; }
            set
            {
                paraFundir = value;

                if (paraFundir)
                    multiplicador = 0.675;
                else
                    multiplicador = 1;

                RecalcularValor();
                DefinirDesatualizado();
            }
        }

        public double Peso
        {
            get { return peso; }
            set
            {
                peso = value;

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

        public Ouro()
        { }

        public Ouro(ulong cliente, int código, double valor, DateTime data, bool pendente, bool cadastrado, bool cobrarJuros)
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
            get { return TipoEnum.Ouro; }
        }

        public new static List<Ouro> ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            string cmd = "select * from ouro join pagamento on ouro.codigo=pagamento.codigo where cliente=" + DbTransformar(cliente.Código);

            if (somentePendente)
                cmd += " AND (pendente = 1 OR devolvido = 1)";

            return Mapear<Ouro>(cmd);
        }

        public new static List<Ouro> ObterPagamentos(IDadosVenda venda)
        {
            string cmd = "select ouro.*, pagamento.* from ouro "
            + " join pagamento on ouro.codigo=pagamento.codigo where "
            + " venda=" + DbTransformar(venda.Código);

            return Mapear<Ouro>(cmd);
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            cmd.CommandText = "INSERT INTO ouro (codigo, peso, paraFundir, cotacao, multiplicador) "
            + " VALUES (" + DbTransformar(Código) + ", "
            + DbTransformar(peso) + ", "
            + DbTransformar(paraFundir) + ", "
            + DbTransformar(cotacao) + ", "
            + DbTransformar(multiplicador) + ")";

            cmd.ExecuteNonQuery();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Atualizar(cmd);

            cmd.CommandText = "UPDATE ouro SET " +
            " peso = " + DbTransformar(Peso) +
            ", paraFundir = " + DbTransformar(ParaFundir) +
            ", cotacao = " + DbTransformar(Cotação) +
            ", multiplicador = " + DbTransformar(multiplicador) +
            " WHERE codigo = " + DbTransformar(Código);

            cmd.ExecuteNonQuery();

        }

        protected override void ClonarAtributos(Pagamento p)
        {
            base.ClonarAtributos(p);

            Ouro c = (Ouro) p;

            c.multiplicador = multiplicador;
            c.paraFundir = paraFundir;
            c.cotacao = cotacao;
            c.peso = peso;
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            cmd.CommandText = "DELETE FROM ouro WHERE codigo = " + DbTransformar(Código);
            cmd.ExecuteNonQuery();

            if (Transacionando)
                base.Descadastrar(cmd);

        }

        protected override Pagamento CriarEntidade()
        {
            return new Ouro();
        }

        /// <summary>
        /// Recalcula valor do Pagamento. 
        /// </summary>
        public void RecalcularValor()
        {
            Valor = peso * cotacao * multiplicador;
        }


        public override string DescriçãoAdicional
        {
            get
            {
                return peso.ToString() + "g " +
                     (paraFundir ? "p/ fundir " : "")
                     + "à cotação " + cotacao.ToString() + 
                     (base.DescriçãoAdicional.Trim().Length == 0 ? "" : " - " + base.DescriçãoAdicional);
            }
        }

        protected override void PreencherAtributos(IDataReader leitor, int inicioAtributosPagamento, int inicioAtributosEspecifico)
        {
            base.PreencherAtributos(leitor, inicioAtributosPagamento, inicioAtributosEspecifico);

            peso = leitor.GetDouble(inicioAtributosEspecifico + 1);
            paraFundir = leitor.GetBoolean(inicioAtributosEspecifico + 2);
            multiplicador = leitor.GetDouble(inicioAtributosEspecifico + 3);
            cotacao = leitor.GetDouble(inicioAtributosEspecifico + 4);
        }
    }
}