using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Financeiro.Comissões;
using Apresentação.IntegraçãoSistemaAntigo;
using Entidades.Privilégio;

[assembly: ExporBotão(Permissão.ManipularComissão | Permissão.Técnico, 5, "Administrativo", false,
    typeof(Apresentação.Administrativo.BaseRelatórios))]

namespace Apresentação.Administrativo
{
    public partial class BaseRelatórios : Apresentação.Formulários.BaseInferior
    {
        public BaseRelatórios()
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
            BaseMercadorias.ImportarDadosDoSistemaLegado();
        }

        private void quadroExportação_Click(object sender, EventArgs e)
        {
            IntegraçãoSistemaAntigo.Fiscal.BaseFiscal.GerarArquivoFiscal();
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

        private void quadroExportacaoCupom_Click(object sender, EventArgs e)
        {
            IntegraçãoSistemaAntigo.Fiscal.BaseFiscal.GerarArquivoCupom();
        }

        private void quadroExportação_Load(object sender, EventArgs e)
        {

        }

        private void quadroExportaVenda_Load(object sender, EventArgs e)
        {

        }

        private void quadroExportaVenda_Click(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Fiscal.NfeVenda.GerarNfeVenda(this);
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            bool técnico = (Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Permissão.Técnico));

            quadroExportação.Visible = técnico;
            quadroExportacaoCupom.Visible = técnico;
            quadroExportaVenda.Visible = técnico;
            quadroOpçãoBalanço.Visible = técnico;
            quadroOpçãoImportação.Visible = técnico;
            quadroControleEstoque.Visible = técnico;

            quadroComissão.Visible = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Permissão.ManipularComissão);
        }

        private void quadroExportacaoCupom_Load(object sender, EventArgs e)
        {

        }

        private void quadroControleEstoque_Load(object sender, EventArgs e)
        {

        }

        private void quadroControleEstoque_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Estoque.BaseEstoque());
        }
    }
}