using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Pessoa.Endereço
{
    public partial class ComboBoxRegião : UserControl
    {
        /// <summary>
        /// Região usada somente na hora de atribuição
        /// e de carga do controle.
        /// </summary>
        private Região região;

        public ComboBoxRegião()
        {
            InitializeComponent();
        }

        public Região Região
        {
            get
            {
                return cmbRegião.SelectedItem as Região;
            }
            set
            {
                this.região = value;

                if (value != null && !cmbRegião.Items.Contains(value))
                {
                    cmbRegião.Items.Add(value);
                    cmbRegião.Text = value.Nome;
                }
            }
        }

        private void ComboBoxRegião_Resize(object sender, EventArgs e)
        {
            if (Height != cmbRegião.Height)
                Height = cmbRegião.Height;
        }

        private void btnAdicionarRegião_Click(object sender, EventArgs e)
        {
            using (EditarRegião dlg = new EditarRegião())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        dlg.Região.Cadastrar();
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "Não foi possível cadastrar a região.",
                            "Cadastro de região",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        AguardeDB.Fechar();
                        return;
                    }

                    cmbRegião.Items.Add(dlg.Região);
                    cmbRegião.SelectedItem = dlg.Região;

                    AguardeDB.Fechar();
                }
            }
        }

        private void ComboBoxRegião_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    AguardeDB.Mostrar();

                    cmbRegião.Items.AddRange(Região.ObterRegiões());

                    if (região != null && !cmbRegião.Items.Contains(região))
                    {
                        cmbRegião.Items.Add(região);
                        cmbRegião.Text = região.Nome;
                    }

                    AguardeDB.Fechar();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Não foi possível carregar lista de regiões:\n\n" + erro.ToString());
                }
            }
        }
    }
}
