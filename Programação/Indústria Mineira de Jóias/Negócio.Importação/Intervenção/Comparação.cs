using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Pessoa.Cadastro;

namespace Apresentação.Importação.Intervenção
{
    public partial class Comparação : Form
    {
        private CadastroCliente[] dlgs;
        private bool duplicar = false;
        private bool ok = false;

        public bool OK { get { return ok; } }
        public bool Duplicar { get { return duplicar; } }

        public Comparação()
        {
            InitializeComponent();
        }

        public void Mostrar(Entidades.Pessoa.Pessoa[] pessoas, Entidades.Pessoa.Pessoa novo)
        {
            dlgs = new CadastroCliente[pessoas.Length + 1];

            for (int i = 0; i < dlgs.Length - 1; i++)
            {
                dlgs[i] = new CadastroCliente(pessoas[i]);
                dlgs[i].Name = "CadastroCliente" + i.ToString();
                dlgs[i].MdiParent = this;
                dlgs[i].Show();
            }

            dlgs[dlgs.Length - 1] = new CadastroCliente(novo);
            dlgs[dlgs.Length - 1].MdiParent = this;
            dlgs[dlgs.Length - 1].Show();
            dlgs[dlgs.Length - 1].BackColor = Color.Yellow;
            dlgs[dlgs.Length - 1].Text += " - Importando";

            MessageBox.Show(
                this,
                "Verifique os dados se correspondem à mesma pessoa. Se sim, corrija os dados necessários na janela correspondente do cadastro já existente e, ao término, clique em desconsiderar cadastro repetido (marcado em amarelo).",
                "Duplicação de cadastro",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                this,
                "Deseja manter todos estes cadastros aparentemente duplicados?\n\nSe você reponder que não, você ainda poderá editá-los.",
                "Duplicação de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                ok = true;
                duplicar = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                this,
                "Deseja mesmo excluir o cadastro duplicado que está marcado com a cor amarela?",
                "Duplicação de cadastro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                ok = true;
                duplicar = false;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Comparação_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (CadastroCliente dlg in dlgs)
                dlg.ValidateChildren();

            if (e.CloseReason == CloseReason.UserClosing && !ok)
            {
                if (MessageBox.Show(this,
                    "Deseja mesmo cancelar a importação?",
                    "Duplicação de cadastro",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                    DialogResult = DialogResult.Cancel;
            }
        }

        private void Comparação_Shown(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
