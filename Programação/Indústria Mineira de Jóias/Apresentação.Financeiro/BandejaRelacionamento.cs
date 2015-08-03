using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Relacionamento.Saída;
using Apresentação.Útil;
using Entidades.Relacionamento;
using System.Collections.Generic;

namespace Apresentação.Financeiro
{
    public class BandejaRelacionamento : Apresentação.Mercadoria.Bandeja.Bandeja
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
             AdicionarVários(coleção.ObterSaquinhosAgrupados());

            //ArrayList saquinhos = coleção.ObterSaquinhosAgrupados();
            //foreach (Saquinho s in saquinhos)
            //{
            //    AdicionarListView(s);
            //}
        }
    }
}