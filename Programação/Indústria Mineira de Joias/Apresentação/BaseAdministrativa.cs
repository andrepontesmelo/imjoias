using Apresenta��o.Financeiro.Comiss�es;
using Apresenta��o.Financeiro.Fiscal;
using Apresenta��o.Fiscal;
using Apresenta��o.Formul�rios;
using Apresenta��o.Integra��oSistemaAntigo;
using Entidades.Privil�gio;
using System;
using System.Windows.Forms;

[assembly: ExporBot�o(Permiss�o.ManipularComiss�o | Permiss�o.T�cnico, 5, "Administrativo", false,
    typeof(Apresenta��o.Administrativo.BaseAdministrativa))]

namespace Apresenta��o.Administrativo
{
    public partial class BaseAdministrativa : BaseInferior
    {
        public BaseAdministrativa()
        {
            InitializeComponent();
        }

        private void quadroOp��oBalan�o_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                SubstituirBase(new Balan�o.BaseBalan�o());
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void quadroOp��oImporta��o_Click(object sender, EventArgs e)
        {
            new ProcessoIntegra��o().ImportarDadosDoSistemaLegado();
        }

        private void quadroFiscalExporta��oAtacadoBR500_Click(object sender, EventArgs e)
        {
            Integra��oSistemaAntigo.Fiscal.BaseFiscal.ExportarAtacadoBR500();
        }

        private void quadroComiss�o_Click(object sender, EventArgs e)
        {
            if (Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.ManipularComiss�o))
                SubstituirBase(new BaseComiss�o());
            else
                MessageBox.Show(this,
                    "Favor solicitar a permiss�o 'Manipular comiss�o' para prosseguir.",
                    "Falta de permiss�o",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void quadroFiscalExportacaoEconnectVarejo_Click(object sender, EventArgs e)
        {
            Integra��oSistemaAntigo.Fiscal.BaseFiscal.ExportarVEconnectVarejo();
        }

        private void quadroExportaVenda_Click(object sender, EventArgs e)
        {
            JanelaNFe janela = new JanelaNFe();
            janela.ShowDialog(this);
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            bool t�cnico = Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.T�cnico);

            quadroFiscalExporta��oAtacadoBR500.Visible = t�cnico;
            quadroFiscalExportacaoEconnectVarejo.Visible = t�cnico;
            quadroFiscal.Visible = t�cnico;
            quadroFiscal.Visible = t�cnico;

            quadroExportaVenda.Visible = t�cnico;
            quadroOp��oImporta��o.Visible = t�cnico;

            quadroOp��oBalan�o.Visible = Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.Balan�o);
            quadroControleEstoque.Visible = Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.Estoque);
            quadroComiss�o.Visible = Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.ManipularComiss�o);
        }

        private void quadroControleEstoque_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Estoque.BaseEstoque());
        }

        private void quadroFiscal_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseFiscal());
        }
    }
}