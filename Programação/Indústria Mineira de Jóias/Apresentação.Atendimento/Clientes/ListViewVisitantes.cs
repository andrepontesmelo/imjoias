using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Apresentação.Atendimento.Clientes
{
    public partial class ListViewVisitantes : UserControl
    {
        public delegate void VisitaCallback(Visita visita);

        /// <summary>
        /// Evento disparado quando usuário seleciona ou
        /// desseleciona uma visita.
        /// </summary>
        public event VisitaCallback AoMudarSeleção;

        private Dictionary<DateTime, ListViewItem> hashVisitaLinha = new Dictionary<DateTime, ListViewItem>();
        private Dictionary<ListViewItem, Visita> hashLinhaVisita = new Dictionary<ListViewItem, Visita>();

        public ListViewVisitantes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Visita selecionada.
        /// </summary>
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

        /// <summary>
        /// Adiciona um vetor de visitas à lista.
        /// </summary>
        /// <param name="visitas">Vetor de visitas.</param>
        public void AdicionarVisitas(Visita[] visitas)
        {
            foreach (Visita visita in visitas)
                AdicionarVisita(visita);
        }

        /// <summary>
        /// Trata evento de visitante que entrou na empresa
        /// </summary>
        public void AdicionarVisita(Visita visita)
        {
            ListViewItem item = new ListViewItem(Visita.ExtrairNomes(visita));

            item.SubItems.Add(visita.Setor != null ? visita.Setor.Nome : "");

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

            // Atribuir data de entrada
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

            // Atribuir saída
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

            lstVisitantes.Items.Add(item);

            // Adicionar na hashtable de linhas
            hashLinhaVisita[item] = visita;
            hashVisitaLinha[visita.Entrada] = item;

            // Garantir visibilidade
            item.EnsureVisible();
        }

        /// <summary>
        /// Remove visitante
        /// </summary>
        public void RemoverVisita(Visita visita)
        {
            ListViewItem linha;

            // Encontrar linha da listview
            linha = hashVisitaLinha[visita.Entrada];

            if (linha != null)
            {
                hashVisitaLinha.Remove(visita.Entrada);
                hashLinhaVisita.Remove(linha);

                // Verificar se existe outras linhas para esta visita
                linha.Remove();
            }
        }

        /// <summary>
        /// Atualiza o estado do visitante na lista de visitantes
        /// </summary>
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

        /// <summary>
        /// Ocorre quando usuário muda a seleção.
        /// </summary>
        private void lstVisitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AoMudarSeleção != null)
                AoMudarSeleção(VisitaSelecionada);
        }
    }
}
