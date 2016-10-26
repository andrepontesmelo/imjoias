using Apresentação.Formulários;
using Entidades.Relacionamento;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    public class BandejaRelacionamento : Mercadoria.Bandeja.Bandeja
    {
        private System.ComponentModel.IContainer components = null;

        public BandejaRelacionamento()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnAgrupar.Visible = false;
            OrdenaçãoReferência = true;
            Agrupar = true;
        }
        #endregion

        public void Abrir(HistóricoRelacionamento coleção)
        {
            // Indice que deve ser mostrado é o do saquinho e nao da mercadoria.
            bool erroAlteracaoConcorrente;

            LimparLista();

            AdicionarVários(coleção.ObterSaquinhosAgrupados(out erroAlteracaoConcorrente));

            if (erroAlteracaoConcorrente)
            {
                AguardeDB.Fechar();

                MessageBox.Show("Este documento possui pelo pelos um item com quantidade negativa. " + 
                    " Isto aconteceu porque mais de uma pessoa excluiu itens no mesmo instante. " + 
                    "Favor verificar.", "Documento inconsistente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}