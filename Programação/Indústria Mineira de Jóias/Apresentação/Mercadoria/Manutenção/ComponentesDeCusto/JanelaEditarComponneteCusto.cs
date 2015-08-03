using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    public partial class JanelaEditarComponenteCusto : Apresentação.Formulários.JanelaExplicativa
    {
        public enum Modo { Alteração, Inserção }
        private Modo modoAtual = Modo.Inserção;
        private ComponenteCusto referência;

        public JanelaEditarComponenteCusto()
        {
            InitializeComponent();
        }

        public Modo ModoAtual
        {
            set
            {
                modoAtual = value;

                if (modoAtual == Modo.Inserção)
                    lblTítulo.Text = "Novo componente";
                else
                    lblTítulo.Text = "Alterando componente";

                txtCódigo.Enabled = (modoAtual == Modo.Inserção);
            }
        }

        public string Código
        {
            get { return txtCódigo.Text; }
            set { txtCódigo.Text = value; }
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
        
        public ComponenteCusto Referência
        {
            get { return comboBoxComponenteCusto.SelectedItem as Entidades.Mercadoria.ComponenteCusto; }
            set 
            { 
                referência = value;
                comboBoxComponenteCusto.SelectedItem = referência;
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

            if (Código.Trim().Length == 0)
                erroMsg += "\n* Código não preenchido";

            if (Nome.Trim().Length == 0)
                erroMsg += "\n* Nome não preenchido";

            if (modoAtual == Modo.Inserção && 
                Entidades.Mercadoria.ComponenteCusto.VerificarExistência(Código))
                    erroMsg += "\n* Código já cadastrado";

            if (Referência != null && Referência.Código == Código)
                erroMsg += "\n* Referência cíclica: Este componente não pode depender dele próprio.";

            if (Referência != null
                && Referência.GeraReferênciaCíclica(Código))
                    erroMsg += "\n* Referência cíclica indireta: Este componente não pode depender de outro que dependa deste";

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
            comboBoxComponenteCusto.SelectedItem = referência;
            
            if (referência != null)
                comboBoxComponenteCusto.Text = referência.ToString();

            txtCódigo.Focus();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    txtValor.SelectedText = Entidades.Configuração.DadosGlobais.Instância.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}