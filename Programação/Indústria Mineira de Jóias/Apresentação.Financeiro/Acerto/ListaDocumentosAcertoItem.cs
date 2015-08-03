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

        public void AoExibir(BaseInferior baseInferior)
        {
            flowLayoutPanel.SuspendLayout();
            flowLayoutPanel.Controls.Clear();

            switch (tipo)
            {
                case Tipo.Saída:
                    foreach (Relacionamento saída in acerto.Saídas)
                        Adicionar(saída);
                    break;

                case Tipo.Retorno:
                    foreach (Relacionamento retorno in acerto.Retornos)
                        Adicionar(retorno);
                    break;

                case Tipo.Venda:
                    foreach (Relacionamento venda in acerto.Vendas)
                        Adicionar(venda);
                    break;
            }

            Visible = flowLayoutPanel.Controls.Count > 0;
            flowLayoutPanel.ResumeLayout();
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
            AoClicar((Relacionamento)((Control)sender).Tag);
        }
    }
}
