using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Apresenta��o.Impress�o.Relat�rios.Acerto;

namespace Apresenta��o.Financeiro.Acerto
{
    public partial class JanelaImpress�o : Apresenta��o.Formul�rios.JanelaImpress�o
    {
        private Relat�rio relat�rio;
        public event EventHandler Impresso;

        Entidades.Acerto.ControleAcertoMercadorias acerto;

        public JanelaImpress�o()
        {
            InitializeComponent();
        }

        public JanelaImpress�o(Entidades.Acerto.ControleAcertoMercadorias acerto)
        {
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();
            InitializeComponent();

            this.acerto = acerto;

            lblDescri��o.Text = "� o resumo de mercadorias relacionadas para " + acerto.Pessoa.PrimeiroNome;

            if (acerto == null)
                throw new NullReferenceException("Acerto � nulo para janela de impress�o");

            System.Data.DataSet ds = acerto.ObterImpress�o(optResumido.Checked);

            relat�rio = new Relat�rio();

            relat�rio.SetDataSource(ds);

            InserirDocumento(relat�rio, acerto.Pessoa.PrimeiroNome);

            Apresenta��o.Formul�rios.AguardeDB.Fechar();
        }

        private void optResumido_CheckedChanged(object sender, EventArgs e)
        {
            optResumido.Enabled = false;
            UseWaitCursor = true;
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();
            System.Data.DataSet ds = acerto.ObterImpress�o(optResumido.Checked);
            relat�rio.SetDataSource(ds);
            
            // Reinsere o documento
            tabControl.Controls.Clear();
            InserirDocumento(relat�rio, acerto.Pessoa.PrimeiroNome);
            
            Apresenta��o.Formul�rios.AguardeDB.Fechar();
            UseWaitCursor = false;
            optResumido.Enabled = true;   
        }

        protected override void Ap�sImpresso()
        {
            base.Ap�sImpresso();

            // Trava Sa�das e Vendas.
            Entidades.Relacionamento.Sa�da.Sa�da.TravarV�rios(acerto.C�digoSa�das, false);
            Entidades.Relacionamento.Venda.Venda.TravarV�rios(acerto.C�digoVendas, false);
            
            /* A op��o por n�o trancar o retorno se deve que as principais mudan�as ocorrer�o no retorno 
             * (retorno realizado de forma errada), ent�o se a pessoa contou pe�as erradas, 
             * ela pode facilmente alterar sem precisar de um supervisor intervir.
             */

            if (Impresso != null)
                Impresso(this, EventArgs.Empty);
        }
    }
}

