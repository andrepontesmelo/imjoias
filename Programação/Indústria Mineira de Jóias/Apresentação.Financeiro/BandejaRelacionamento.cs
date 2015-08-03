using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Relacionamento.Sa�da;
using Apresenta��o.�til;
using Entidades.Relacionamento;
using System.Collections.Generic;

namespace Apresenta��o.Financeiro
{
    public class BandejaRelacionamento : Apresenta��o.Mercadoria.Bandeja.Bandeja
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
            Ordena��oRefer�ncia = true;
            Agrupar = true;
        }
        #endregion

        public void Abrir(Hist�ricoRelacionamento cole��o)
        {
            // Indice que deve ser mostrado � o do saquinho e nao da mercadoria.
             AdicionarV�rios(cole��o.ObterSaquinhosAgrupados());

            //ArrayList saquinhos = cole��o.ObterSaquinhosAgrupados();
            //foreach (Saquinho s in saquinhos)
            //{
            //    AdicionarListView(s);
            //}
        }
    }
}