using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseExtrato : Apresentação.Formulários.BaseInferior
    {
        public BaseExtrato()
        {
            InitializeComponent();
        }

        public BaseExtrato(string referência) : this()
        {
            Carregar(referência);
        }

        private void Carregar(string referência)
        {
            if (referência == null)
                return;

            título.Título = "Extrato de " + Entidades.Mercadoria.Mercadoria.MascararReferência(referência, true);
            txtMercadoria.Referência = referência;
            listaExtrato.Carregar(referência);
        }
    }
}
