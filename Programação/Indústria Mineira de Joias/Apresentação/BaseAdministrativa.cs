using Apresenta��o.Financeiro.Comiss�es;
using Apresenta��o.Formul�rios;
using Apresenta��o.Integra��oSistemaAntigo;
using Entidades.Privil�gio;
using System;
using System.Windows.Forms;

[assembly: ExporBot�o(Permiss�o.ManipularComiss�o | Permiss�o.T�cnico, 5, "Administrativo", false,
    typeof(Apresenta��o.Administrativo.BaseAdministrativa))]

namespace Apresenta��o.Administrativo
{
    public partial class BaseAdministrativa : Apresenta��o.Formul�rios.BaseInferior
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

        private void quadroExporta��o_Click(object sender, EventArgs e)
        {
            Integra��oSistemaAntigo.Fiscal.BaseFiscal.GerarArquivoFiscal();
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

        private void quadroExportacaoCupom_Click(object sender, EventArgs e)
        {
            Integra��oSistemaAntigo.Fiscal.BaseFiscal.GerarArquivoCupom();
        }

        private void quadroExportaVenda_Click(object sender, EventArgs e)
        {
            Apresenta��o.Financeiro.Fiscal.NfeVenda.GerarNfeVenda(this);
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            bool t�cnico = Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.T�cnico);

            quadroExporta��o.Visible = t�cnico;
            quadroExportacaoCupom.Visible = t�cnico;
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
    }
}