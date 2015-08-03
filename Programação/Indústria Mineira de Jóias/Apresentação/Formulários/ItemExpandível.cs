using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Item expandível, que pode discriminar diversos subitens.
    /// </summary>
    public partial class ItemExpandível : QuadroSimples
    {
        public struct Item
        {
            private string descrição;
            private string valor;
            private EventHandler aoClicar;
            private object objeto;

            public Item(string descrição, string valor, EventHandler aoClicar, object objeto)
            {
                this.descrição = descrição;
                this.valor = valor;
                this.aoClicar = aoClicar;
                this.objeto = objeto;
            }

            public string Descrição { get { return descrição; } set { descrição = value; } }
            public string Valor { get { return valor; } set { valor = value; } }
            public EventHandler AoClicar { get { return aoClicar; } set { aoClicar = value; } }
            public object Objeto { get { return objeto; } set { objeto = value; } }
        }

        private List<Item> itens = new List<Item>();
        private bool expandido = false;
        private List<Control> controles = new List<Control>();

        public ItemExpandível()
        {
            InitializeComponent();
        }

        public string Descrição
        {
            get { return lblItem.Text; }
            set { lblItem.Text = value; }
        }

        [DefaultValue("Valor")]
        public string Valor
        {
            get { return lblValor.Text; }
            set { lblValor.Text = value; }
        }

        [DefaultValue(true)]
        public bool Expandível { get { return picExpandir.Visible; } set { picExpandir.Visible = value; } }

        public List<Item> Itens { get { return itens; } }

        private void AjustarTamanho(object sender, EventArgs e)
        {
            if (expandido)
                Encolher();
            else
                Expandir();
        }

        private void Encolher()
        {
            SuspendLayout();
            tabela.SuspendLayout();

            foreach (Control controle in controles)
            {
                tabela.Controls.Remove(controle);
                controle.Dispose();
            }

            tabela.RowCount = 1;

            //for (int i = tabela.RowStyles.Count - 1; i > 0; i--)
            //    tabela.RowStyles.RemoveAt(i);

            controles.Clear();
            expandido = false;

            tabela.ResumeLayout();
            ResumeLayout();

            picExpandir.Image = Resource.Expand_large;
        }

        private void Expandir()
        {
            int i = 2;

            foreach (Item item in itens)
            {
                controles.Add(CriarControle(ContentAlignment.TopLeft, item.Descrição ?? "", item.AoClicar, item));
                controles.Add(CriarControle(ContentAlignment.TopRight, item.Valor ?? "", item.AoClicar, item));
            }

            SuspendLayout();
            tabela.SuspendLayout();

            tabela.RowCount += itens.Count;

            foreach (Control controle in controles)
            {
                tabela.Controls.Add(controle);
                tabela.SetRow(controle, i / 2);
                tabela.SetColumn(controle, i % 2);
                i++;
            }

            foreach (RowStyle estilo in tabela.RowStyles)
                estilo.SizeType = SizeType.AutoSize;

            expandido = true;

            tabela.ResumeLayout();
            ResumeLayout();

            picExpandir.Image = Resource.Collapse_large;
        }

        private Control CriarControle(ContentAlignment alinhamento, string texto, EventHandler aoClicar, object objeto)
        {
            Control controle;

            if (aoClicar != null)
            {
                LinkLabel link = new LinkLabel();
                link.Text = texto;
                link.TextAlign = alinhamento;
                link.Click += new EventHandler(LinkClick);
                controle = link;
            }
            else
            {
                Label lbl = new Label();
                lbl.Text = texto;
                lbl.TextAlign = alinhamento;
                controle = lbl;
            }

            controle.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            controle.Tag = objeto;

            return controle;
        }

        void LinkClick(object sender, EventArgs e)
        {
            ((Item)((Control)sender).Tag).AoClicar(((Control)sender).Tag, e);
        }
    }
}
