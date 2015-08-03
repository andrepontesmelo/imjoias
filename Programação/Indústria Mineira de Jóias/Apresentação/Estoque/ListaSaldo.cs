using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Estoque;
using Apresentação.Formulários;

namespace Apresentação.Estoque
{
    public partial class ListaSaldo : UserControl
    {
        public event EventHandler AoDuploClique;

        struct ResultadoCarga
        {
            public List<ListViewItem> ListaGrafica;
            public double TotalSaldoPeso;
            public int TotalReferencias;
        }


        public ListaSaldo()
        {
            InitializeComponent();
        }

        public void Carregar()
        {
            if (!bg.IsBusy)
            {
                AguardeDB.Mostrar();
                bg.RunWorkerAsync();
            }
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {

            List<Saldo> entidades = Entidades.Estoque.Saldo.Obter();
            ResultadoCarga resultado = new ResultadoCarga();

            resultado.ListaGrafica = new List<ListViewItem>(entidades.Count);

            ListViewGroup grupoDePeso = lst.Groups[0];
            ListViewGroup grupoDeReferencia = lst.Groups[1];

            foreach (Saldo s in entidades)
            {
                ListViewItem i;

                if (s.Depeso)
                    i = new ListViewItem(grupoDePeso);
                else
                    i = new ListViewItem(grupoDeReferencia);

                i.Text = Entidades.Mercadoria.Mercadoria.MascararReferência(s.Referencia);
                i.SubItems.Add(s.Peso.ToString());
                i.SubItems.Add(s.Entrada.ToString());
                i.SubItems.Add(s.Venda.ToString());
                i.SubItems.Add(s.Devolucao.ToString());
                i.SubItems.Add(s.SaldoValor.ToString());
                i.SubItems.Add(s.FornecedorNome);
                i.SubItems.Add(s.FornecedorReferência);

                i.Tag = s;
                resultado.ListaGrafica.Add(i);
                resultado.TotalSaldoPeso += s.Peso * s.SaldoValor;
            }

            resultado.TotalReferencias = entidades.Count;
            resultado.TotalSaldoPeso = Math.Round(resultado.TotalSaldoPeso, 2);
            e.Result = resultado;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResultadoCarga resultado = (ResultadoCarga)e.Result;

            lst.SuspendLayout();
            lst.Items.Clear();

            foreach (ListViewItem i in resultado.ListaGrafica)
                lst.Items.Add(i);

            panelReferencias.Text = resultado.TotalReferencias.ToString() + " Referência(s)";
            panelPesoTotal.Text = resultado.TotalSaldoPeso.ToString() + "g de saldo";
            lst.ResumeLayout();

            AguardeDB.Fechar();
        }

        public Saldo Seleção
        {
            get
            {
                if (lst.SelectedItems.Count == 0)
                    return null;

                return lst.SelectedItems[0].Tag as Saldo;
            }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            if (AoDuploClique != null)
                AoDuploClique(sender, e);
        }
    }
}
