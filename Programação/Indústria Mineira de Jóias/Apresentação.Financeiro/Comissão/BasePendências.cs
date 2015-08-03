using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Apresenta��o.Formul�rios;
using Entidades.Privil�gio;

//[assembly: ExporBot�o(
//    Permiss�o.PagarComiss�o,
//    "Comiss�o", true,
//    typeof(Apresenta��o.Financeiro.Comiss�o.BasePend�ncias))]

namespace Apresenta��o.Financeiro.Comiss�o
{
    public partial class BasePend�ncias : Apresenta��o.Formul�rios.BaseInferior
    {
        public BasePend�ncias()
        {
            InitializeComponent();
        }

        protected override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            if (splash != null)
                splash.Mensagem = "Construindo tela de comiss�es pendentes...";
        }


        protected override void AoExibir()
        {
            base.AoExibir();

            // Obt�m as vendas n�o verificadas
            listaVendas.Carregar(Entidades.Relacionamento.Venda.VendaSintetizada.ObterVendasN�oVerificadas());
        }

        private void op��oVerificar_Click(object sender, EventArgs e)
        {
            //Apresenta��o.Formul�rios.AguardeDB.Mostrar();
            //UseWaitCursor = true;

            //List<IDadosVenda> listaDadosVenda = listaVendas.ObterVendasMarcadas();
            //List<long> c�digoVendas = new List<long>(listaDadosVenda.Count);

            //if (listaDadosVenda.Count == 0)
            //{
            //    Apresenta��o.Formul�rios.AguardeDB.Fechar();
            //    UseWaitCursor = false;

            //    MessageBox.Show("Nenhuma venda est� selecionada", "Processo cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            
            //foreach (IDadosVenda venda in listaDadosVenda)
            //    c�digoVendas.Add(venda.C�digo);

            //Entidades.Relacionamento.Venda.Venda.AutorizarComiss�o(c�digoVendas);

            //Apresenta��o.Formul�rios.AguardeDB.Fechar();
            //UseWaitCursor = false;

            //// Recarrega a lista
            //AoExibir();
        }
    }
}

