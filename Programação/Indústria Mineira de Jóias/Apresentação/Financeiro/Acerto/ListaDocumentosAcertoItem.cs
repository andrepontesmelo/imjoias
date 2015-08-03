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

        public void AoExibir(BaseInferior baseInferior)
        {
            flowLayoutPanel.SuspendLayout();
            flowLayoutPanel.Controls.Clear();

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        private void Adicionar(VendaAcerto venda)
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
            flowLayoutPanel.Controls.Add(lnk);
        }

        private void Adicionar(Relacionamento relacionamento)
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
            flowLayoutPanel.Controls.Add(lnk);
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
                    foreach (Relacionamento saída in saídas)
                        Adicionar(saída);
                    break;

                case Tipo.Retorno:
                    foreach (Relacionamento retorno in retornos)
                        Adicionar(retorno);
                    break;

                case Tipo.Venda:
                    foreach (VendaAcerto venda in vendas)
                        Adicionar(venda);
                    break;
            }

            Visible = flowLayoutPanel.Controls.Count > 0;
            flowLayoutPanel.ResumeLayout();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (tipo)
            {
                case Tipo.Saída:
                    saídas = acerto.Saídas;
                    break;

                case Tipo.Retorno:
                    retornos = acerto.Retornos;
                    break;

                case Tipo.Venda:
                    vendas = VendaAcerto.ObterVendas(acerto);
                    break;
            }
        }
    }
}
