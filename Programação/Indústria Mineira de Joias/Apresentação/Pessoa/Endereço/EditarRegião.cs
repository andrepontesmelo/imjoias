using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endereço;
using Apresentação.Pessoa.Consultas;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// Formulário para edição de região.
    /// </summary>
    public partial class EditarRegião : Apresentação.Formulários.JanelaExplicativa
    {
        private Região região;

        public EditarRegião()
        {
            InitializeComponent();

            Região = new Região();

            txtCódigo.ReadOnly = false;
        }

        public EditarRegião(Região região)
        {
            InitializeComponent();

            Região = região;
        }

        public Região Região
        {
            get { return região; }
            set
            {
                this.região = value;

                txtCódigo.Text = value.Código.ToString();
                txtNome.Text = value.Nome;
                txtObs.Text = value.Observações;

                foreach (Estado estado in value.Estados)
                    lstEstados.Items.Add(estado);

                foreach (Localidade localidade in value.Localidades)
                    lstLocalidades.Items.Add(localidade);
            }
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            região.Nome = txtNome.Text.Trim();
        }

        private void txtObs_Validated(object sender, EventArgs e)
        {
            região.Observações = txtObs.Text.Trim();
        }

        private void lstEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdEstadoRemover.Enabled = lstEstados.SelectedItem != null;
        }

        private void lstLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdLocalidadeRemover.Enabled = lstLocalidades.SelectedItem != null;
        }

        private void cmdEstadoRemover_Click(object sender, EventArgs e)
        {
            região.Estados.Remover((Estado)lstEstados.SelectedItem);
            lstEstados.Items.RemoveAt(lstEstados.SelectedIndex);
        }

        private void cmdLocalidadeRemover_Click(object sender, EventArgs e)
        {
            região.Localidades.Remover((Localidade)lstLocalidades.SelectedItem);
            lstLocalidades.Items.RemoveAt(lstLocalidades.SelectedIndex);
        }

        private void cmdLocalidadeAdicionar_Click(object sender, EventArgs e)
        {
            Localidade localidade;

            localidade = ProcurarLocalidade.Procurar(this);

            if (localidade != null)
            {
                região.Localidades.Adicionar(localidade);
                lstLocalidades.Items.Add(localidade);
            }
        }

        private void cmdEstadoAdicionar_Click(object sender, EventArgs e)
        {
            using (EscolherEstado dlg = new EscolherEstado())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    região.Estados.Adicionar(dlg.Estado);
                    lstEstados.Items.Add(dlg.Estado);
                }
            }
        }

        private void cmdPessoaAdicionar_Click(object sender, EventArgs e)
        {
            Entidades.Pessoa.Pessoa pessoa = ProcurarPessoa.Procurar(null);

            if (pessoa != null)
            {
                lstPessoas.Items.Add(pessoa);
            }
        }

        private void txtCódigo_Validated(object sender, EventArgs e)
        {
            região.DefinirCódigo(uint.Parse(txtCódigo.Text));
        }

        private void txtCódigo_Validating(object sender, CancelEventArgs e)
        {
            if (região.Cadastrado)
                e.Cancel = uint.Parse(txtCódigo.Text) != região.Código;
        }
    }
}

