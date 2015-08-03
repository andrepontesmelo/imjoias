using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Entidades.Pagamentos;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class Cadastro : Apresentação.Formulários.JanelaExplicativa
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
            //set { pagamento = value; }
        }

        public virtual void PrepararParaAlteração(Entidades.Pagamentos.Pagamento pagamento)
        {
            this.pagamento = pagamento;
            txtValor.Double = pagamento.Valor;
            chkCobrarJuros.Checked = pagamento.CobrarJuros;
            data.Value = pagamento.Data;
            txtDescrição.Text = pagamento.Descrição;
            chkPagamentoPendente.Checked = pagamento.Pendente;
            //RefazerListaVendas(null);
        }

        /// <summary>
        /// Abre a janela para cadastro de novo pagamento
        /// </summary>
        /// <param name="venda">Venda vinculada a pagamento</param>
        public virtual void PrepararParaCadastro(IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            pagamento = CriarEntidade();
            pagamento.Cliente = pessoa.Código;
            pagamento.CobrarJuros = true;
            
            if (venda != null)
                pagamento.Venda = venda.Código;

            //RefazerListaVendas(venda);
            //MarcarVendasSemPagamentos();
            chkCobrarJuros.Checked = pagamento.CobrarJuros;

            if (venda != null)
            {
                // A data inicial do pagamento é o mesmo da venda
                data.Value = venda.Data;
                pagamento.Data = data.Value;

                // O valor inicial do pagamento é aquele para acerto a vista na data da venda.
                Entidades.Relacionamento.Venda.Venda v = Entidades.Relacionamento.Venda.Venda.ObterVenda(venda.Código);
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
            Apresentação.Formulários.AguardeDB.Mostrar();

            pagamento.Valor = ObterValor();
            pagamento.Data = data.Value;
            pagamento.Pendente = chkPagamentoPendente.Checked;
            pagamento.CobrarJuros = chkCobrarJuros.Checked;
            pagamento.Descrição = txtDescrição.Text;

            if (!pagamento.Cadastrado)
            {
                pagamento.RegistradoPor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
                pagamento.Cadastrar();
            }
            else
            {
                pagamento.Atualizar();
            }

            if (PagamentoAlteradoOuRegistrado != null)
                PagamentoAlteradoOuRegistrado(this, EventArgs.Empty);

            Apresentação.Formulários.AguardeDB.Fechar();
            UseWaitCursor = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //// Verifica se existem apenas vendas desmarcadas
            //if (chkListaVendas.CheckedItems.Count == 0 && chkListaVendas.Items.Count > 0
            //    && !pagamento.Atualizado && (MessageBox.Show("Este pagamento está relacionado a NENHUMA venda. \nDeseja continuar? ", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            //        == DialogResult.No))
            //{
            //    return;
            //}


            Gravar();
            DialogResult = DialogResult.OK;
            Close();
        }

        //private void lnkAdicionar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    List<IDadosVenda> vendasMarcadas;
        //    EscolhaVendas janela = new EscolhaVendas();
            
        //    janela.Abrir(pagamento.Cliente);
        //    janela.Marcar(pagamento.Vendas);
        //    janela.ShowDialog(this);
        //    vendasMarcadas = janela.ObterVendasMarcadas();
        //    janela.Close();

        //    pagamento.Vendas = vendasMarcadas;
        //    pagamento.DefinirDesatualizado();
        //    RefazerListaVendas(null);
        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
                Close();
        }

        //private void chkListaVendas_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (e.NewValue == CheckState.Unchecked)
        //    {
        //        // Retirar o venda!
        //        pagamento.Vendas.Remove((IDadosVenda)chkListaVendas.Items[e.Index]);
        //        pagamento.DefinirDesatualizado();
        //    }
        //    else if (e.NewValue == CheckState.Checked)
        //    {
        //        // Adicionar a venda!
        //        pagamento.Vendas.Add((IDadosVenda)chkListaVendas.Items[e.Index]);
        //        pagamento.DefinirDesatualizado();
        //    }
        //    else
        //        throw new NotSupportedException();
        //}

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* O padrão da cultura atual é utilizar virgula. 
             * No entanto, os funcionários utilizam o ponto do 
             * teclado numérico.
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

        private void Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!pagamento.Cadastrado || !pagamento.Atualizado)
            //{
            //    e.Cancel =
            //        MessageBox.Show(this, "Descartar alterações?", "Fechando a janela", MessageBoxButtons.YesNo)
            //        == DialogResult.No;
            //}
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

        public static Cadastro ConstruirJanelaEdição(Entidades.Pagamentos.Pagamento pagamento)
        {
            Cadastro dlg;

            if (pagamento is Cheque)
                dlg = new CadastroCheque();

            else if (pagamento is Dinheiro)
                dlg = new CadastroDinheiro();

            else if (pagamento is NotaPromissória)
                dlg = new CadastroNotaPromissória();

            //else if (pagamento is Crédito)
            //    dlg = new CadastroCrédito();

            else
                throw new NotSupportedException();

            dlg.PrepararParaAlteração(pagamento);

            return dlg;
        }

        private void txtIdentificação_Validated(object sender, EventArgs e)
        {
            pagamento.Descrição = txtDescrição.Text;
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
    }
}