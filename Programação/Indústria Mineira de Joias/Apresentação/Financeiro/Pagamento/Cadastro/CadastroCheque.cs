using System;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class CadastroCheque : Apresenta��o.Financeiro.Pagamento.Cadastro
    {
        public CadastroCheque()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Cheque();
        }

        public override void PrepararParaAltera��o(Entidades.Pagamentos.Pagamento pagamento)
        {
            dataVencimento.Value = ((Entidades.Pagamentos.Cheque) pagamento).Vencimento;

            if (((Entidades.Pagamentos.Cheque)pagamento).ProrrogadoPara.HasValue)
            {
                chkProrrogado.Checked = true;
                dataProrroga��o.Value = ((Entidades.Pagamentos.Cheque)pagamento).ProrrogadoPara.Value;
                dataProrroga��o.Enabled = true;
            }
            else
            {
                chkProrrogado.Checked = false;
                dataProrroga��o.Enabled = false;
            }
            
            txtCPF.Text = ((Entidades.Pagamentos.Cheque)pagamento).Cpf;
            chkDevolvido.Checked = ((Entidades.Pagamentos.Cheque)pagamento).Devolvido;
            chkTerceiro.Checked = ((Entidades.Pagamentos.Cheque)pagamento).DeTerceiro;
            //txtIdentifica��o.Text = ((Entidades.Pagamentos.Cheque)pagamento).Identifica��o;

            base.PrepararParaAltera��o(pagamento);
        }

        protected override void Gravar()
        {
            // Nem sempre validated � executado.
            if (chkProrrogado.Checked)
                ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara
                = dataProrroga��o.Value;
            else
                ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara = null;

            ((Entidades.Pagamentos.Cheque)Pagamento).Vencimento = dataVencimento.Value;
            ((Entidades.Pagamentos.Cheque)Pagamento).Cpf = txtCPF.Text;
            ((Entidades.Pagamentos.Cheque)Pagamento).Devolvido = chkDevolvido.Checked;
            base.Gravar();
        }

        private void dataVencimento_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Cheque)Pagamento).Vencimento = dataVencimento.Value;
        }

        private void txtCPF_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Cheque)Pagamento).Cpf = txtCPF.Text;
        }

        void chkDevolvido_CheckedChanged(object sender, System.EventArgs e)
        {
            if (Pagamento != null)
            {
                ((Entidades.Pagamentos.Cheque)Pagamento).Devolvido = chkDevolvido.Checked;

                if (chkPagamentoPendente.Enabled)
                    chkPagamentoPendente.Checked = chkDevolvido.Checked;

                if (chkDevolvido.Checked)
                    chkPagamentoPendente.Enabled = false;
            }
        }



        private void txtIdentifica��o_Validated(object sender, EventArgs e)
        {
            //if (txtIdentifica��o.Text.Trim().Length > 0)
            //    ((Entidades.Pagamentos.Cheque)Pagamento).Identifica��o = txtIdentifica��o.Text.Trim();
            //else
            //    ((Entidades.Pagamentos.Cheque)Pagamento).Identifica��o = null;
        }

        private void chkTerceiro_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Cheque)Pagamento).DeTerceiro = chkTerceiro.Checked;
        }

        private void chkProrrogado_CheckedChanged(object sender, EventArgs e)
        {
            dataProrroga��o.Enabled = chkProrrogado.Checked;

            if (!chkProrrogado.Checked)
                ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara = null;
        }

        private void dataProrroga��o_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara = dataProrroga��o.Value;
        }

        private void dataProrroga��o_ValueChanged(object sender, EventArgs e)
        {

        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

            if (venda != null)
            {
                dataVencimento.Value = venda.Data.AddDays(venda.DiasSemJuros);
                ((Entidades.Pagamentos.Cheque)Pagamento).Vencimento = dataVencimento.Value;
            }

            txtValor.Focus();
        }

        private void CadastroCheque_Load(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void chkCobrarJuros_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

