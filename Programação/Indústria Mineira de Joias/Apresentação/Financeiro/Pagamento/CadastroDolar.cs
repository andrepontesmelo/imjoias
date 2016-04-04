using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class CadastroDolar : Apresentação.Financeiro.Pagamento.Cadastro
    {
        public CadastroDolar()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Dolar();
        }

        public override void PrepararParaAlteração(Entidades.Pagamentos.Pagamento pagamento)
        {
            txtValorEmDolares.Double = ((Entidades.Pagamentos.Dolar)pagamento).ValorEmDolar;
            txtCotação.Valor = ((Entidades.Pagamentos.Dolar)pagamento).Cotação;

            base.PrepararParaAlteração(pagamento);
        }

        protected override void Gravar()
        {
            ((Entidades.Pagamentos.Dolar) Pagamento).Cotação = txtCotação.Valor;
            ((Entidades.Pagamentos.Dolar) Pagamento).ValorEmDolar = txtValorEmDolares.Double;

            base.Gravar();
        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

                ((Entidades.Pagamentos.Dolar)Pagamento).Cotação = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(
                    Entidades.Moeda.ObterMoeda(
                    Entidades.Moeda.MoedaSistema.DólarParalelo));

            AtualizarInterface();
            txtValor.Focus();
        }

        /// <summary>
        /// Atualiza tela com referência na entidade.
        /// </summary>
        private void AtualizarInterface()
        {
            // Pagamento é nulo quando está carregando para alteração.
            if (Pagamento != null)
            {
                txtValor.Double = Pagamento.Valor;
                txtCotação.Valor = ((Entidades.Pagamentos.Dolar) Pagamento).Cotação;
                txtValorEmDolares.Double = ((Entidades.Pagamentos.Dolar) Pagamento).ValorEmDolar;
            }
        }

        private void txtCotação_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Dolar)Pagamento).Cotação = txtCotação.Valor;

            AtualizarInterface();
        }

        private void txtValorEmDolares_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Dolar) Pagamento).ValorEmDolar = txtValorEmDolares.Double;

            AtualizarInterface();
        }
    }
}

