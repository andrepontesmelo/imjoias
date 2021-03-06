﻿using System.Collections.Generic;
using Entidades.Fiscal.Fabricação;

namespace Apresentação.Administrativo.Fiscal.Lista.Fabricação
{
    public partial class ListaEntradaFabricaçãoFiscal : ListaItemFabricaçãoFiscal
    {
        public ListaEntradaFabricaçãoFiscal()
        { 
            InitializeComponent();

            lista.Columns.Clear();
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência,
            this.colCFOP,
            this.colSaldoAnterior,
            this.colQuantidade,
            this.colSaldoPosterior,
            this.colTipo,
            this.colValorUnitário,
            this.colValorTotal,
            this.colDescrição});
        }

        protected override List<ItemFabricaçãoFiscal> ObterItensEntidade(FabricaçãoFiscal fabricação)
        {
            return EntradaFabricaçãoFiscal.Obter(fabricação.Código);
        }
    }
}
