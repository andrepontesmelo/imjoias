using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Financeiro.Venda;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Comissões.BaseInferior
{
    public partial class BaseVendaSemComissão : Apresentação.Formulários.BaseInferior
    {
        private long? últimoItemSelecionado;
        private List<IDadosVenda> últimosItensChecados;

        public BaseVendaSemComissão()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            Recarregar();

            base.AoExibir();
        }

        void listViewVendas_AoDuploClique(long? códigoVenda)
        {
            if (códigoVenda.HasValue)
            {
                BaseEditarVenda novaBase = new BaseEditarVenda();
                novaBase.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value));
                SubstituirBase(novaBase);
            }
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = VendaSintetizada.ObterVendasSemComissão();
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listViewVendas.Carregar((VendaSintetizada[]) e.Result);
        
            if (últimoItemSelecionado.HasValue)
                listViewVendas.ItemSelecionado = últimoItemSelecionado;

            listViewVendas.ItensSelecionados = últimosItensChecados;
        }

        private void listViewVendas_AoSalvarNfe(object sender, EventArgs e)
        {
            Recarregar();
        }

        private void Recarregar()
        {
            últimoItemSelecionado = listViewVendas.ItemSelecionado;
            últimosItensChecados = listViewVendas.ItensSelecionados;
            bg.RunWorkerAsync();
        }
    }
}
