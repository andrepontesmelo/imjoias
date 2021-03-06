using Apresentação.Financeiro.Coaf;
using Apresentação.Financeiro.Comissões.BaseInferior;
using Apresentação.Fiscal.BaseInferior;
using Apresentação.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.IntegraçãoSistemaAntigo;
using Entidades.Privilégio;
using System;
using System.Windows.Forms;

[assembly: ExporBotão(Permissão.ManipularComissão | Permissão.Técnico, 5, "Administrativo", false,
    typeof(Apresentação.Administrativo.BaseAdministrativa))]

namespace Apresentação.Administrativo
{
    public partial class BaseAdministrativa : BaseInferior
    {
        public BaseAdministrativa()
        {
            InitializeComponent();
        }

        private void quadroOpçãoBalanço_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                SubstituirBase(new Balanço.BaseBalanço());
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void quadroOpçãoImportação_Click(object sender, EventArgs e)
        {
            new ProcessoIntegração().ImportarDadosDoSistemaLegado();
        }

        private void quadroFiscalExportaçãoVarejoBR500_Click(object sender, EventArgs e)
        {
            IntegraçãoSistemaAntigo.Fiscal.BaseFiscal.ExportarVarejoBR500();
        }

        private void quadroComissão_Click(object sender, EventArgs e)
        {
            if (PermissãoFuncionário.ValidarPermissão(Permissão.ManipularComissão))
                SubstituirBase(new BaseComissão());
            else
                MessageBox.Show(this,
                    "Favor solicitar a permissão 'Manipular comissão' para prosseguir.",
                    "Falta de permissão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void quadroFiscalExportacaoEconnectVarejo_Click(object sender, EventArgs e)
        {
            IntegraçãoSistemaAntigo.Fiscal.BaseFiscal.ExportarVEconnectVarejo();
        }

        private void quadroExportaVenda_Click(object sender, EventArgs e)
        {
            JanelaNFe janela = new JanelaNFe();
            janela.ShowDialog(this);
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            bool técnico = PermissãoFuncionário.ValidarPermissão(Permissão.Técnico);

            quadroFiscalExportaçãoVarejoBR500.Visible = técnico;
            quadroFiscalExportacaoEconnectVarejo.Visible = técnico;
            quadroFiscal.Visible = técnico;
            quadroFiscal.Visible = técnico;
            quadroExportaVenda.Visible = técnico;
            quadroOpçãoImportação.Visible = técnico;
            quadroOpçãoCoaf.Visible = técnico;

            quadroOpçãoBalanço.Visible = PermissãoFuncionário.ValidarPermissão(Permissão.Balanço);
            quadroControleEstoque.Visible = PermissãoFuncionário.ValidarPermissão(Permissão.Estoque);
            quadroComissão.Visible = PermissãoFuncionário.ValidarPermissão(Permissão.ManipularComissão);
        }

        private void quadroControleEstoque_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Estoque.BaseEstoque());
        }

        private void quadroFiscal_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseFiscal());
        }

        private void quadroOpçãoCoaf_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseCoaf());
        }

        private void quadroManutençãoMercadorias_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Mercadoria.Manutenção.Base.BaseManutenção());
        }
    }
}