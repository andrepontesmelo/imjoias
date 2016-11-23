using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Fiscal;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaFechamento : UserControl
    {
        public Fechamento Seleção => lista.SelectedItems.Count > 0 ? lista.SelectedItems[0].Tag as Fechamento : null; 

        public ListaFechamento()
        {
            InitializeComponent();
        }

        public void Carregar()
        {
            Carregar(Fechamento.Obter());
        }

        private void Carregar(List<Fechamento> entidades)
        {
            lista.Items.Clear();
            lista.Items.AddRange(CriarItens(entidades));
        }

        private ListViewItem[] CriarItens(List<Fechamento> entidades)
        {
            ListViewItem[] resultado = new ListViewItem[entidades.Count];

            for (int x = 0; x < resultado.Length; x++)
                resultado[x] = CriarItem(entidades[x]);

            return resultado;
        }

        private ListViewItem CriarItem(Fechamento fechamento)
        {
            var item = new ListViewItem(new string[lista.Columns.Count]);
            item.SubItems[colId.Index].Text = fechamento.Código.ToString();
            item.SubItems[colInício.Index].Text = FormatarData(fechamento.Início);
            item.SubItems[colFim.Index].Text = FormatarData(fechamento.Fim);
            item.SubItems[colFechado.Index].Text = fechamento.Fechado ? "sim" : "não";
            item.Tag = fechamento;

            return item;
        }

        private string FormatarData(DateTime início)
        {
            return início.ToShortDateString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SolicitarExclusão();
        }

        private void lista_AoExcluir(object sender, EventArgs e)
        {
            SolicitarExclusão();
        }

        private void SolicitarExclusão()
        {
            Fechamento seleção = Seleção;

            if (seleção == null)
                return;

            if (MessageBox.Show(this,
                "Confirma exclusão?",
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            seleção.Excluir();
            Carregar();
        }
    }
}
