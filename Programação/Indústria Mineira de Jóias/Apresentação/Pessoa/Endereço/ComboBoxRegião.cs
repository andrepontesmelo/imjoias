using Apresentação.Formulários;
using Entidades.Pessoa.Endereço;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Endereço
{
    public partial class ComboBoxRegião : UserControl
    {
        /// <summary>
        /// Região usada somente na hora de atribuição
        /// e de carga do controle.
        /// </summary>
        private Região região;
        private bool comissaoFoiTrocada = false;

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
             
                if (cmbRegião.Items.Count == 0 && value != null)
                    Carregar();

                if (value != null && cmbRegião.Items.Contains(value))
                {
                    cmbRegião.SelectedItem = value; 
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
                if (cmbRegião.Items.Count <= 1)
                    Carregar();
            }
        }

        private void btnRemoverRegião_Click(object sender, EventArgs e)
        {
            Entidades.Pessoa.Endereço.Região região = Região;

            if (região == null)
                return;

            if (!Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroRemover))
            {
                MessageBox.Show(this,
                        "Favor solicitar a permissão 'Remover Cadastro' para apagar esta região.",
                        "Sem permissão",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                return;
            }

            AguardeDB.Mostrar();

            List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoasPorRegião(região);

            AguardeDB.Fechar();

            if (pessoas.Count > 0)
            {
                JanelaRemanejarRegião janelaRemanejarRegião = new JanelaRemanejarRegião();
                janelaRemanejarRegião.eventoComissaoTrocada += new JanelaRemanejarRegião.ComissaoTrocadaDelegate(evento_comissãoTrocada);
                janelaRemanejarRegião.Carregar(pessoas, região);
                janelaRemanejarRegião.ShowDialog(this);

                if (!comissaoFoiTrocada)
                    return;
            }

            if (MessageBox.Show(this,
              "Confirma exclusão de região " + região.Nome + " ?",
              "Exclusão de região",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            região.Descadastrar();

            MessageBox.Show(this,
              " A região '" + região.ToString() + "' foi apagada!",
              "Sucesso",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);

            Recarregar();
        }

        private void evento_comissãoTrocada()
        {
            comissaoFoiTrocada = true;
            Recarregar();
        }

        private void Recarregar()
        {
            Limpar();
            Carregar();
        }

        private void Limpar()
        {
            cmbRegião.SelectedIndex = -1;
            cmbRegião.Text = "";
            cmbRegião.ValueMember = null;
            cmbRegião.ResetText();
            cmbRegião.Items.Clear();
        }

        internal void RemoveRegião(Entidades.Pessoa.Endereço.Região região)
        {
            CarregarExceto(região);
        }

        internal void Carregar()
        {
            CarregarExceto(null);
        }
      
        public void CarregarExceto(Região exceto)
        {
            Região[] regiões = Região.ObterRegiões();
            if (exceto != null) {
                regiões = Região.Remover(regiões, exceto);
            }

            cmbRegião.Items.AddRange(regiões);
            cmbRegião.SelectedIndex = -1;
        }
    }
}
