using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Mercadoria;
using System.Collections;
using Entidades;

namespace Apresentação.Financeiro.Cotação
{
    /// <summary>
    /// Janela para edição de moeda.
    /// </summary>
    public partial class EditarMoeda : JanelaExplicativa
    {
        private const string msgSistema = "Como esta moeda é definida pelo sistema, não é possível alterar seus dados.";
        private Moeda moeda;

        /// <summary>
        /// Moeda (a ser) editada.
        /// </summary>
        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value;

                txtNome.Text = value.Nome;
                cmbComponente.SelectedIndex = moeda.ComponenteDeCusto != null ? cmbComponente.Items.IndexOf(moeda.ComponenteDeCusto) : -1;
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

            try
            {
                List<ComponenteCusto> componentes = ComponenteCusto.ObterComponentes();

                cmbComponente.Items.AddRange(componentes.ToArray());
            }
            finally
            {
                AguardeDB.Fechar();
            }
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
            if (moeda.ComponenteDeCusto == null || !moeda.ComponenteDeCusto.Equals(cmbComponente.SelectedItem))
                moeda.ComponenteDeCusto = cmbComponente.SelectedItem as ComponenteCusto;
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