using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Atendimento.Clientes
{
    public partial class ListViewVisitantes : UserControl
    {
        public delegate void VisitaCallback(Visita visita);

        public event VisitaCallback AoMudarSeleção;
        public event VisitaCallback AoDuploClique;

        private Dictionary<DateTime, ListViewItem> hashVisitaLinha = new Dictionary<DateTime, ListViewItem>();
        private Dictionary<ListViewItem, Visita> hashLinhaVisita = new Dictionary<ListViewItem, Visita>();

        public ListViewVisitantes()
        {
            InitializeComponent();
        }

        public Visita VisitaSelecionada
        {
            get
            {
                if (lstVisitantes.SelectedItems.Count != 1)
                    return null;

                return hashLinhaVisita[lstVisitantes.SelectedItems[0]];
            }
        }

        public void Limpar()
        {
            hashLinhaVisita.Clear();
            hashVisitaLinha.Clear();
            lstVisitantes.Items.Clear();
        }

        public void AdicionarVisitas(List<Visita> visitas)
        {
            ListViewItem[] itens = new ListViewItem[visitas.Count];
            int x = 0;

            foreach (Visita visita in visitas)
            {
                itens[x] = CriarItem(visita);
                x++;
            }

            lstVisitantes.Items.AddRange(itens);

            colVisitante.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colAtendente.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colEntrada.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colSaída.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private ListViewItem CriarItem(Visita visita)
        {
            ListViewItem item = new ListViewItem(visita.ExtrairNomes());

            item.SubItems.Add(visita.Setor != null ? visita.Setor.Nome : "");

            AtribuirEspera(visita, item);
            AtribuirDataEntrada(visita, item);
            AtribuirSaída(visita, item);
            AdicionarHashes(visita, item);

            return item;
        }

        private void AtribuirEspera(Visita visita, ListViewItem item)
        {
            if (visita.Espera.HasValue)
            {
                item.SubItems.Add(visita.Atendente.Nome);
                item.Group = lstVisitantes.Groups["lstGrpAtendimento"];
            }
            else
            {
                item.SubItems.Add("");
                item.Group = lstVisitantes.Groups["lstGrpAguardando"];
            }
        }

        private void AdicionarHashes(Visita visita, ListViewItem item)
        {
            hashLinhaVisita[item] = visita;
            hashVisitaLinha[visita.Entrada] = item;
        }

        private void AtribuirSaída(Visita visita, ListViewItem item)
        {
            if (visita.Saída.HasValue)
            {
                item.SubItems.Add(visita.Saída.Value.ToLongTimeString());

                if (visita.Entrada.Date == DateTime.Now.Date)
                    item.Group = lstVisitantes.Groups["lstGrpPassado"];
                else
                {
                    string grpChave = "lstGrpPassado" + visita.Entrada.Date.ToShortDateString();

                    if (lstVisitantes.Groups[grpChave] == null)
                        lstVisitantes.Groups.Add(
                            grpChave,
                            visita.Entrada.Date.ToLongDateString());

                    item.Group = lstVisitantes.Groups[grpChave];
                }
            }
            else
                item.SubItems.Add("");
        }

        private static void AtribuirDataEntrada(Visita visita, ListViewItem item)
        {
            if (!visita.Saída.HasValue && visita.Entrada.Date != DateTime.Now.Date)
            {
                /* Pessoas em atendimento, porém com data diferente
                 * são exibidas com data completa.
                 */
                TimeSpan dif = visita.Entrada.Date - DateTime.Now.Date;

                if (dif.Days == 1)
                    item.SubItems.Add("Ontem, " + visita.Entrada.ToString("HH:mm"));
                else
                    item.SubItems.Add(visita.Entrada.ToString("dd/MM/yyyy HH:mm"));
            }
            else
                item.SubItems.Add(visita.Entrada.ToLongTimeString());
        }

        public void AdicionarVisita(Visita visita)
        {
            ListViewItem item = CriarItem(visita);

            lstVisitantes.Items.Add(item);
            item.EnsureVisible();
        }

        public void RemoverVisita(Visita visita)
        {
            ListViewItem linha;

            linha = hashVisitaLinha[visita.Entrada];

            if (linha != null)
            {
                hashVisitaLinha.Remove(visita.Entrada);
                hashLinhaVisita.Remove(linha);
                linha.Remove();
            }
        }

        public void AtualizarVisita(Visita visita)
        {
            ListViewItem linha;

            linha = hashVisitaLinha[visita.Entrada];
            hashLinhaVisita[linha] = visita;

            if (linha != null)
            {
                linha.SubItems[colAtendente.Index].Text = visita.Atendente != null ? visita.Atendente.Nome : "";

                if (!visita.Espera.HasValue && !visita.Saída.HasValue)
                    linha.Group = lstVisitantes.Groups["lstGrpAguardando"];

                else if (!visita.Saída.HasValue)
                    linha.Group = lstVisitantes.Groups["lstGrpAtendimento"];
                else
                {
                    linha.Group = lstVisitantes.Groups["lstGrpPassado"];
                    linha.UseItemStyleForSubItems = true;
                    linha.ForeColor = SystemColors.GrayText;
                    linha.SubItems[colSaída.Index].Text = visita.Saída.Value.ToLongTimeString();
                }
            }
        }

        private void lstVisitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AoMudarSeleção != null)
                AoMudarSeleção(VisitaSelecionada);
        }

        private void lstVisitantes_DoubleClick(object sender, EventArgs e)
        {
            Visita visita = VisitaSelecionada;

            if (visita == null || AoDuploClique == null)
                return;

            AoDuploClique(visita);
        }
    }
}
