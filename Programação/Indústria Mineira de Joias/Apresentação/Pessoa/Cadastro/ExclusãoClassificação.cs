using Apresentação.Formulários;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class ExclusãoClassificação : JanelaExplicativa
    {
        public delegate void ItemExcluido();
        public ItemExcluido EventoItemExcluido;

        private List<Entidades.Pessoa.Pessoa> afetadas;
        private Classificação classificador;

        public ExclusãoClassificação()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Carregar(Classificação classificador, List<Entidades.Pessoa.Pessoa> afetadas)
        {
            this.afetadas = afetadas;
            this.classificador = classificador;

            //lblTítulo.Text = "Exclusão de classificação '" + classificador.Denominação + "'";
            Text = "Exclusão de '" + classificador.Denominação + "'";

            foreach (Entidades.Pessoa.Pessoa p in afetadas)
            {
                ListViewItem novoItem = new ListViewItem(new string [] { p.Código.ToString(), p.Nome });
                listView.Items.Add(novoItem);
            }

            groupBox1.Text = afetadas.Count.ToString() + " Pessoa(s) ";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Aguarde janela = new Aguarde("Exclusão de classificação", afetadas.Count);
            janela.Show();

            foreach (Entidades.Pessoa.Pessoa p in afetadas)
            {
                classificador.DefinirAtribuição(p, false);
                p.AtualizarClassificação();
                janela.Passo(p.Nome);
            }

            classificador.Descadastrar();

            janela.Close();

            if (EventoItemExcluido != null)
                EventoItemExcluido();

            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
