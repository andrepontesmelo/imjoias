using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Configuração;
using Apresentação.Formulários;
using System.Threading;
using Entidades.Acerto;
using System.Collections;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Mostra horário marcado de acertos para uma data específica.
    /// </summary>
    public partial class ListaAcertoHorário : UserControl
    {
        private DateTime data = DateTime.Now.Date;

        [Browsable(false), ReadOnly(true)]
        public DateTime Data { get { return data; } set { data = value; if (carregado) Carregar(); } }

        public bool Clicável { get { return clicável; } set { clicável = value; } }

        private bool carregado = false;
        private bool clicável = true;

        public delegate void AcertoHandler(AcertoConsignado acerto);
        public event AcertoHandler AoClicarAcerto;

        public ListaAcertoHorário()
        {
            InitializeComponent();
        }

        private void ListaAcertoHorário_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                Carregar();
        }

        private void Carregar()
        {
            carregado = true;

            if (bgCarga.IsBusy)
                return;

            SinalizaçãoCarga.Sinalizar(this, "Carregando...", "Aguarde enquanto o horário é carregado.");
            bgCarga.RunWorkerAsync();
        }

        private void bgCarga_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Entidades.Acerto.AcertoConsignado.ObterAcertosPendentes(data);
        }

        private void bgCarga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FlowLayoutPanel[] flows = new FlowLayoutPanel[] {
                flow07, flow08, flow09, flow10, flow11, flow12, flow13, flow14, flow15,
                flow16, flow17 };

            foreach (FlowLayoutPanel flow in flows)
                flow.Controls.Clear();

            foreach (AcertoConsignado acerto in (IEnumerable)e.Result)
            {
                int i;

                i = Math.Max(0, Math.Min(flows.Length - 1, acerto.Previsão.Value.Hour - 7));

                if (flows[i].Controls.Count > 0 ||
                    acerto.Previsão.Value.Hour - 7 != i ||
                    acerto.Previsão.Value.Minute != 0)
                {
                    Label lbl = new Label();
                    lbl.Text = string.Format("({0:HH:mm})", acerto.Previsão.Value);
                    lbl.ForeColor = SystemColors.GrayText;
                    flows[i].Controls.Add(lbl);
                }

                if (clicável)
                {
                    LinkLabel lnk;
                    lnk = new LinkLabel();
                    lnk.Text = acerto.Cliente.Nome;
                    lnk.Tag = acerto;
                    lnk.Click += new EventHandler(lnk_Click);
                    flows[i].Controls.Add(lnk);
                }
                else
                {
                    Label lbl;
                    lbl = new Label();
                    lbl.Text = acerto.Cliente.Nome;
                    flows[i].Controls.Add(lbl);
                }
            }

            SinalizaçãoCarga.Dessinalizar(this);
        }

        void lnk_Click(object sender, EventArgs e)
        {
            AoClicarAcerto((AcertoConsignado)((LinkLabel)sender).Tag);
        }
    }
}
