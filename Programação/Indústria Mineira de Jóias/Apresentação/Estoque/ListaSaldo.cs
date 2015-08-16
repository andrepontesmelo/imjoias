﻿using System;
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
        private ListViewColumnSorter lvwColumnSorter;

        private volatile List<Entidades.Estoque.Saldo> itens;
        private volatile Entidades.Fornecedor[] arrayFornecedores;

        private Entidades.Configuração.ConfiguraçãoUsuário<bool> localizadorAberto;
        private Entidades.Configuração.ConfiguraçãoUsuário<int> filtrarFornecedor;

        struct ResultadoCarga
        {
            public ListViewItem[] ListaGrafica;
            public double TotalSaldoPeso;
            public int TotalReferencias;
        }


        public ListaSaldo()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            this.lst.ListViewItemSorter = lvwColumnSorter;
            localizador.Visible = true;

            localizadorAberto = new Entidades.Configuração.ConfiguraçãoUsuário<bool>("ListaSaldo.localizador.aberto", false);
            filtrarFornecedor = new Entidades.Configuração.ConfiguraçãoUsuário<int>("ListaSaldo.toolStrip.filtrarFornecedor", 0);

            AtualizarEnabledComboboxFornecedor();

            CarregarPersistênciaFiltroFornecedor();

            localizador.Visible = localizadorAberto.Valor;

            if (!localizadorAberto.Valor)
                lst.Height += localizador.Height;
        }

        private void CarregarPersistênciaFiltroFornecedor()
        {
            if (filtrarFornecedor.Valor > 0)
            {
                Entidades.Fornecedor fornecedorSelecionado = Entidades.Fornecedor.ObterFornecedor(filtrarFornecedor.Valor);

                toolStripComboBoxFornecedor.Items.Add(fornecedorSelecionado);
                toolStripComboBoxFornecedor.SelectedItem = fornecedorSelecionado;
            }
            else
            {
                toolStripBtnFiltrarFornecedor.Checked = false;
                toolStripComboBoxFornecedor.Enabled = false;
            }
        }

        public void Carregar()
        {
            if (!bg.IsBusy)
            {
                AguardeDB.Mostrar();
                bg.RunWorkerAsync();
            }
        }

        private delegate Entidades.Fornecedor ObterFornecedorÚnicoCallback();

        private Entidades.Fornecedor ObterFornecedorÚnico()
        {
            if (toolStrip.InvokeRequired)
            {
                ObterFornecedorÚnicoCallback método = new ObterFornecedorÚnicoCallback(ObterFornecedorÚnico);
                return (Entidades.Fornecedor) toolStrip.Invoke(método, new object[] { });
            }
            else
            {
                if (!toolStripBtnFiltrarFornecedor.Checked)
                    return null;

                return toolStripComboBoxFornecedor.SelectedItem as Entidades.Fornecedor;
            }
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            arrayFornecedores = Entidades.Fornecedor.ObterFornecedores().ToArray();
            
            itens = Entidades.Estoque.Saldo.Obter(true, true, ObterFornecedorÚnico(), Saldo.Ordem.ReferênciaPeso);
            ResultadoCarga resultado = new ResultadoCarga();

            resultado.ListaGrafica = new ListViewItem[itens.Count];

            int x = 0;

            foreach (Saldo s in itens)
            {
                ListViewItem i = CriarItem(s);

                resultado.ListaGrafica[x++] = i;
                resultado.TotalSaldoPeso += s.Peso * s.SaldoValor;
                localizador.InserirListViewItem(i);
            }

            resultado.TotalReferencias = itens.Count;
            resultado.TotalSaldoPeso = Math.Round(resultado.TotalSaldoPeso, 2);
            e.Result = resultado;
        }

        private ListViewItem CriarItem(Saldo s)
        {
            ListViewGroup grupoDePeso = lst.Groups[0];
            ListViewGroup grupoDeReferencia = lst.Groups[1];

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
            return i;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResultadoCarga resultado = (ResultadoCarga)e.Result;

            lst.SuspendLayout();
            lst.Items.Clear();

            lst.Items.AddRange(resultado.ListaGrafica);

            toolStripComboBoxFornecedor.Items.Clear();
            toolStripComboBoxFornecedor.Items.AddRange(arrayFornecedores);

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

        private void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvwColumnSorter.OnClick((ListView)sender, e);
        }

        public List<Saldo> Itens { get { return itens; } }

        private void localizador_DesrealçarTudo(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lst.Items)
                i.BackColor = Color.White;
        }

        private void localizador_EncontrarItem(object item, object últimoEncontrado)
        {
            ListViewItem i = (ListViewItem)item;
            ListViewItem iAnterior = últimoEncontrado as ListViewItem;

            if (iAnterior != null)
                iAnterior.Selected = false;

            i.Selected = true;
            i.EnsureVisible();
        }

        private void localizador_RealçarItens(System.Collections.ArrayList itens)
        {
            foreach (ListViewItem i in itens)
            {
                i.BackColor = Color.Yellow;
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (!localizador.Visible)
            {
                localizador.Visible = true;
                lst.Height -= localizador.Height;

                localizadorAberto.Valor = true;
            }
        }

        private void localizador_AoFechar(object sender, EventArgs e)
        {
            localizadorAberto.Valor = false;
            lst.Height += localizador.Height;
        }

        private void toolStripBtnFiltrarFornecedor_Click(object sender, EventArgs e)
        {
            if (toolStripBtnFiltrarFornecedor.Checked)
                filtrarFornecedor.Valor = 0;

            AtualizarEnabledComboboxFornecedor();

            Carregar();
        }

        private void toolStripComboboxFornecedorSelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarFornecedor.Valor = (int) ObterFornecedorÚnico().Código;

            Carregar();
        }

        private void AtualizarEnabledComboboxFornecedor()
        {
            toolStripBtnFiltrarFornecedor.Checked = !toolStripBtnFiltrarFornecedor.Checked;
            toolStripComboBoxFornecedor.Enabled = toolStripBtnFiltrarFornecedor.Checked;
        }
    }
}
