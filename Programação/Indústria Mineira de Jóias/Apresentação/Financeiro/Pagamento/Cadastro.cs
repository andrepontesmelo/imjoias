using Apresenta��o.Formul�rios;
using Entidades.Pagamentos;
using Entidades.Relacionamento.Venda;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class Cadastro : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private  Entidades.Pagamentos.Pagamento pagamento = null;
        public EventHandler PagamentoAlteradoOuRegistrado;


        public Cadastro()
        {
            InitializeComponent();
        }

        public Entidades.Pagamentos.Pagamento Pagamento
        {
            get { return pagamento; }
        }

        public virtual void PrepararParaAltera��o(Entidades.Pagamentos.Pagamento pagamento)
        {
            this.pagamento = pagamento;

            txtValor.Double = pagamento.Valor;
            chkCobrarJuros.Checked = pagamento.CobrarJuros;
            data.Value = pagamento.Data;
            txtDescri��o.Text = pagamento.Descri��o;
            chkPagamentoPendente.Checked = pagamento.Pendente;
        }

        /// <summary>
        /// Abre a janela para cadastro de novo pagamento
        /// </summary>
        /// <param name="venda">Venda vinculada a pagamento</param>
        public virtual void PrepararParaCadastro(IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            pagamento = CriarEntidade();
            pagamento.Cliente = pessoa.C�digo;
            pagamento.CobrarJuros = true;
            
            if (venda != null)
                pagamento.Venda = venda.C�digo;

            chkCobrarJuros.Checked = pagamento.CobrarJuros;

            if (venda != null)
            {
                // A data inicial do pagamento � o mesmo da venda
                data.Value = venda.Data;
                pagamento.Data = data.Value;

                // O valor inicial do pagamento � aquele para acerto a vista na data da venda.
                Entidades.Relacionamento.Venda.Venda v = Entidades.Relacionamento.Venda.Venda.ObterVenda(venda.C�digo);
                if (v.Saldo < 0)
                {
                    pagamento.Valor = -v.Saldo;
                    txtValor.Double = -v.Saldo;
                }
                else
                {
                    pagamento.Valor = 0;
                    txtValor.Double = 0;
                }
            }

            txtValor.Focus();
        }

        protected virtual Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            throw new Exception("Base!");
        }

        protected virtual double ObterValor()
        {
            return txtValor.Double;
        }

        protected virtual void Gravar()
        {
            UseWaitCursor = true;
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            pagamento.Valor = ObterValor();
            pagamento.Data = data.Value;
            pagamento.Pendente = chkPagamentoPendente.Checked;
            pagamento.CobrarJuros = chkCobrarJuros.Checked;
            pagamento.Descri��o = txtDescri��o.Text;

            if (!pagamento.Cadastrado)
            {
                pagamento.RegistradoPor = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;
                pagamento.Cadastrar();
            }
            else
            {
                pagamento.Atualizar();
            }

            if (PagamentoAlteradoOuRegistrado != null)
                PagamentoAlteradoOuRegistrado(this, EventArgs.Empty);

            AguardeDB.Fechar();
            UseWaitCursor = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Gravar();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* O padr�o da cultura atual � utilizar virgula. 
             * No entanto, os funcion�rios utilizam o ponto do 
             * teclado num�rico.
             */

            if (e.KeyChar == '.')
            {
                e.KeyChar = txtValor.DecimalPoint;
                e.Handled = false;
            }
        }

        private void chkPagamentoPendente_CheckedChanged(object sender, EventArgs e)
        {
            chkPagamentoPendente.BackColor =
                chkPagamentoPendente.Checked ?
                Color.Yellow : SystemColors.Control;

            if (pagamento != null)
                pagamento.Pendente = chkPagamentoPendente.Checked;
        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            txtValor.Double = Math.Abs(txtValor.Double);
            pagamento.Valor = txtValor.Double;
        }

        private void data_Validated(object sender, EventArgs e)
        {
            pagamento.Data = data.Value;
        }

        public static Cadastro ConstruirJanelaEdi��o(Entidades.Pagamentos.Pagamento pagamento)
        {
            Cadastro dlg;

            if (pagamento is Cheque)
                dlg = new CadastroCheque();

            else if (pagamento is Dinheiro)
                dlg = new CadastroDinheiro();

            else if (pagamento is NotaPromiss�ria)
                dlg = new CadastroNotaPromiss�ria();

            else
                throw new NotSupportedException();

            dlg.PrepararParaAltera��o(pagamento);

            return dlg;
        }

        private void txtIdentifica��o_Validated(object sender, EventArgs e)
        {
            pagamento.Descri��o = txtDescri��o.Text;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            txtValor.Focus();
        }
    }
}