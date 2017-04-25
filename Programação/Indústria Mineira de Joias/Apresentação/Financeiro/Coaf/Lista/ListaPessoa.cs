using Apresentação.Formulários;
using Entidades.Coaf;
using Entidades.Configuração;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Coaf.Inconsistência;

namespace Apresentação.Financeiro.Coaf.Lista
{
    public partial class ListaPessoa : UserControl
    {
        public event EventHandler DuploClique;
        public event EventHandler SeleçãoAlterada;

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

        public string ObterCpfCnpjPessoaSelecionada()
        {
            if (lista.SelectedItems.Count == 0)
                return null;

            return (lista.SelectedItems[0].Tag as PessoaResumo).CpfCnpj;
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DuploClique?.Invoke(sender, e);
        }

        public void Carregar()
        {
            var entidades = ObterEntidades();
            var inconsistências = Entidades.Coaf.Inconsistência.InconsistênciaPessoa.ObterInconsistências();
            List<ListViewItem> itens = CriarItens(entidades, inconsistências);

            lista.Items.Clear();
            lista.Items.AddRange(itens.ToArray());
            colPendências.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private List<ListViewItem> CriarItens(List<PessoaResumo> entidades, Dictionary<uint, InconsistênciaPessoa> inconsistências)
        {
            List<ListViewItem> resultado = new List<ListViewItem>();

            var random = new Random((int)DateTime.Now.Ticks);
            foreach (PessoaResumo entidade in entidades)
            {
                if (!entidade.Verificável)
                    continue;

                ListViewItem item = new ListViewItem(ObterGrupo(entidade));
                item.SubItems.AddRange(new string[] { "", "", "", "", "" });
                item.SubItems[colCPFCNPJ.Index].Text = FormatarCpfCnpj(entidade.CpfCnpj);
                item.SubItems[colCódigo.Index].Text = entidade.Código.Equals(0) ? "" : entidade.Código.ToString();
                item.SubItems[colPessoa.Index].Text = entidade.Código.Equals(0) ? "<Sem Cadastro>" : entidade.Nome;
                item.SubItems[colValorAcumulado.Index].Text = entidade.ValorAcumulado.ToString("C");
                item.SubItems[colPendências.Index].Text = ConcatenarInconsistências(inconsistências, entidade.Código);
                item.Tag = entidade;

                if (entidade.PoliticamenteExposta)
                    item.SubItems[colPEP.Index].Text = HashPessoaExpostaPoliticamente.Hash[entidade.CpfResponsável].Descrição;

                resultado.Add(item);

            }

            return resultado;
            }

        private string ConcatenarInconsistências(Dictionary<uint, InconsistênciaPessoa> inconsistências, uint código)
        {
            InconsistênciaPessoa inconsistênciaPessoa;
            if (inconsistências.TryGetValue(código, out inconsistênciaPessoa))
            {
                return inconsistênciaPessoa.Concatenar();
            }

            return "";
        }

        private ListViewGroup ObterGrupo(PessoaResumo entidade)
        {
            return entidade.Notificável ? lista.Groups["grupoNotificáveis"] : lista.Groups["grupoNãoNotificáveis"];
        }

        private string FormatarCpfCnpj(string cpfCnpj)
        {
            return PessoaCPFCNPJRG.FormatarCpfCnpj(cpfCnpj);
        }

        private List<PessoaResumo> ObterEntidades()
        {
            var resultado = PessoaResumo.Obter(ConfiguraçõesCoaf.Instância.DataInício, 
                ConfiguraçõesCoaf.Instância.DataFim,
                ConfiguraçõesCoaf.Instância.ValorMínimoLimiar);

            return FiltrarResumosSemPessoaSemDocumento(resultado);
        }

        private List<PessoaResumo> FiltrarResumosSemPessoaSemDocumento(List<PessoaResumo> resumos)
        {
            var resultado = new List<PessoaResumo>();

            foreach (PessoaResumo resumo in resumos)
            {
                if (!resumo.Código.Equals(0) || !String.IsNullOrWhiteSpace(resumo.CpfCnpj))
                    resultado.Add(resumo);
            }
            
            return resultado;
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleçãoAlterada?.Invoke(sender, e);
        }
    }
}
