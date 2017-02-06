using System;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class CadastroCheque : Apresentação.Financeiro.Pagamento.Cadastro
    {
        public CadastroCheque()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Cheque();
        }

        public override void PrepararParaAlteração(Entidades.Pagamentos.Pagamento pagamento)
        {
            dataVencimento.Value = ((Entidades.Pagamentos.Cheque) pagamento).Vencimento;

            if (((Entidades.Pagamentos.Cheque)pagamento).ProrrogadoPara.HasValue)
            {
                chkProrrogado.Checked = true;
                dataProrrogação.Value = ((Entidades.Pagamentos.Cheque)pagamento).ProrrogadoPara.Value;
                dataProrrogação.Enabled = true;
            }
            else
            {
                chkProrrogado.Checked = false;
                dataProrrogação.Enabled = false;
            }
            
            txtCPF.Text = ((Entidades.Pagamentos.Cheque)pagamento).Cpf;
            chkDevolvido.Checked = ((Entidades.Pagamentos.Cheque)pagamento).Devolvido;
            chkTerceiro.Checked = ((Entidades.Pagamentos.Cheque)pagamento).DeTerceiro;
            //txtIdentificação.Text = ((Entidades.Pagamentos.Cheque)pagamento).Identificação;

            base.PrepararParaAlteração(pagamento);
        }

        protected override void Gravar()
        {
            // Nem sempre validated é executado.
            if (chkProrrogado.Checked)
                ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara
                = dataProrrogação.Value;
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



        private void txtIdentificação_Validated(object sender, EventArgs e)
        {
            //if (txtIdentificação.Text.Trim().Length > 0)
            //    ((Entidades.Pagamentos.Cheque)Pagamento).Identificação = txtIdentificação.Text.Trim();
            //else
            //    ((Entidades.Pagamentos.Cheque)Pagamento).Identificação = null;
        }

        private void chkTerceiro_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Cheque)Pagamento).DeTerceiro = chkTerceiro.Checked;
        }

        private void chkProrrogado_CheckedChanged(object sender, EventArgs e)
        {
            dataProrrogação.Enabled = chkProrrogado.Checked;

            if (!chkProrrogado.Checked)
                ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara = null;
        }

        private void dataProrrogação_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.Cheque)Pagamento).ProrrogadoPara = dataProrrogação.Value;
        }

        private void dataProrrogação_ValueChanged(object sender, EventArgs e)
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

