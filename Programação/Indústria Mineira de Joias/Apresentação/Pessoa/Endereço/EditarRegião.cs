using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endere�o;
using Apresenta��o.Pessoa.Consultas;

namespace Apresenta��o.Pessoa.Endere�o
{
    /// <summary>
    /// Formul�rio para edi��o de regi�o.
    /// </summary>
    public partial class EditarRegi�o : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Regi�o regi�o;

        public EditarRegi�o()
        {
            InitializeComponent();

            Regi�o = new Regi�o();

            txtC�digo.ReadOnly = false;
        }

        public EditarRegi�o(Regi�o regi�o)
        {
            InitializeComponent();

            Regi�o = regi�o;
        }

        public Regi�o Regi�o
        {
            get { return regi�o; }
            set
            {
                this.regi�o = value;

                txtC�digo.Text = value.C�digo.ToString();
                txtNome.Text = value.Nome;
                txtObs.Text = value.Observa��es;

                foreach (Estado estado in value.Estados)
                    lstEstados.Items.Add(estado);

                foreach (Localidade localidade in value.Localidades)
                    lstLocalidades.Items.Add(localidade);
            }
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            regi�o.Nome = txtNome.Text.Trim();
        }

        private void txtObs_Validated(object sender, EventArgs e)
        {
            regi�o.Observa��es = txtObs.Text.Trim();
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
            regi�o.Estados.Remover((Estado)lstEstados.SelectedItem);
            lstEstados.Items.RemoveAt(lstEstados.SelectedIndex);
        }

        private void cmdLocalidadeRemover_Click(object sender, EventArgs e)
        {
            regi�o.Localidades.Remover((Localidade)lstLocalidades.SelectedItem);
            lstLocalidades.Items.RemoveAt(lstLocalidades.SelectedIndex);
        }

        private void cmdLocalidadeAdicionar_Click(object sender, EventArgs e)
        {
            Localidade localidade;

            localidade = ProcurarLocalidade.Procurar(this);

            if (localidade != null)
            {
                regi�o.Localidades.Adicionar(localidade);
                lstLocalidades.Items.Add(localidade);
            }
        }

        private void cmdEstadoAdicionar_Click(object sender, EventArgs e)
        {
            using (EscolherEstado dlg = new EscolherEstado())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    regi�o.Estados.Adicionar(dlg.Estado);
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

        private void txtC�digo_Validated(object sender, EventArgs e)
        {
            regi�o.DefinirC�digo(uint.Parse(txtC�digo.Text));
        }

        private void txtC�digo_Validating(object sender, CancelEventArgs e)
        {
            if (regi�o.Cadastrado)
                e.Cancel = uint.Parse(txtC�digo.Text) != regi�o.C�digo;
        }
    }
}

