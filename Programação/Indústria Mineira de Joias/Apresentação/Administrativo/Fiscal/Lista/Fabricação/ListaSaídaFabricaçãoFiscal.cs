using Entidades.Fiscal.Fabricação;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaSaídaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        public ListaSaídaFabricaçãoFiscal()
        {
            InitializeComponent();
        }

        protected override List<ItemFabricaçãoFiscal> ObterItensEntidade(FabricaçãoFiscal fabricação)
        {
            return new List<ItemFabricaçãoFiscal>(SaídaFabricaçãoFiscal.Obter(fabricação.Código));
        }

        protected override ListViewItem CriarItem(ItemFabricaçãoFiscal entidade)
        {
            var item = base.CriarItem(entidade);

            item.SubItems[colPeso.Index].Text = ((SaídaFabricaçãoFiscal) entidade).Peso.ToString();
            item.SubItems[colPesoTotal.Index].Text =  Math.Round(((SaídaFabricaçãoFiscal) entidade).PesoTotal, 2).ToString();

            return item;
        }
    }
}
