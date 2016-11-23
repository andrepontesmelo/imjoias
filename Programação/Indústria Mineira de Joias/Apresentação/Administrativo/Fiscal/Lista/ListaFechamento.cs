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
    }
}
