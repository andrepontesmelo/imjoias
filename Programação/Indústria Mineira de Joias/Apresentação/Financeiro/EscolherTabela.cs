using Apresentação.Formulários;
using Entidades;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Questiona ao usuário qual tabela utilizar.
    /// </summary>
    public partial class EscolherTabela : JanelaExplicativa
    {
        private List<Tabela> lista = new List<Tabela>();

        public EscolherTabela()
        {
            InitializeComponent();

            AguardeDB.Mostrar();

            try
            {
                foreach (Tabela tabela in Tabela.ObterTabelas(Funcionário.FuncionárioAtual.Setor))
                    AdicionarTabela(tabela, false);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        public EscolherTabela(Entidades.Pessoa.Pessoa pessoa) : this()
        {
            if (pessoa != null && pessoa.Setor != null)
            {
                List<Tabela> tabelas = Tabela.ObterTabelas(pessoa.Setor);

                foreach (Tabela tabela in tabelas)
                    if (!lista.Contains(tabela))
                        AdicionarTabela(tabela, false);
            }

            if (lst.Items.Count == 0 && Representante.ÉRepresentante(pessoa))
                foreach (Tabela tabela in Tabela.ObterTabelas())
                    if (!lista.Contains(tabela))
                        AdicionarTabela(tabela, false);
        }

        /// <summary>
        /// Adiciona tabela na lista.
        /// </summary>
        private void AdicionarTabela(Tabela tabela, bool ressaltarSetor)
        {
            ListViewItem item = new ListViewItem();

            lista.Add(tabela);

            item.Text = tabela.Nome;
            item.SubItems.Add(tabela.Setor.Nome);
            item.Tag = tabela;

            if (ressaltarSetor && tabela.Setor.Código == Funcionário.FuncionárioAtual.Setor.Código)
                item.Font = new Font(item.Font, FontStyle.Bold);

            lst.Items.Add(item);
        }

        public Tabela Tabela
        {
            get { return (Tabela)lst.SelectedItems[0].Tag; }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lst.SelectedItems.Count == 1;
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            if (btnOK.Enabled)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void botãoLiberarRecurso_LiberarRecurso(object sender, EventArgs e)
        {
            lst.Items.Clear();

            foreach (Tabela tabela in Tabela.ObterTabelas())
                AdicionarTabela(tabela, true);
        }

        private void EscolherTabela_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}