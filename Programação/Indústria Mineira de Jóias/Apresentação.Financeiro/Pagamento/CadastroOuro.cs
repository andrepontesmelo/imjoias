using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class CadastroOuro : Apresentação.Financeiro.Pagamento.Cadastro
    {
        public CadastroOuro()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Ouro();
        }

        public override void PrepararParaAlteração(Entidades.Pagamentos.Pagamento pagamento)
        {
            txtPeso.Double = ((Entidades.Pagamentos.Ouro) pagamento).Peso;
            txtCotação.Valor = ((Entidades.Pagamentos.Ouro) pagamento).Cotação;

            if (((Entidades.Pagamentos.Ouro) pagamento).ParaFundir)
            {
                chkOuroFundir.Checked = true;
                chkOuroMil.Checked = false;
            } else
            {
                chkOuroFundir.Checked = false;
                chkOuroMil.Checked = true;
            }

            base.PrepararParaAlteração(pagamento);
        }

        protected override void Gravar()
        {
            ((Entidades.Pagamentos.Ouro) Pagamento).Cotação = txtCotação.Valor;
            ((Entidades.Pagamentos.Ouro) Pagamento).Peso = txtPeso.Double;
            ((Entidades.Pagamentos.Ouro) Pagamento).ParaFundir = chkOuroFundir.Checked;

            base.Gravar();
        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

            if (venda == null)
                ((Entidades.Pagamentos.Ouro)Pagamento).Cotação = Entidades.Cotação.ObterCotaçãoVigente(
                    Entidades.Moeda.ObterMoeda(
                    Entidades.Moeda.MoedaSistema.Ouro));
            else
                ((Entidades.Pagamentos.Ouro)Pagamento).Cotação = venda.Cotação;

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
                txtCotação.Valor = ((Entidades.Pagamentos.Ouro)Pagamento).Cotação;
                txtPeso.Double = ((Entidades.Pagamentos.Ouro)Pagamento).Peso;
                chkOuroFundir.Checked = ((Entidades.Pagamentos.Ouro)Pagamento).ParaFundir;
                txtValor.Double = ((Entidades.Pagamentos.Ouro) Pagamento).Valor;
                txtPeso.Double = ((Entidades.Pagamentos.Ouro) Pagamento).Peso;
            }
        }

        private void txtCotação_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Ouro)Pagamento).Cotação = txtCotação.Valor;

            AtualizarInterface();
        }

        private void txtPeso_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Ouro)Pagamento).Peso = txtPeso.Double;

            AtualizarInterface();
        }

        private void chkOuroMil_CheckedChanged(object sender, EventArgs e)
        {
            if (Pagamento != null)
                ((Entidades.Pagamentos.Ouro)Pagamento).ParaFundir = chkOuroFundir.Checked;

            AtualizarInterface();
        }
    }
}

