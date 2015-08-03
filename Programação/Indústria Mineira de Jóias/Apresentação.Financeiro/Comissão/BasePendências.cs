using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Apresentação.Formulários;
using Entidades.Privilégio;

//[assembly: ExporBotão(
//    Permissão.PagarComissão,
//    "Comissão", true,
//    typeof(Apresentação.Financeiro.Comissão.BasePendências))]

namespace Apresentação.Financeiro.Comissão
{
    public partial class BasePendências : Apresentação.Formulários.BaseInferior
    {
        public BasePendências()
        {
            InitializeComponent();
        }

        protected override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            if (splash != null)
                splash.Mensagem = "Construindo tela de comissões pendentes...";
        }


        protected override void AoExibir()
        {
            base.AoExibir();

            // Obtém as vendas não verificadas
            listaVendas.Carregar(Entidades.Relacionamento.Venda.VendaSintetizada.ObterVendasNãoVerificadas());
        }

        private void opçãoVerificar_Click(object sender, EventArgs e)
        {
            //Apresentação.Formulários.AguardeDB.Mostrar();
            //UseWaitCursor = true;

            //List<IDadosVenda> listaDadosVenda = listaVendas.ObterVendasMarcadas();
            //List<long> códigoVendas = new List<long>(listaDadosVenda.Count);

            //if (listaDadosVenda.Count == 0)
            //{
            //    Apresentação.Formulários.AguardeDB.Fechar();
            //    UseWaitCursor = false;

            //    MessageBox.Show("Nenhuma venda está selecionada", "Processo cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            
            //foreach (IDadosVenda venda in listaDadosVenda)
            //    códigoVendas.Add(venda.Código);

            //Entidades.Relacionamento.Venda.Venda.AutorizarComissão(códigoVendas);

            //Apresentação.Formulários.AguardeDB.Fechar();
            //UseWaitCursor = false;

            //// Recarrega a lista
            //AoExibir();
        }
    }
}

