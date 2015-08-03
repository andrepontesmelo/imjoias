using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace Apresentação.Financeiro.Acerto.Impressão
{
    public partial class JanelaImpressão : Apresentação.Formulários.JanelaImpressão
    {
        private Relatório relatório;
        private CrystalReportViewer vizualizador;
        public event EventHandler Impresso;

        Entidades.Acerto.Acerto acerto;

        public JanelaImpressão()
        {
            InitializeComponent();
        }

        public JanelaImpressão(Entidades.Acerto.Acerto acerto)
        {
            Apresentação.Formulários.AguardeDB.Mostrar();
            InitializeComponent();

            this.acerto = acerto;

            lblDescrição.Text = "É o resumo de mercadorias relacionadas para " + acerto.Pessoa.PrimeiroNome;

            if (acerto == null)
                throw new NullReferenceException("Acerto é nulo para janela de impressão");

            System.Data.DataSet ds = acerto.ObterImpressão(optResumido.Checked);

            relatório = new Relatório();

            relatório.SetDataSource(ds);

            vizualizador = InserirDocumento(relatório, acerto.Pessoa.PrimeiroNome);

            Apresentação.Formulários.AguardeDB.Fechar();
        }

        private void optResumido_CheckedChanged(object sender, EventArgs e)
        {
            optResumido.Enabled = false;
            UseWaitCursor = true;
            Apresentação.Formulários.AguardeDB.Mostrar();
            System.Data.DataSet ds = acerto.ObterImpressão(optResumido.Checked);
            relatório.SetDataSource(ds);
            vizualizador.ReportSource = relatório;
            Apresentação.Formulários.AguardeDB.Fechar();
            UseWaitCursor = false;
            optResumido.Enabled = true;   
        }

        protected override void ApósImpresso()
        {
            base.ApósImpresso();

            // Trava Saídas e Vendas.
            Entidades.Relacionamento.Saída.Saída.TravarVários(acerto.CódigoSaídas);
            Entidades.Relacionamento.Venda.Venda.TravarVários(acerto.CódigoVendas);
            
            /* A opção por não trancar o retorno se deve que as principais mudanças ocorrerão no retorno 
             * (retorno realizado de forma errada), então se a pessoa contou peças erradas, 
             * ela pode facilmente alterar sem precisar de um supervisor intervir.
             */

            if (Impresso != null)
                Impresso(this, EventArgs.Empty);
        }
    }
}

