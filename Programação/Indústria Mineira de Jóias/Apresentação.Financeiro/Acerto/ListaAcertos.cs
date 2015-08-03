using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    public partial class ListaAcertos : UserControl
    {
        private List<AcertoConsignado> acertos;
        private Dictionary<DateTime, ListViewGroup> hashGrupo = new Dictionary<DateTime,ListViewGroup>();

        public event EventHandler AoMudarSeleção;
        public event EventHandler AoClicarDuasVezesItem;

        public ListaAcertos()
        {
            InitializeComponent();
        }

        public AcertoConsignado Seleção
        {
            get
            {
                if (lst.SelectedItems.Count == 1)
                    return (AcertoConsignado)lst.SelectedItems[0].Tag;
                else
                    return null;
            }
        }

        public void MostrarAcertos(AcertoConsignado[] value)
        {
            acertos = new List<AcertoConsignado>(value);
            acertos.Sort(new Comparison<AcertoConsignado>(CompararAcerto));

            lst.Items.Clear();

            foreach (AcertoConsignado acerto in acertos)
                Adicionar(acerto);

            lst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private int CompararAcerto(AcertoConsignado a, AcertoConsignado b)
        {
            if (a.Previsão.HasValue && b.Previsão.HasValue)
                return a.Previsão.Value.CompareTo(b.Previsão.Value);

            else if (a.Previsão.HasValue)
                return 1;

            else if (b.Previsão.HasValue)
                return -1;

            else
                return a.DataMarcação.CompareTo(b.DataMarcação);
        }

        private void Adicionar(AcertoConsignado acerto)
        {
            ListViewItem item = new ListViewItem();

            item.Text = acerto.Código.ToString();
            item.SubItems.Add(acerto.Cliente.Nome);
            item.SubItems.Add(acerto.DataMarcação.ToString("dd/MM/yyyy"));
            item.SubItems.Add(acerto.Previsão.HasValue ? acerto.Previsão.Value.ToString("dd/MM/yyyy") : "Não marcado");
            //item.SubItems.Add(acerto.CalcularValorMercadorias().ToString("C"));
            item.Group = ObterGrupo(acerto);
            item.Tag = acerto;

            lst.Items.Add(item);
        }

        private ListViewGroup ObterGrupo(AcertoConsignado acerto)
        {
            ListViewGroup grupo;

            if (!acerto.Previsão.HasValue)
                return lst.Groups[0];

            else if (!hashGrupo.TryGetValue(acerto.Previsão.Value, out grupo))
            {
                grupo = new ListViewGroup("Acerto para " + acerto.Previsão.Value.ToLongDateString());
                lst.Groups.Add(grupo);
                hashGrupo.Add(acerto.Previsão.Value, grupo);
            }

            return grupo;
        }

        private void ListaAcertos_DoubleClick(object sender, EventArgs e)
        {
            if (Seleção != null)
                AoClicarDuasVezesItem(this, e);
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AoMudarSeleção != null)
                AoMudarSeleção(this, e);
        }
    }
}
