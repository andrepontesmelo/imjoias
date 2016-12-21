using Entidades.Mercadoria;
using System;
using System.Windows.Forms;

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
            get
            {
                return ObterReferênciaDesmascarada();
            }
            set
            {
                AtribuirMascararReferência(value);
            }
        }

        private void AtribuirMascararReferência(string referência)
        {
            if (referência == null)
                txtReferência.Text = "";
            else
                txtReferência.Text = Entidades.Mercadoria.Mercadoria.MascararReferência(referência, true);
        }

        private string ObterReferênciaDesmascarada()
        {
            string referênciaNumérica;
            int dígito;
            Entidades.Mercadoria.Mercadoria.DesmascararReferência(txtReferência.Text, out referênciaNumérica, out dígito);
            return referênciaNumérica;
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
            txtReferência.Text = referência; 
            ReferênciaAlterada?.Invoke(this, null);
        }


        private void txtReferência_Validated(object sender, EventArgs e)
        {
            AtribuirMascararReferência(ObterReferênciaDesmascarada());
            ReferênciaAlterada?.Invoke(this, null);
        }
    }
}
