using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades;
using Entidades.Pessoa;

namespace Apresentação.Financeiro.Venda
{
    /// <summary>
    /// Permite a criação de pagamentos, mediante à escolha da forma
    /// e das prestações.
    /// </summary>
    public partial class JanelaCriarPagamentos : JanelaExplicativa
    {
        double dívida, juros;

        private Entidades.Relacionamento.Venda.Venda venda;

        /// <summary>
        /// Constrói a janela a partir da venda.
        /// </summary>
        public JanelaCriarPagamentos(Entidades.Relacionamento.Venda.Venda venda)
        {
            InitializeComponent();

            this.venda = venda;

            venda.CalcularDívida(Preço.SomarDiasTabelaComercial(venda.Data, (int) venda.DiasSemJuros), out dívida, out juros);

            cmbPrestações.Items.Clear();

            //if (((TimeSpan)(DadosGlobais.Instância.HoraDataAtual.Date - venda.Data.Date)).Days == 0)
            //{
            foreach (string parcelamento in DadosGlobais.Instância.Parcelamento)
                cmbPrestações.Items.Add(parcelamento);

            cmbPrestações.SelectedItem = cmbPrestações.Items[0];
            //}
            //else
            //{
            //    cmbPrestações.Enabled = false;
            //    botãoLiberarPrestações.Visible = false;
            //}

            lblValor.Text = venda.Valor.ToString("C");

            if (venda.DescontoPercentual.HasValue && !txtDescontoPercentual.Focused)
                txtDescontoPercentual.Text =
                    string.Format("{0:######0.00}%", venda.DescontoPercentual.Value);

            if (venda.Desconto != 0 && !txtDesconto.Focused)
                txtDesconto.Text = venda.Desconto.ToString("C");

            lblValorComDesconto.Text = string.Format("{0:C}", venda.Valor - venda.Desconto);
            lblPago.Text = venda.CalcularValorPago().ToString("C");
            lblDívida.Text = dívida.ToString("C");
            txtDiasSemJuros.Int = (int)venda.DiasSemJuros;

            AtualizarValores();
        }


        /// <summary>
        /// Libera a escolha das prestações.
        /// </summary>
        private void botãoLiberarPrestações_LiberarRecurso(object sender, EventArgs e)
        {
            cmbPrestações.DropDownStyle = ComboBoxStyle.DropDown;
            cmbPrestações.Focus();
        }

        /// <summary>
        /// Libera a escolha do desconto.
        /// </summary>
        private void botãoLiberarDesconto_LiberarRecurso(object sender, EventArgs e)
        {
            // Mudou aqui ? tem outro lugar para mudar!!
            txtDesconto.ReadOnly = txtDescontoPercentual.ReadOnly 
                = txtDiasSemJuros.ReadOnly = false;

            txtDescontoPercentual.Focus();
        }

        /// <summary>
        /// Atualiza os valores.
        /// </summary>
        private void AtualizarValores()
        {
            if (cmbPrestações.Text.Length > 0 && cmbPrestações.Text.Trim() != "0")
            {
                double valorFinal;

                try
                {
                    valorFinal = CalcularPreçoFinal();
                }
                catch (FormatException e)
                {
                    MessageBox.Show(
                        this,
                        e.Message, "Prestações", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    lblPrestação.Text = lblValorFinal.Text = lblJuros.Text = "Erro";

                    return;
                }

                lblJuros.Text = string.Format("{0:C}",
                    valorFinal - dívida);

                lblValorFinal.Text = string.Format("{0:C}",
                    valorFinal);

                lblPrestação.Text = string.Format("{0:C}",
                    valorFinal / Preço.ContarPrestações(cmbPrestações.Text));

                radioDinheiro.Enabled = Preço.ContarPrestações(cmbPrestações.Text) == 1;
            }
            else
            {
                lblJuros.Text = juros.ToString("C");
                lblValorFinal.Text = dívida.ToString("C");
                lblPrestação.Text = dívida.ToString("C");
                radioDinheiro.Enabled = true;
            }

            btnOK.Enabled = true;
            btnAtualizar.Visible = false;
            timerAtualizar.Enabled = false;
        }

        /// <summary>
        /// Inicia edição após mudança nas prestações.
        /// </summary>
        private void cmbPrestações_TextUpdate(object sender, EventArgs e)
        {
            IniciarEdição();
        }

        /// <summary>
        /// Calcula o preço final.
        /// </summary>
        /// <returns>Preço final.</returns>
        private double CalcularPreçoFinal()
        {
            if (cmbPrestações.Text.Length > 0 && cmbPrestações.Text.Trim() != "0")
            {
                int dias;

                dias = Preço.InterpretarPrestações(cmbPrestações.Text);

                return Preço.AcrescentarJurosSimples(dívida, venda.TaxaJuros, dias);
            }
            else
                return dívida;
        }

        /// <summary>
        /// Inicia edição.
        /// </summary>
        private void IniciarEdição()
        {
            if (btnOK.Enabled)
            {
                lblValorComDesconto.Text = "";
                lblJuros.Text = "";
                lblValorFinal.Text = "";
                lblPrestação.Text = "";
                btnOK.Enabled = false;
                btnAtualizar.Visible = true;
                timerAtualizar.Enabled = true;
            }
        }

        /// <summary>
        /// Atualiza os dados.
        /// </summary>
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarValores();
        }

        /// <summary>
        /// Tenta atualizar os dados após 1 segundo.
        /// </summary>
        private void timerAtualizar_Tick(object sender, EventArgs e)
        {
            try
            {
                // Só para garantir que é interpretável.
                Preço.InterpretarPrestações(cmbPrestações.Text);

                AtualizarValores();
            }
            catch { }
        }

        /// <summary>
        /// Gera pagamentos, cadastra no banco de dados e
        /// pede confirmação do usuário.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<Entidades.Pagamentos.Pagamento> pagamentos;

            if (radioDinheiro.Checked && radioDinheiro.Enabled)
                pagamentos = GerarPagamentoDinheiro();

            else if (radioCheque.Checked)
                pagamentos = GerarPagamentoCheque();

            else if (radioPromissória.Checked)
                pagamentos = GerarPagamentoPromissória();

            else if (!radioPersonalizar.Checked)
            {
                MessageBox.Show(
                    this,
                    "Por favor, escolha antes a forma de pagamento.",
                    "Forma de pagamento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            else
                pagamentos = new List<Entidades.Pagamentos.Pagamento>();

            foreach (Entidades.Pagamentos.Pagamento pagamento in pagamentos)
                if (!pagamento.Cadastrado)
                    pagamento.Cadastrar();

            using (JanelaPersonalizarPagamentos personalizar = new JanelaPersonalizarPagamentos(venda))
            {
                if (personalizar.ShowDialog(this) == DialogResult.OK)
                {
                    if (Entidades.Pagamentos.Pagamento.ObterPagamentos(venda).Length > 0)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        MessageBox.Show(
                            this,
                            "Nenhum pagamento foi registrado!\n\nOperação cancelada!",
                            "Pagamentos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (Entidades.Pagamentos.Pagamento pagamento in pagamentos)
                        try
                        {
                            pagamento.Descadastrar();
                        }
                        catch { } // Talvez não esteja cadastrado.
                }
            }

            if (!venda.Atualizado)
                venda.Atualizar();
        }

        /// <summary>
        /// Gera pagamento em dinheiro - única prestação.
        /// </summary>
        private List<Entidades.Pagamentos.Pagamento> GerarPagamentoDinheiro()
        {
            List<Entidades.Pagamentos.Pagamento> pagamentos = new List<Entidades.Pagamentos.Pagamento>();

            Entidades.Pagamentos.Dinheiro dinheiro;

            dinheiro = new Entidades.Pagamentos.Dinheiro();

            dinheiro.Cliente = venda.Cliente.Código;
            dinheiro.Venda = venda.Código;
            dinheiro.Valor = CalcularPreçoFinal();
            dinheiro.ÚltimoVencimento = dinheiro.Data = DadosGlobais.Instância.HoraDataAtual;
            dinheiro.RegistradoPor = Funcionário.FuncionárioAtual;
            dinheiro.Pendente = false;

            pagamentos.Add(dinheiro);

            return pagamentos;
        }

        /// <summary>
        /// Gera pagamento em cheque.
        /// </summary>
        private List<Entidades.Pagamentos.Pagamento> GerarPagamentoCheque()
        {
            List<Entidades.Pagamentos.Pagamento> pagamentos = new List<Entidades.Pagamentos.Pagamento>();
            double valorFinal = CalcularPreçoFinal();
            double valor;
            int[] dias = Preço.InterpretarDiasPrestações(cmbPrestações.Text);
            DateTime data = Preço.SomarDiasTabelaComercial(venda.Data, (int) venda.DiasSemJuros);

            valor = Math.Round(valorFinal / (double)dias.Length, 2);

            for (int i = 0; i < dias.Length; i++)
            {
                Entidades.Pagamentos.Cheque cheque;

                cheque = new Entidades.Pagamentos.Cheque();
                cheque.Cliente = venda.Cliente.Código;
                cheque.Venda = venda.Código;
                cheque.Valor = valor;
                cheque.Data = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;
                cheque.RegistradoPor = Funcionário.FuncionárioAtual;
                cheque.Pendente = false;
                cheque.Vencimento = Preço.SomarDiasTabelaComercial(data, dias[i]);
                cheque.ProrrogadoPara = null;

                pagamentos.Add(cheque);
            }

            if (pagamentos.Count > 0)
                pagamentos[pagamentos.Count - 1].Valor += valorFinal - valor * dias.Length;

            return pagamentos;
        }

        /// <summary>
        /// Gera pagamento em notas promissórias.
        /// </summary>
        private List<Entidades.Pagamentos.Pagamento> GerarPagamentoPromissória()
        {
            List<Entidades.Pagamentos.Pagamento> pagamentos = new List<Entidades.Pagamentos.Pagamento>();
            double valorFinal = CalcularPreçoFinal();
            double valor;
            int[] dias = Preço.InterpretarDiasPrestações(cmbPrestações.Text);
            DateTime data = Preço.SomarDiasTabelaComercial(venda.Data, (int) venda.DiasSemJuros);

            valor = Math.Round(valorFinal / (double)dias.Length, 2);

            for (int i = 0; i < dias.Length; i++)
            {
                Entidades.Pagamentos.NotaPromissória promissória;

                promissória = new Entidades.Pagamentos.NotaPromissória();
                promissória.Cliente = venda.Cliente.Código;
                promissória.Venda = venda.Código;
                promissória.Valor = valor;
                //promissória.Valor = valorFinal;
                promissória.Data = DadosGlobais.Instância.HoraDataAtual;
                promissória.RegistradoPor = Funcionário.FuncionárioAtual;
                promissória.Pendente = true;
                promissória.ÚltimoVencimento = Preço.SomarDiasTabelaComercial(data, dias[i]);
                //promissória.Vencimento = promissória.Data.AddDays(dias[dias.Length - 1]);

                pagamentos.Add(promissória);
            }

            pagamentos[pagamentos.Count - 1].Valor += valorFinal - valor * dias.Length;

            return pagamentos;
        }

        /// <summary>
        /// Ocorre ao alterar o percentual de desconto.
        /// </summary>
        private void txtDescontoPercentual_TextChanged(object sender, EventArgs e)
        {
            if (txtDescontoPercentual.Focused)
            {
                double percentual;

                IniciarEdição();

                if (double.TryParse(txtDescontoPercentual.Text, out percentual))
                {
                    venda.DescontoPercentual = percentual;
                    txtDesconto.Double = venda.Desconto;
                }
                else
                {
                    venda.DescontoPercentual = null;
                    txtDesconto.Text = "";
                }
            }
        }

        /// <summary>
        /// Ocorre ao alterar o desconto.
        /// </summary>
        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            if (txtDesconto.Focused)
            {
                IniciarEdição();
                venda.Desconto = txtDesconto.Double;
                txtDescontoPercentual.Text = "";
            }
        }

        /// <summary>
        /// Ocorre ao escolher as prestações.
        /// </summary>
        private void cmbPrestações_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrestações.SelectedIndex >= 0)
                AtualizarValores();
            else
                IniciarEdição();
        }

        private void txtDescontoPercentual_Leave(object sender, EventArgs e)
        {
            AtualizarValores();
        }

        private void txtDiasSemJuros_TextChanged(object sender, EventArgs e)
        {
            if (txtDiasSemJuros.Focused)
            {
                IniciarEdição();
                venda.DiasSemJuros = (uint)txtDiasSemJuros.Int;
            }
        }

        private void txtDiasSemJuros_Leave(object sender, EventArgs e)
        {
            AtualizarValores();
        }

        private void botãoLiberarDiasSemJuros_LiberarRecurso(object sender, EventArgs e)
        {
            // Mudou aqui ? tem outro lugar!!
            txtDesconto.ReadOnly = txtDescontoPercentual.ReadOnly
                = txtDiasSemJuros.ReadOnly = false;

            txtDiasSemJuros.Focus();
        }

        private void lnkDatas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dataZero = Preço.SomarDiasTabelaComercial(venda.Data, (int)venda.DiasSemJuros);
            JanelaEscolhaDatasPagamento janela = new JanelaEscolhaDatasPagamento();

            int[] dias = Preço.InterpretarDiasPrestações(cmbPrestações.Text);

            List<DateTime> datas = new List<DateTime>();

            foreach (int dia in dias)
            {
                datas.Add(Preço.SomarDiasTabelaComercial(dataZero, dia));
            }

            janela.Datas = datas;
            janela.ShowDialog();
            
            datas = janela.Datas;



            string strDias = "";

            foreach (DateTime t in datas)
            {
                if (strDias != "")
                    strDias += "x";

                strDias += Preço.CalcularDiasTabelaComercial(dataZero, t).ToString();
            }

            cmbPrestações.DropDownStyle = ComboBoxStyle.DropDown;
            cmbPrestações.Text = strDias;
        }
    }
}