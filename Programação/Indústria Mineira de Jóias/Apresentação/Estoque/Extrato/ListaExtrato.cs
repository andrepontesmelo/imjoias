using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Estoque;
using Apresentação.Financeiro;
using Apresentação.Formulários;
using ListViewSorter;

namespace Apresentação.Estoque.Extrato
{
    public partial class ListaExtrato : UserControl
    {
        private ListViewColumnSorter lvwColumnSorter;

        public delegate void QuerAbrirDocumentoDelegate(Entidades.Relacionamento.Relacionamento relacionamento);
        public event QuerAbrirDocumentoDelegate QuerAbrirDocumento;

        public ListaExtrato()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            this.lst.ListViewItemSorter = lvwColumnSorter;
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            Saldo s = (Saldo)e.Argument;
            double? peso = s.Peso;
            
            if (!s.Depeso)
                peso = null;

            List<Entidades.Estoque.Extrato> lstEntidades = Entidades.Estoque.Extrato.Obter(s.Referencia, peso);
            Entidades.Estoque.Extrato.ComputarSaldo(lstEntidades);
            e.Result = lstEntidades;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Entidades.Estoque.Extrato> lstExtrato = (List<Entidades.Estoque.Extrato>) e.Result;
            lst.SuspendLayout();
            lst.Items.Clear();
            foreach (Entidades.Estoque.Extrato extrato in lstExtrato)
            {
                ListViewItem i = new ListViewItem(extrato.Data.ToShortDateString() + " " + extrato.Data.ToLongTimeString());
                i.SubItems.Add(Entidades.Pessoa.Pessoa.ReduzirNome(extrato.Nome));
                i.SubItems.Add(extrato.Entrada.ToString());
                i.SubItems.Add(extrato.Venda.ToString());
                i.SubItems.Add(extrato.Devolucao.ToString());
                i.SubItems.Add(extrato.Saldo.ToString());
                i.SubItems.Add(extrato.Operacao);
                i.Tag = extrato;
                lst.Items.Add(i);
            }
            lst.ResumeLayout();
        }

        internal void Carregar(Entidades.Estoque.Saldo s)
        {
            bg.RunWorkerAsync(s);
        }

        public Entidades.Estoque.Extrato Seleção
        {
            get
            {
                if (lst.SelectedItems.Count == 0)
                    return null;
                return lst.SelectedItems[0].Tag as Entidades.Estoque.Extrato;
            }
        }
        
        private void lst_DoubleClick(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            UseWaitCursor = true;
            Entidades.Estoque.Extrato entidade = Seleção;
            string[] dividido = entidade.Operacao.Split(' ');
            string tipoDocumento = dividido[0];
            ulong códigoDocumento = ulong.Parse(dividido[1]);

            Entidades.Relacionamento.Relacionamento relacionamento;

            switch (tipoDocumento)
            {
                case "Devolução":
                case "Venda":
                    relacionamento = Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoDocumento);
                    QuerAbrirDocumento(relacionamento);
                    break;
                case "Entrada":
                    relacionamento = Entidades.Estoque.Entrada.Obter(códigoDocumento);
                    QuerAbrirDocumento(relacionamento);
                    break;

                default:
                    throw new NotImplementedException();
            }

            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvwColumnSorter.OnClick((ListView)sender, e);
        }
    }
}

