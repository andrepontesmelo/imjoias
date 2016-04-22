using Apresentação.Formulários;
using Entidades.Privilégio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Endereço
{
    public partial class JanelaRemanejarRegião : JanelaExplicativa
    {
        private List<Entidades.Pessoa.Pessoa> pessoas;
        private Entidades.Pessoa.Endereço.Região região;

        public delegate void ComissaoTrocadaDelegate();
        public ComissaoTrocadaDelegate eventoComissaoTrocada;

        public JanelaRemanejarRegião()
        {
            InitializeComponent();
        }

        public void Carregar(List<Entidades.Pessoa.Pessoa> pessoas, Entidades.Pessoa.Endereço.Região região)
        {
            this.pessoas = pessoas;
            this.região = região;

            lblDescrição.Text = "A(s) seguinte(s) " + pessoas.Count.ToString() 
                + " pessoa(s) está/estão atualmente cadastrada(s) na região " + região.ToString() 
                + ". Selecione uma nova região para elas.";
            listView.Items.Clear();
            comboBoxRegião.CarregarExceto(região);

            foreach (Entidades.Pessoa.Pessoa p in pessoas)
            {
                ListViewItem novo = new ListViewItem(new string[] { p.Código.ToString(), p.Nome });
                listView.Items.Add(novo);
            }
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (!Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroEditar))
            {
                MessageBox.Show(this,
                        "Favor solicitar a permissão 'Editar Cadastro' para alterar a região destas pessoas.",
                        "Sem permissão",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                return;
            }

            if (MessageBox.Show(this,
              "Confirma alteração de região de " + pessoas.Count.ToString() + "\n" + 
              "pessoa(s) de " + região.ToString() + " para " + comboBoxRegião.Região.ToString() + " ?",
              "Mudança de região",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            if (comboBoxRegião.Região != null && pessoas.Count > 0)
            {
                AguardeDB.Mostrar();
                int cadastrosAlterados = Entidades.Pessoa.Pessoa.TrocarRegião(pessoas, comboBoxRegião.Região);
                AguardeDB.Fechar();

                if (cadastrosAlterados > 0 && eventoComissaoTrocada != null)
                {
                    eventoComissaoTrocada();

                    MessageBox.Show(this,
                    cadastrosAlterados.ToString() +  " cadastro(s) alterado(s)!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                Close();
            }
        }
    }
}