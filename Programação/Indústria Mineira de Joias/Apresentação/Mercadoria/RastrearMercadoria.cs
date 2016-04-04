using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Apresenta��o.Formul�rios;
using Entidades.�lbum;
using Acesso.Comum;

namespace Apresenta��o.Mercadoria
{
    /// <summary>
    /// Janela que mostra o rastro de mercadoria.
    /// </summary>
    public partial class RastrearMercadoria : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private ComparadorListViewConsignado comparadorConsignado = new ComparadorListViewConsignado();
        private ComparadorListViewVenda comparadorVenda = new ComparadorListViewVenda();

        public RastrearMercadoria()
        {
            InitializeComponent();

            lstConsignado.ListViewItemSorter = comparadorConsignado;
            lstVendas.ListViewItemSorter = comparadorVenda;
        }

        public RastrearMercadoria(Entidades.Mercadoria.Mercadoria mercadoria)
            : this()
        {
            txtMercadoria.Refer�ncia = mercadoria.Refer�ncia;
            Rastrear();
        }

        private void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (comparadorConsignado.Coluna == e.Column)
                lstConsignado.Sorting = lstConsignado.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            else
                comparadorConsignado.Coluna = e.Column;

            lstConsignado.Sort();
        }

        private void lstVendas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (comparadorVenda.Coluna == e.Column)
                lstVendas.Sorting = lstConsignado.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            else
                comparadorVenda.Coluna = e.Column;

            lstVendas.Sort();
        }

        /// <summary>
        /// Compara os itens da ListView.
        /// </summary>
        private class ComparadorListViewConsignado : IComparer
        {
            public int Coluna = 0;

            public int Compare(object x, object y)
            {
                ListViewItem a, b;

                a = (ListViewItem)x;
                b = (ListViewItem)y;

                switch (Coluna)
                {
                    case 0:
                        return a.Text.CompareTo(b.Text);

                    case 1:
                        return int.Parse(a.SubItems[1].Text).CompareTo(int.Parse(b.SubItems[1].Text));

                    case 2:
                        DateTime d1, d2;

                        if (!DateTime.TryParse(a.SubItems[2].Text, out d1))
                            return a.Text.CompareTo(b.Text);

                        if (!DateTime.TryParse(b.SubItems[2].Text, out d2))
                            return a.Text.CompareTo(b.Text);

                        return DateTime.Compare(d1, d2);

                    default:
                        throw new NotSupportedException();
                }
            }
        }
        /// <summary>
        /// Compara os itens da ListView.
        /// </summary>
        private class ComparadorListViewVenda : IComparer
        {
            public int Coluna = 0;

            public int Compare(object x, object y)
            {
                ListViewItem a, b;

                a = (ListViewItem)x;
                b = (ListViewItem)y;

                switch (Coluna)
                {
                    case 0:
                        return Int32.Parse(a.Text).CompareTo(Int32.Parse(b.Text));

                    case 1:
                        return int.Parse(a.SubItems[1].Text).CompareTo(int.Parse(b.SubItems[1].Text));

                    case 2:
                        return Int32.Parse(a.SubItems[2].Text).CompareTo(Int32.Parse(b.SubItems[2].Text));

                    case 3:
                        DateTime d1, d2;

                        if (!DateTime.TryParse(a.SubItems[3].Text, out d1))
                            return a.Text.CompareTo(b.Text);

                        if (!DateTime.TryParse(b.SubItems[3].Text, out d2))
                            return a.Text.CompareTo(b.Text);

                        return DateTime.Compare(d1, d2);

                    default:
                        throw new NotSupportedException();
                }
            }
        }

        private void txtMercadoria_Refer�nciaConfirmada(object sender, EventArgs e)
        {
            Rastrear();
        }

        private void Rastrear()
        {
            bgRastrear.RunWorkerAsync();
            txtMercadoria.Enabled = false;

            pic�cone.Image = Resource.elegant;

            Sinaliza��oCarga.Sinalizar(lstConsignado, "Rastreando...", "Aguarde enquando a mercadoria � rastreada.");
        }

        private void bgRastrear_DoWork(object sender, DoWorkEventArgs e)
        {
            ResultadoRastros resultado = new ResultadoRastros();

            resultado.RastroVenda = txtMercadoria.Mercadoria.RastrearVenda();
            resultado.RastroConsignado = txtMercadoria.Mercadoria.RastrearConsignado();

            e.Result = resultado;
        }

        private void bgRastrear_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResultadoRastros resultado = (ResultadoRastros) e.Result;

            lstConsignado.Items.Clear();

            foreach (Entidades.Mercadoria.Mercadoria.RastroConsignado rastro in resultado.RastroConsignado)
            {
                ListViewItem item = new ListViewItem(
                    new string[] {
                        rastro.Pessoa.Nome,
                        rastro.Quantidade.ToString(),
                        rastro.Devolu��o.HasValue ? rastro.Devolu��o.Value.ToString("dd/MM/yyyy") : "" });

                lstConsignado.Items.Add(item);
            }

            lstConsignado.Sort();

            DbFoto foto = CacheMiniaturas.Inst�ncia.Obter(txtMercadoria.Mercadoria);
            
            if (foto != null)
                pic�cone.Image = foto.Imagem;

            lstVendas.Items.Clear();

            foreach (Entidades.Mercadoria.Mercadoria.RastroVenda rastro in resultado.RastroVenda)
            {
                ListViewItem item = new ListViewItem(
                    new string[] {
                        rastro.C�digo.ToString(),
                        rastro.Pessoa.Nome,
                        rastro.Quantidade.ToString(),
                        rastro.Data.Value.ToShortDateString()
                    });

                lstVendas.Items.Add(item);
            }

            lstVendas.Sort();

            Sinaliza��oCarga.Dessinalizar(lstConsignado);

            txtMercadoria.Enabled = true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }

    public class ResultadoRastros
    {
        public List<Entidades.Mercadoria.Mercadoria.RastroVenda> RastroVenda { get; set; }
        public List<Entidades.Mercadoria.Mercadoria.RastroConsignado> RastroConsignado { get; set; }
    }
}
