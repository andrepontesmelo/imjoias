using Entidades.Fiscal.Fabricação;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaSaídaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        private ApuradorFabricação apurador;

        public ListaSaídaFabricaçãoFiscal()
        {
            InitializeComponent();

            lista.SuspendLayout();
            colEstoqueAnterior.DisplayIndex = 0;
            colApuração.DisplayIndex = 2;
            lista.ResumeLayout();
        }

        public override void Carregar(FabricaçãoFiscal fabricação)
        {
            apurador = new ApuradorFabricação(fabricação);
            base.Carregar(fabricação);
        }

        protected override List<ItemFabricaçãoFiscal> ObterItensEntidade(FabricaçãoFiscal fabricação)
        {
            return new List<ItemFabricaçãoFiscal>(SaídaFabricaçãoFiscal.Obter(fabricação.Código));
        }

        protected override ListViewItem CriarItem(ItemFabricaçãoFiscal entidade)
        {
            var item = base.CriarItem(entidade);
            var saída = (SaídaFabricaçãoFiscal) entidade;

            item.SubItems[colPeso.Index].Text = saída.Peso.ToString();
            item.SubItems[colPesoTotal.Index].Text =  Math.Round(saída.PesoTotal, 2).ToString();
            var apuração = apurador.ObterApuração(entidade);
            item.SubItems[colApuração.Index].Text = apuração.ToString();
            item.SubItems[colEstoqueAnterior.Index].Text = apurador.ObterInventárioAnterior(entidade).ToString();

            return item;
        }
    }
}
