using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.ComissãoCálculo;
using System.Globalization;
using Apresentação.Atendimento.Comum;
using Apresentação.Formulários;
using Apresentação.Financeiro.Comissões.Delegate;
using System.Diagnostics;

namespace Apresentação.Financeiro.Comissões
{
    public partial class ListaVendaComissão : UserControl
    {
        CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

        public event VendaDelegate AoSolicitarAbrirVenda;
        public event PessoaDelegate AoSolicitarAbrirAtendimentoPessoa;
        public event EventHandler AoDuploClique;

        private Dictionary<EnumRegra, ListViewGroup> hashRegraGrupo;

        private DateTime? diaInicial;
        private DateTime? diaFinal;
        private Entidades.Pessoa.Pessoa comissãoPara;
        private Comissão comissão;
        private bool estorno;
        
        [Browsable(true)]
        public Color CorFundo
        {
            get { return lst.BackColor; }
            set { lst.BackColor = value; }
        }

        private Apresentação.Formulários.ListViewColumnSorter ordenador;

        /// <summary>
        /// em aberto são as comissões da parte esquerda da tela.
        /// Em fechado são as comissões da parte direita da tela.
        /// </summary>
        private bool emAberto;

        public ListaVendaComissão()
        {
            InitializeComponent();

            lst.Columns.Clear();
            lst.Columns.Add(colCódigoVenda);
            lst.Columns.Add(colData);
            lst.Columns.Add(colVendedor);
            lst.Columns.Add(colCliente);
            lst.Columns.Add(colComissaoPara);
            lst.Columns.Add(colSetor);
            lst.Columns.Add(colValorVenda);
            lst.Columns.Add(colValorComissão);

            EnumRegra[] tipos = (EnumRegra[]) Enum.GetValues(typeof(EnumRegra));
            hashRegraGrupo = new Dictionary<EnumRegra, ListViewGroup>(tipos.Length);

            lock (hashRegraGrupo)
            {
                foreach (EnumRegra tipo in tipos)
                {
                    ListViewGroup grupo = new ListViewGroup(tipo.ToString());
                    lst.Groups.Add(grupo);
                    hashRegraGrupo[tipo] = grupo;
                }
            }

            ordenador = new ListViewColumnSorter();
            lst.ListViewItemSorter = ordenador;
        }

        public void Carregar(DateTime? diaInicial, DateTime? diaFinal, Entidades.Pessoa.Pessoa comissãoPara, Comissão comissão, bool emAberto, bool estorno)
        {
            if (bg.IsBusy)
                return;

            AguardeDB.Mostrar();
            UseWaitCursor = true;

            this.diaInicial = diaInicial;
            this.diaFinal = diaFinal;
            this.comissãoPara = comissãoPara;
            this.comissão = comissão;
            this.emAberto = emAberto;
            this.estorno = estorno;

            lst.Items.Clear();
            bg.RunWorkerAsync();
        }

        private void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lst, e);
        }

        private void abrirFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0 || AoSolicitarAbrirAtendimentoPessoa == null)
                return;

            ComissãoValor cv = (ComissãoValor)lst.SelectedItems[0].Tag;
            AoSolicitarAbrirAtendimentoPessoa(Entidades.Pessoa.Pessoa.ObterPessoa(cv.ClienteCódigo)); 
        }

        private void lst_MouseClick(object sender, MouseEventArgs e)
        {
           if (e.Button == System.Windows.Forms.MouseButtons.Right && lst.SelectedItems.Count > 0)
           {
               ComissãoValor cv = (ComissãoValor)lst.SelectedItems[0].Tag;

               abrirClienteToolStripMenuItem.Text = "Abrir " +
                   lst.SelectedItems[0].SubItems[colCliente.Index].Text;
               abrirClienteToolStripMenuItem.Image = ControladorÍconePessoa.ObterÍcone(Entidades.Pessoa.Pessoa.ObterPessoa(cv.ClienteCódigo));

               abrirVendedorToolStripMenuItem.Image = ControladorÍconePessoa.ObterÍcone(cv.Vendedor);
               abrirVendedorToolStripMenuItem.Text = "Abrir " +
                   lst.SelectedItems[0].SubItems
                   [colVendedor.Index].Text;

               abrirComissãoParaToolStripMenuItem.Text = "Abrir " +
                   lst.SelectedItems[0].SubItems[colComissaoPara.Index].Text;
               abrirComissãoParaToolStripMenuItem.Image = ControladorÍconePessoa.ObterÍcone(cv.ComissãoPara);

               if (abrirVendedorToolStripMenuItem.Text.CompareTo(abrirComissãoParaToolStripMenuItem.Text) == 0)
                   abrirComissãoParaToolStripMenuItem.Visible = false;

               contextMenuStrip1.Show(lst, e.X, e.Y);
           }
        }

        private void abrirVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0 || AoSolicitarAbrirVenda == null)
                return;

            ComissãoValor cv = (ComissãoValor) lst.SelectedItems[0].Tag;


            long códigoVenda = (long)cv.Venda;
            Entidades.Relacionamento.Venda.Venda v = Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda);

            AoSolicitarAbrirVenda(v);
        }

        private void abrirVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0 || AoSolicitarAbrirAtendimentoPessoa == null)
                return;

            ComissãoValor cv = (ComissãoValor)lst.SelectedItems[0].Tag;
            AoSolicitarAbrirAtendimentoPessoa(cv.Vendedor); 
        }

        private void abrirComissãoParaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count == 0 || AoSolicitarAbrirAtendimentoPessoa == null)
                return;

            ComissãoValor cv = (ComissãoValor)lst.SelectedItems[0].Tag;
            AoSolicitarAbrirAtendimentoPessoa(cv.ComissãoPara); 
        }



        [DebuggerNonUserCode]
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ComissãoValor> lstComissões = ComissãoValor.Obter(diaInicial, diaFinal, comissãoPara, comissão, emAberto, estorno);
            e.Result = lstComissões;
        }

        [DebuggerNonUserCode]
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<ComissãoValor> lstComissões = (List<ComissãoValor>) e.Result;

            decimal totalVenda = 0;
            decimal totalComissão = 0;
            
            lst.Items.Clear();
            foreach (ComissãoValor cv in lstComissões)
            {
                totalVenda += (decimal) cv.ValorVenda;
                totalComissão += (decimal) cv.ValorComissão;

                if (hashRegraGrupo != null)
                {
                    lock (hashRegraGrupo)
                    {
                        ListViewItem i = new ListViewItem(hashRegraGrupo[cv.Regra]);
                        i.Text = Entidades.Relacionamento.Venda.Venda.FormatarCódigo(cv.Venda);

                        string data = cv.Data.ToShortDateString();
                        string nomeVendedor = Entidades.Pessoa.Pessoa.ReduzirNome(cv.Vendedor.Nome);
                        string nomeCliente = cv.ClienteNome;
                        string nomeComissãoPara = Entidades.Pessoa.Pessoa.ReduzirNome(cv.ComissãoPara.Nome);
                        string nomeSetor = cv.Setor.Nome;
                        string valorVenda = cv.ValorVenda.ToString("C", cultura);
                        string valorComissão = cv.ValorComissão.ToString("C", cultura);

                        string[] dados = new string[7] { data,
                        nomeVendedor,
                        nomeCliente,
                        nomeComissãoPara,
                        nomeSetor,
                        valorVenda,
                        valorComissão
                        };

                        i.SubItems.AddRange(dados);

                        i.Tag = cv;
                        lst.Items.Add(i);
                    }
                }
            }

            colCliente.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colCódigoVenda.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colComissaoPara.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colData.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colValorVenda.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colValorComissão.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colSetor.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            panelComissãoTotal.Text = "Comissão: " + totalComissão.ToString("C", cultura);
            panelComissãoTotal.AutoSize = StatusBarPanelAutoSize.Contents;

            panelVendaTotal.Text = "Venda: " + totalVenda.ToString("C", cultura);
            panelVendaTotal.AutoSize = StatusBarPanelAutoSize.Contents;

            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        public List<ComissãoValor> Selecionados
        {
            get
            {
                List<ComissãoValor> retorno = new List<ComissãoValor>();
                foreach (ListViewItem item in lst.SelectedItems)
                    retorno.Add((ComissãoValor)item.Tag);
                return retorno;
            }
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelecionarTudo();
        }

        private void inverterSeleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lst.Items)
                i.Selected = !i.Selected;
        }

        private void SelecionarTudo()
        {
            foreach (ListViewItem i in lst.Items)
                i.Selected = true;
        }

        private void lst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
                SelecionarTudo();
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lst_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && AoDuploClique != null)
                AoDuploClique(sender, e);
        }
   
    }
}
