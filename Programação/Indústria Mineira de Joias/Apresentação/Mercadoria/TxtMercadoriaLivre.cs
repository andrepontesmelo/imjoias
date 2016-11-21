using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Mercadoria
{
    public partial class TxtMercadoriaLivre : UserControl
    {
        public event EventHandler ReferênciaAlterada;

        public TxtMercadoriaLivre()
        {
            InitializeComponent();
        }

        public TipoMercadoria? ListarApenas = null;

        public string Referência
        {
            get { return txtReferência.Text; }
            set { txtReferência.Text = value; }
        }

        public Entidades.Mercadoria.Mercadoria Mercadoria => Entidades.Mercadoria.Mercadoria.ObterMercadoria(Referência);

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var janela = new Janela.JanelaPesquisaReferência();
            janela.ListarApenas = ListarApenas;
            janela.AoSelecionar += Janela_AoSelecionar; ;
            janela.ShowDialog(this);
        }

        private void Janela_AoSelecionar(string referência)
        {
            string referênciaNumérica;
            int dígito;

            Entidades.Mercadoria.Mercadoria.DesmascararReferência(referência, out referênciaNumérica, out dígito);
            txtReferência.Text = referênciaNumérica + dígito;
            ReferênciaAlterada?.Invoke(this, null);
        }

        private void txtReferência_Validated(object sender, EventArgs e)
        {
            ReferênciaAlterada?.Invoke(sender, e);
        }
    }
}
