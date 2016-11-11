using Apresentação.Administrativo.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.Extrato;
using Entidades.Configuração;
using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseExtrato : Apresentação.Formulários.BaseInferior
    {
        private string referência;

        private string ReferênciaFormatada => Entidades.Mercadoria.Mercadoria.MascararReferência(referência, true);

        public BaseExtrato()
        {
            InitializeComponent();
        }

        private DateTime? DataInicial => dataInicial.Value as DateTime?;
        private DateTime? DataFinal => dataFinal.Value as DateTime?;
        private bool DatasVálidas => DataInicial.HasValue && DataFinal.HasValue &&
            DataInicial.Value <= DataFinal.Value;

        public BaseExtrato(string referência) : this()
        {
            this.referência = referência;

            AtribuirIntervaloDatasPadrão();
            Carregar();
        }

        private void AtribuirIntervaloDatasPadrão()
        {
            var agora = DadosGlobais.Instância.HoraDataAtual;
            
            this.dataInicial.Value = new DateTime(agora.Year, agora.Month, 1);
            this.dataFinal.Value = new DateTime(agora.Year, agora.Month, 1).AddMonths(1).AddDays(-1);
        }

        private void Carregar()
        {
            if (referência == null)
                return;

            txtMercadoria.Referência = ReferênciaFormatada;

            AguardeDB.Mostrar();

            título.Título = "Extrato de " + ReferênciaFormatada;

            if (!DatasVálidas)
                AtribuirIntervaloDatasPadrão();

            listaExtrato.Carregar(referência, DataInicial.Value, DataFinal.Value);
            título.Descrição = string.Format("Extrato de {0} de {1} até {2} ",
                ReferênciaFormatada, DataInicial.Value.ToShortDateString(), DataFinal.Value.ToShortDateString());

            AguardeDB.Fechar();
        }

        private void dataInicial_Validated(object sender, EventArgs e)
        {
            Carregar();
        }

        private void dataFinal_Validated(object sender, EventArgs e)
        {
            Carregar();
        }

        private void dataInicial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !DatasVálidas;
        }

        private void dataFinal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !DatasVálidas;
        }

        private void txtMercadoria_ReferênciaConfirmada(object sender, EventArgs e)
        {
            referência = txtMercadoria.ReferênciaNumérica;
            Carregar();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            var janela = new JanelaImpressãoFiscal();

            DateTime dataInicial = DataInicial.HasValue ? DataInicial.Value : DadosGlobais.Instância.HoraDataAtual;
            DateTime dataFinal = DataFinal.HasValue ? DataFinal.Value : DadosGlobais.Instância.HoraDataAtual;

            janela.InserirDocumento("Extrato Geral",
                string.Format("Relatório de extrato de {0} até {1}", dataInicial.ToShortDateString(), dataFinal.ToShortDateString()),
                new ControladorImpressãoExtrato().CriarRelatório(null, dataInicial, dataFinal));

            janela.ShowDialog(this);
        }
    }
}
