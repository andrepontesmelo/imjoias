using Apresentação.Administrativo.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.Extrato;
using Entidades.Configuração;
using Entidades.Fiscal.Registro;
using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseExtrato : Apresentação.Formulários.BaseInferior
    {

        private DateTime? DataInicial => seleçãoPeríodo.DataInicial;
        private DateTime? DataFinal => seleçãoPeríodo.DataFinal;
        private bool DatasVálidas => seleçãoPeríodo.DatasVálidas;

        private string referência;

        private string ReferênciaFormatada => Entidades.Mercadoria.Mercadoria.MascararReferência(referência, true);

        public BaseExtrato()
        {
            InitializeComponent();
        }


        public BaseExtrato(string referência) : this()
        {
            this.referência = referência;

            seleçãoPeríodo.AtribuirIntervaloDatasPadrão();
            Carregar();
        }

        private void Carregar()
        {
            if (referência == null)
                return;

            txtMercadoria.Referência = ReferênciaFormatada;

            AguardeDB.Mostrar();

            título.Título = "Extrato de " + ReferênciaFormatada;

            if (!DatasVálidas)
                seleçãoPeríodo.AtribuirIntervaloDatasPadrão();

            CarregarEstoqueAnterior();

            listaExtrato.Carregar(referência, DataInicial.Value, DataFinal.Value);
            título.Descrição = string.Format("Extrato de {0} de {1} até {2} ",
                ReferênciaFormatada, DataInicial.Value.ToShortDateString(), DataFinal.Value.ToShortDateString());

            AguardeDB.Fechar();
        }

        private void CarregarEstoqueAnterior()
        {
            decimal estoqueAnterior = 0;
            InventárioAnterior.ObterHashReferênciaQuantidade(DataInicial.Value).TryGetValue(referência, out estoqueAnterior);
            txtEstoqueAnterior.Text = estoqueAnterior.ToString();
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

        private void seleçãoPeríodo_AoAlterar(object sender, EventArgs e)
        {
            Carregar();
        }
    }
}
