using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Apresenta��o.Financeiro.Cota��o
{
    public partial class RegistrarCota��o : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public delegate void RegistrarCota��oDelegate(Entidades.Financeiro.Cota��o cota��o);
        public RegistrarCota��oDelegate Cota��oRegistrada;
        private CultureInfo cultura;
        private Moeda moeda;

        public Moeda Moeda
        {
            set 
            { 
                moeda = value;
                lblT�tulo.Text = moeda.Nome;
            }
        }

        public RegistrarCota��o()
        {
            InitializeComponent();

            txtRespons�vel.Text = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual.Nome;
            data.Value = Entidades.Configura��o.DadosGlobais.Inst�ncia.HoraDataAtual;
            cultura = Entidades.Configura��o.DadosGlobais.Inst�ncia.Cultura;
        }

        /// <summary>
        /// Ocorre ao clicar em OK.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Entidades.Financeiro.Cota��o novaCota��o;
            
            UseWaitCursor = true;

            //cota��es = Aplica��oIntegrada.Aplica��oAtual.Contextos.Cota��es;
            //cota��es.RegistrarCota��o(txtCota��o.Double);

            //if (comboMoeda.Sele��o == null)
            //{
            //    MessageBox.Show(this,
            //        "Por favor, escolha uma moeda antes de prosseguir.",
            //        "Registrar cota��o",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            novaCota��o = Entidades.Financeiro.Cota��o.RegistrarCota��o(moeda, txtCota��o.Double, data.Value);

            // Dispara o evento
            if (Cota��oRegistrada != null)
                Cota��oRegistrada(novaCota��o);
            
            UseWaitCursor = false;

            Close();
            Dispose();
        }

        private void txtCota��o_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ',':
                case '.':
                    txtCota��o.SelectedText = cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}

