using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Apresentação.Financeiro.Cotação
{
    public partial class RegistrarCotação : Apresentação.Formulários.JanelaExplicativa
    {
        public delegate void RegistrarCotaçãoDelegate(Entidades.Financeiro.Cotação cotação);
        public RegistrarCotaçãoDelegate CotaçãoRegistrada;
        private CultureInfo cultura;
        private Moeda moeda;

        public Moeda Moeda
        {
            set 
            { 
                moeda = value;
                lblTítulo.Text = moeda.Nome;
            }
        }

        public RegistrarCotação()
        {
            InitializeComponent();

            txtResponsável.Text = Entidades.Pessoa.Funcionário.FuncionárioAtual.Nome;
            data.Value = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;
            cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;
        }

        /// <summary>
        /// Ocorre ao clicar em OK.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Entidades.Financeiro.Cotação novaCotação;
            
            UseWaitCursor = true;

            //cotações = AplicaçãoIntegrada.AplicaçãoAtual.Contextos.Cotações;
            //cotações.RegistrarCotação(txtCotação.Double);

            //if (comboMoeda.Seleção == null)
            //{
            //    MessageBox.Show(this,
            //        "Por favor, escolha uma moeda antes de prosseguir.",
            //        "Registrar cotação",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            novaCotação = Entidades.Financeiro.Cotação.RegistrarCotação(moeda, txtCotação.Double, data.Value);

            // Dispara o evento
            if (CotaçãoRegistrada != null)
                CotaçãoRegistrada(novaCotação);
            
            UseWaitCursor = false;

            Close();
            Dispose();
        }

        private void txtCotação_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ',':
                case '.':
                    txtCotação.SelectedText = cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}

