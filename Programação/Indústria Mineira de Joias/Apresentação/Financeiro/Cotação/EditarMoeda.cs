using Apresentação.Formulários;
using Entidades.Mercadoria;
using Entidades.Moedas;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Cotação
{
    public partial class EditarMoeda : JanelaExplicativa
    {
        private const string msgSistema = "Como esta moeda é definida pelo sistema, não é possível alterar seus dados.";
        private Moeda moeda;

        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value;

                txtNome.Text = value.Nome;
                cmbComponente.SelectedIndex = moeda.ComponenteCusto != null ? cmbComponente.Items.IndexOf(moeda.ComponenteCusto) : -1;
                picMoeda.Image = value.Ícone;
                txtCasasDecimais.Int = value.CasasDecimais;

                txtNome.ReadOnly = value.Sistema;
                cmbComponente.Enabled = !value.Sistema;
                lnkÍcone.Enabled = !value.Sistema;
                txtCasasDecimais.ReadOnly = value.Sistema;
            }
        }

        public EditarMoeda()
        {
            InitializeComponent();

            CarregarComponentes();
        }

        public EditarMoeda(Moeda moeda) : this()
        {
            Moeda = moeda;
        }

        private void CarregarComponentes()
        {
            AguardeDB.Mostrar();
            cmbComponente.Items.AddRange(ComponenteCusto.Lista.ToArray());
            AguardeDB.Fechar();
        }

        private void lnkÍcone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    moeda.Ícone = Image.FromFile(openFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show(
                        this,
                        "Não foi possível importar a imagem escolhida.",
                        "Edição de moeda",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    picMoeda.Image = moeda.Ícone;
                }
            }
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            moeda.Nome = txtNome.Text.Trim();
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = txtNome.Text.Trim().Length == 0;
        }

        private void cmbComponente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moeda.ComponenteCusto == null || !moeda.ComponenteCusto.Equals(cmbComponente.SelectedItem))
                moeda.ComponenteCusto = cmbComponente.SelectedItem as ComponenteCusto;
        }

        private void EditarMoeda_Shown(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            if (moeda == null)
                moeda = new Moeda();

            else if (moeda.Sistema)
            {
                MessageBox.Show(
                    this,
                    msgSistema, "Edição de moeda",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDescrição.Text = msgSistema;
            }
        }

        private void txtCasasDecimais_Validated(object sender, EventArgs e)
        {
            moeda.CasasDecimais = (byte)txtCasasDecimais.Int;
        }
    }
}