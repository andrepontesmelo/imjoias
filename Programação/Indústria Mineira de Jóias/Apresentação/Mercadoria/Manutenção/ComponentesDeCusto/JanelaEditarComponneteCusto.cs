using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresenta��o.Mercadoria.Manuten��o.ComponentesDeCusto
{
    public partial class JanelaEditarComponenteCusto : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public enum Modo { Altera��o, Inser��o }
        private Modo modoAtual = Modo.Inser��o;
        private ComponenteCusto refer�ncia;

        public JanelaEditarComponenteCusto()
        {
            InitializeComponent();
        }

        public Modo ModoAtual
        {
            set
            {
                modoAtual = value;

                if (modoAtual == Modo.Inser��o)
                    lblT�tulo.Text = "Novo componente";
                else
                    lblT�tulo.Text = "Alterando componente";

                txtC�digo.Enabled = (modoAtual == Modo.Inser��o);
            }
        }

        public string C�digo
        {
            get { return txtC�digo.Text; }
            set { txtC�digo.Text = value; }
        }

        public double Valor
        {
            get { return txtValor.Double; }
            set { txtValor.Double = value; }
        }

        public string Nome
        {
            get { return txtNome.Text; }
            set { txtNome.Text = value; }
        }
        
        public ComponenteCusto Refer�ncia
        {
            get { return comboBoxComponenteCusto.SelectedItem as Entidades.Mercadoria.ComponenteCusto; }
            set 
            { 
                refer�ncia = value;
                comboBoxComponenteCusto.SelectedItem = refer�ncia;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string erroMsg = "";

            if (C�digo.Trim().Length == 0)
                erroMsg += "\n* C�digo n�o preenchido";

            if (Nome.Trim().Length == 0)
                erroMsg += "\n* Nome n�o preenchido";

            if (modoAtual == Modo.Inser��o && 
                Entidades.Mercadoria.ComponenteCusto.VerificarExist�ncia(C�digo))
                    erroMsg += "\n* C�digo j� cadastrado";

            if (Refer�ncia != null && Refer�ncia.C�digo == C�digo)
                erroMsg += "\n* Refer�ncia c�clica: Este componente n�o pode depender dele pr�prio.";

            if (Refer�ncia != null
                && Refer�ncia.GeraRefer�nciaC�clica(C�digo))
                    erroMsg += "\n* Refer�ncia c�clica indireta: Este componente n�o pode depender de outro que dependa deste";

                if (!String.IsNullOrEmpty(erroMsg))
                {
                    MessageBox.Show(erroMsg, "Erros encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
        }

        private void JanelaEditarComponneteCusto_Load(object sender, EventArgs e)
        {
            comboBoxComponenteCusto.Carregar();
            comboBoxComponenteCusto.SelectedItem = refer�ncia;
            
            if (refer�ncia != null)
                comboBoxComponenteCusto.Text = refer�ncia.ToString();

            txtC�digo.Focus();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    txtValor.SelectedText = Entidades.Configura��o.DadosGlobais.Inst�ncia.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}