using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresentação.Administrativo.Balanço
{
    public partial class BaseBalanço : Apresentação.Formulários.BaseInferior
    {
        public BaseBalanço()
        {
            InitializeComponent();
        }

        protected override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Construindo tela para balanço";

            base.AoCarregarCompletamente(splash);
        }

        private void opção1_Click(object sender, EventArgs e)
        {
            //ControleAcertoMercadorias acerto;
            //BaseResumo baseResumo;

            //Apresentação.Formulários.AguardeDB.Mostrar();

            //// Faz a contabilização das mercadorias
            //acerto = new ControleAcertoMercadorias(listaSaídas.ObterCódigosMarcados(),
            //    listaRetornos.ObterCódigosMarcados(),
            //    listaVendas.ObterCódigosMarcados());

            //baseResumo = new BaseResumo();
            //baseResumo.Carregar(acerto);

            //SubstituirBase(baseResumo);
            //Apresentação.Formulários.AguardeDB.Fechar();

            SubstituirBase(new BaseResumo(listaSaídas.ObterCódigosMarcados(),
                listaRetornos.ObterCódigosMarcados(),
                listaVendas.ObterCódigosMarcados()));
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            // Recarrega as listas
            listaRetornos.Carregar();
            listaSaídas.Carregar();
            listaVendas.Carregar();
        }

        private void opçãoFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
