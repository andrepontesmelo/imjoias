using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class CadastroOuro : Apresenta��o.Financeiro.Pagamento.Cadastro
    {
        public CadastroOuro()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Ouro();
        }

        public override void PrepararParaAltera��o(Entidades.Pagamentos.Pagamento pagamento)
        {
            txtPeso.Double = ((Entidades.Pagamentos.Ouro) pagamento).Peso;
            txtCota��o.Valor = ((Entidades.Pagamentos.Ouro) pagamento).Cota��o;

            if (((Entidades.Pagamentos.Ouro) pagamento).ParaFundir)
            {
                chkOuroFundir.Checked = true;
                chkOuroMil.Checked = false;
            } else
            {
                chkOuroFundir.Checked = false;
                chkOuroMil.Checked = true;
            }

            base.PrepararParaAltera��o(pagamento);
        }

        protected override void Gravar()
        {
            ((Entidades.Pagamentos.Ouro) Pagamento).Cota��o = txtCota��o.Valor;
            ((Entidades.Pagamentos.Ouro) Pagamento).Peso = txtPeso.Double;
            ((Entidades.Pagamentos.Ouro) Pagamento).ParaFundir = chkOuroFundir.Checked;

            base.Gravar();
        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

            if (venda == null)
                ((Entidades.Pagamentos.Ouro)Pagamento).Cota��o = Entidades.Cota��o.ObterCota��oVigente(
                    Entidades.Moeda.ObterMoeda(
                    Entidades.Moeda.MoedaSistema.Ouro));
            else
                ((Entidades.Pagamentos.Ouro)Pagamento).Cota��o = venda.Cota��o;

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
                txtCota��o.Valor = ((Entidades.Pagamentos.Ouro)Pagamento).Cota��o;
                txtPeso.Double = ((Entidades.Pagamentos.Ouro)Pagamento).Peso;
                chkOuroFundir.Checked = ((Entidades.Pagamentos.Ouro)Pagamento).ParaFundir;
                txtValor.Double = ((Entidades.Pagamentos.Ouro) Pagamento).Valor;
                txtPeso.Double = ((Entidades.Pagamentos.Ouro) Pagamento).Peso;
            }
        }

        private void txtCota��o_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Ouro)Pagamento).Cota��o = txtCota��o.Valor;

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

