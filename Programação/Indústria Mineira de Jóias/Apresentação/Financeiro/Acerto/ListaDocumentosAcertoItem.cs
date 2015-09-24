using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Acerto;
using Entidades.Relacionamento;
using Acesso.Comum;

namespace Apresentação.Financeiro.Acerto
{
    public partial class ListaDocumentosAcertoItem : QuadroSimples, IAoMostrarBaseInferior
    {
        public enum Tipo { Saída, Retorno, Venda }

        private Tipo tipo;
        private AcertoConsignado acerto;

        public delegate void ClickDelegate(Relacionamento relacionamento);
        public event ClickDelegate AoClicar;

        public ListaDocumentosAcertoItem()
        {
            InitializeComponent();
        }

        public Tipo TipoDocumento
        {
            get { return tipo; }
            set
            {
                tipo = value;
                label1.Text = tipo.ToString() + "s";
            }
        }

        public AcertoConsignado AcertoConsignado
        {
            get { return acerto; }
            set { acerto = value; flowLayoutPanel.Controls.Clear();  }
        }

        public void AoExibirDaPrimeiraVez(BaseInferior baseInferior)
        {
        }

        private DbComposição<Entidades.Relacionamento.Saída.Saída> saídas;
        private DbComposição<Entidades.Relacionamento.Retorno.Retorno> retornos;
        private List<VendaAcerto> vendas;

        private Control[] gráficosSaídas;
        private Control[] gráficosRetornos;
        private Control[] gráficosVendas;

        public void AoExibir(BaseInferior baseInferior)
        {
            Recarregar(acerto);
        }

        public void Recarregar(AcertoConsignado acerto)
        {
            this.acerto = acerto;

            if (!bg.IsBusy)
            {

                flowLayoutPanel.SuspendLayout();
                flowLayoutPanel.Controls.Clear();

                bg.RunWorkerAsync();
            }
        }

        private Control Construir(VendaAcerto venda)
        {
            LinkLabel lnk = new LinkLabel();
            lnk.Text = string.Format(
                "{0} {1}, {2:D} às {2:HH:mm}",
                Tipo.Venda.ToString(),
                venda.Código,
                venda.Data);
            lnk.LinkBehavior = LinkBehavior.HoverUnderline;
            lnk.LinkColor = Color.Black;
            lnk.Margin = new Padding(5);
            lnk.Tag = venda;
            lnk.AutoSize = true;
            lnk.Click += new EventHandler(lnk_Click);

            return lnk;
        }

        private Control Construir(Relacionamento relacionamento)
        {
            LinkLabel lnk = new LinkLabel();
            lnk.Text = string.Format(
                "{0} {1}, {2:D} às {2:HH:mm}",
                tipo.ToString(),
                relacionamento.Código,
                relacionamento.Data);
            lnk.LinkBehavior = LinkBehavior.HoverUnderline;
            lnk.LinkColor = Color.Black;
            lnk.Margin = new Padding(5);
            lnk.Tag = relacionamento;
            lnk.AutoSize = true;
            lnk.Click += new EventHandler(lnk_Click);

            return lnk;
        }

        void lnk_Click(object sender, EventArgs e)
        {
            object tag = ((Control)sender).Tag;

            if (tag is Relacionamento)
                AoClicar((Relacionamento) tag);

            if (tag is VendaAcerto)
                AoClicar(Entidades.Relacionamento.Venda.Venda.ObterVenda(((VendaAcerto) tag).Código));
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (tipo)
            {
                case Tipo.Saída:
                    flowLayoutPanel.Controls.AddRange(gráficosSaídas);
                break;

                case Tipo.Retorno:
                    flowLayoutPanel.Controls.AddRange(gráficosRetornos);
                break;

                case Tipo.Venda:
                    flowLayoutPanel.Controls.AddRange(gráficosVendas);
                break;
            }

            Visible = flowLayoutPanel.Controls.Count > 0;
            flowLayoutPanel.ResumeLayout();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;

            switch (tipo)
            {
                case Tipo.Saída:
                    saídas = acerto.Saídas;
                    gráficosSaídas = new Control[saídas.ContarElementos()];

                    foreach (Relacionamento saída in saídas)
                        gráficosSaídas[x++] = Construir(saída);

                    break;

                case Tipo.Retorno:
                    retornos = acerto.Retornos;
                    gráficosRetornos = new Control[retornos.ContarElementos()];

                    foreach (Relacionamento retorno in retornos)
                        gráficosRetornos[x++] = Construir(retorno);
                    break;

                case Tipo.Venda:
                    vendas = VendaAcerto.ObterVendas(acerto);
                    gráficosVendas = new Control[vendas.Count];

                    foreach (VendaAcerto venda in vendas)
                        gráficosVendas[x++] = Construir(venda);

                    break;
            }
        }
    }
}
