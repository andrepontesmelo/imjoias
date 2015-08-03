using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Venda
{
    public partial class EditarDébito : JanelaExplicativa
    {
        private VendaDébito débito;
        private DateTime dataVenda;

        public VendaDébito Débito
        {
            get { return débito; }
        }

        private EditarDébito()
        {
            InitializeComponent();
            txtValorBruto.Focus();
        }

        public EditarDébito(Entidades.Relacionamento.Venda.Venda venda)
            : this()
        {
            débito = new VendaDébito(venda);

            txtDiasDeJuros.Int = 0;
            dataVenda = venda.Data;
            txtValorBruto.Focus();
        }

        public EditarDébito(VendaDébito débito)
            : this()
        {
            this.débito = débito;

            dataVenda = débito.Venda.Data;
            txtDiasDeJuros.Int = débito.DiasDeJuros;
            data.Value = débito.Data;
            txtValorBruto.Double = débito.ValorBruto;
            txtValorLíquido.Double = débito.ValorLíquido;
            txtDescrição.Text = débito.Descrição;
            chkCobrarJuros.Checked = débito.CobrarJuros;
            //chkComissão.Checked = débito.Comissão;

            btnOK.Focus();
        }

        private void txtDescrição_Validated(object sender, EventArgs e)
        {
            débito.Descrição = txtDescrição.Text.Trim();
        }

        //private void chkComissão_CheckedChanged(object sender, EventArgs e)
        //{
        //    débito.Comissão = chkComissão.Checked;
        //}

        private void txtValor_Validated(object sender, EventArgs e)
        {
            débito.ValorBruto = txtValorBruto.Double;
            CalcularJuros();
        }

        private void data_Validated(object sender, EventArgs e)
        {
            débito.Data = data.Value;
            CalcularJuros();
        }

        private void txtValorLíquido_Validated(object sender, EventArgs e)
        {
            débito.ValorLíquido = txtValorLíquido.Double;
        }

        private void chkCobrarJuros_Validated(object sender, EventArgs e)
        {
            débito.CobrarJuros = chkCobrarJuros.Checked;
        }

        //private void chkComissão_Validated(object sender, EventArgs e)
        //{
        //    débito.Comissão = chkComissão.Checked;
        //}

        private void CalcularJuros()
        {
            txtValorLíquido.Double =
                débito.CalcularValorLíquido();
        }

        private void data_ValueChanged(object sender, EventArgs e)
        {
            débito.Data = data.Value;
            txtDiasDeJuros.Int = Entidades.Preço.CalcularDias(débito.Data, dataVenda);
        }

        private void txtDiasDeJuros_TextChanged(object sender, EventArgs e)
        {
            débito.DiasDeJuros = txtDiasDeJuros.Int;
            CalcularJuros();
        }

        private void chkCobrarJuros_CheckedChanged(object sender, EventArgs e)
        {
            débito.CobrarJuros = chkCobrarJuros.Checked;
            txtDiasDeJuros.Enabled = chkCobrarJuros.Checked;
            CalcularJuros();
        }
    }
}