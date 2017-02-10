using Apresentação.Formulários;
using Entidades.Coaf;
using Entidades.Configuração;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Coaf.Lista
{
    public partial class ListaPessoa : UserControl
    {
        public event EventHandler DuploClique;
        
        public ListaPessoa()
        {
            InitializeComponent();
            lista.ListViewItemSorter = new ListViewColumnSorter();
            lista.ColumnClick += Lista_ColumnClick;
        }

        private void Lista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnSorter)lista.ListViewItemSorter).OnClick(lista, e);
        }

        public uint? ObterPessoaSelecionada()
        {
            if (lista.SelectedItems.Count == 0)
                return null;

            return (lista.SelectedItems[0].Tag as PessoaResumo).Código;
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }

        public void Carregar()
        {
            var entidades = ObterEntidades();
            List<ListViewItem> itens = CriarItens(entidades);

            lista.Items.Clear();
            lista.Items.AddRange(itens.ToArray());
        }

        private List<ListViewItem> CriarItens(List<PessoaResumo> entidades)
        {
            List<ListViewItem> resultado = new List<ListViewItem>();

            foreach (PessoaResumo entidade in entidades)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.AddRange(new string[] { "", "", "", "", "" });
                item.SubItems[colCPFCNPJ.Index].Text = FormatarCpfCnpj(entidade.CpfCnpj);
                item.SubItems[colCódigo.Index].Text = entidade.Código.ToString();
                item.SubItems[colPessoa.Index].Text = entidade.Nome;
                item.SubItems[colValorAcumulado.Index].Text = entidade.ValorAcumulado.ToString("C");

                if (entidade.Notificável)
                {
                    item.SubItems[colNotificável.Index].Text = "Notificável";
                    item.BackColor = Color.Yellow;
                }
                item.Tag = entidade;

                if (entidade.PoliticamenteExposta)
                    item.SubItems[colPEP.Index].Text = CódigoPep.Hash[entidade.Código].Descrição;

                resultado.Add(item);
            }

            return resultado;
        }

        private string FormatarCpfCnpj(string cpfCnpj)
        {
            return PessoaCPFCNPJRG.FormatarCpfCnpj(cpfCnpj);
        }

        private List<PessoaResumo> ObterEntidades()
        {
            int meses = 6;
            var agora = DadosGlobais.Instância.HoraDataAtual;
            var início = agora.AddMonths(-1 * meses);

            return PessoaResumo.Obter(início);
        }
    }
}
