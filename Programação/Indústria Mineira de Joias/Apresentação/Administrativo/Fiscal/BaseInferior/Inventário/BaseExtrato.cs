using Apresentação.Administrativo.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.Extrato;
using Entidades.Configuração;
using Entidades.Fiscal;
using Entidades.Fiscal.Registro;
using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseExtrato : Apresentação.Formulários.BaseInferior
    {
        private Fechamento fechamento;

        private DateTime? DataInicial => fechamento.Início;
        private DateTime? DataFinal => fechamento.Fim;

        private string referência;

        private string ReferênciaFormatada => Entidades.Mercadoria.Mercadoria.MascararReferência(referência, true);

        public BaseExtrato()
        {
            InitializeComponent();
        }


        public BaseExtrato(string referência, Fechamento fechamento) : this()
        {
            this.referência = referência;
            this.fechamento = fechamento;

            Carregar();
        }

        private void Carregar()
        {
            if (referência == null)
                return;

            comboFechamento.Carregar();

            txtMercadoria.Referência = ReferênciaFormatada;

            AguardeDB.Mostrar();

            título.Título = "Extrato de " + ReferênciaFormatada;

            CarregarEstoqueAnterior();

            listaExtrato.Carregar(referência, fechamento);
            título.Descrição = string.Format("Extrato de {0} de {1} até {2} ",
                ReferênciaFormatada, DataInicial.Value.ToShortDateString(), DataFinal.Value.ToShortDateString());

            AguardeDB.Fechar();
        }

        private void CarregarEstoqueAnterior()
        {
            decimal estoqueAnterior = 0;
            InventárioRelativo.ObterHashReferênciaQuantidadeInventárioAnterior(DataInicial.Value).TryGetValue(referência, out estoqueAnterior);
            txtEstoqueAnterior.Text = estoqueAnterior.ToString();
        }

        private void txtMercadoria_ReferênciaConfirmada(object sender, EventArgs e)
        {
            referência = txtMercadoria.ReferênciaNumérica;
            Carregar();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            if (fechamento == null)
                return;

            var janela = new JanelaImpressãoFiscal();

            DateTime dataInicial = DataInicial.HasValue ? DataInicial.Value : DadosGlobais.Instância.HoraDataAtual;
            DateTime dataFinal = DataFinal.HasValue ? DataFinal.Value : DadosGlobais.Instância.HoraDataAtual;

            janela.InserirDocumento("Extrato Geral",
                string.Format("Relatório de extrato de {0} até {1}", dataInicial.ToShortDateString(), dataFinal.ToShortDateString()),
                new ControladorImpressãoExtrato().CriarRelatório(null, fechamento));

            janela.ShowDialog(this);
        }

        private void comboFechamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            fechamento = comboFechamento.Seleção;
            Carregar();
        }
    }
}
