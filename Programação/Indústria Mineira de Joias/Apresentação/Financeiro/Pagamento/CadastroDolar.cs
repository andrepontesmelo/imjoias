using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class CadastroDolar : Apresenta��o.Financeiro.Pagamento.Cadastro
    {
        public CadastroDolar()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Dolar();
        }

        public override void PrepararParaAltera��o(Entidades.Pagamentos.Pagamento pagamento)
        {
            txtValorEmDolares.Double = ((Entidades.Pagamentos.Dolar)pagamento).ValorEmDolar;
            txtCota��o.Valor = ((Entidades.Pagamentos.Dolar)pagamento).Cota��o;

            base.PrepararParaAltera��o(pagamento);
        }

        protected override void Gravar()
        {
            ((Entidades.Pagamentos.Dolar) Pagamento).Cota��o = txtCota��o.Valor;
            ((Entidades.Pagamentos.Dolar) Pagamento).ValorEmDolar = txtValorEmDolares.Double;

            base.Gravar();
        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

                ((Entidades.Pagamentos.Dolar)Pagamento).Cota��o = Entidades.Financeiro.Cota��o.ObterCota��oVigente(
                    Entidades.Moeda.ObterMoeda(
                    Entidades.Moeda.MoedaSistema.D�larParalelo));

            AtualizarInterface();
            txtValor.Focus();
        }

        /// <summary>
        /// Atualiza tela com refer�ncia na entidade.
        /// </summary>
        private void AtualizarInterface()
        {
            // Pagamento � nulo quando est� carregando para altera��o.
            if (Pagamento != null)
            {
                txtValor.Double = Pagamento.Valor;
                txtCota��o.Valor = ((Entidades.Pagamentos.Dolar) Pagamento).Cota��o;
                txtValorEmDolares.Double = ((Entidades.Pagamentos.Dolar) Pagamento).ValorEmDolar;
            }
        }

        private void txtCota��o_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Dolar)Pagamento).Cota��o = txtCota��o.Valor;

            AtualizarInterface();
        }

        private void txtValorEmDolares_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Dolar) Pagamento).ValorEmDolar = txtValorEmDolares.Double;

            AtualizarInterface();
        }
    }
}

