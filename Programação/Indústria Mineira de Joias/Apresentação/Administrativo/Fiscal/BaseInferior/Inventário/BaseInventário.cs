using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Administrativo.Fiscal.BaseInferior.fabricação;
using Apresentação.Administrativo.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.Inventário;
using Entidades.Configuração;
using Entidades.Fiscal;
using Entidades.Fiscal.Exceções;
using Entidades.Fiscal.Fabricação;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseInventário : Formulários.BaseInferior
    {
        public BaseInventário()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Carregar();
        }

        public DateTime? Data
        {
            get
            {
                var fechamento = cmbFechamento.Seleção;

                if (fechamento == null)
                    return null;

                return fechamento.Fim;
            }
        }

        public Fechamento Fechamento => cmbFechamento.Seleção;

        private void Carregar()
        {
            cmbFechamento.Carregar();

            if (Fechamento == null)
            {
                MessageBox.Show("Selecione um fechamento.");
                return;
            }

            títuloBaseInferior1.Título = string.Format("Inventário {0}",
                !Data.HasValue ? "atual" : "em " + Data.Value.ToShortDateString());

            AguardeDB.Mostrar();
            listaInventário.Carregar(Fechamento);
            AguardeDB.Fechar();
        }
        
        private void optAtual_CheckedChanged(object sender, EventArgs e)
        {
            Carregar();
        }

        private void opçãoProduzir_Click(object sender, EventArgs e)
        {
            List<ItemFabricaçãoFiscal> itens = listaInventário.ObterItensChecados(Fechamento.Código);
            FabricaçãoFiscal novafabricação;

            if (itens.Count == 0)
                return;

            try
            {
                novafabricação = FabricaçãoFiscal.Criar(itens, Fechamento);
            } catch (ExceçãoFiscal erro)
            {
                MensagemErro.MostrarMensagem(this, erro, "Erro ao criar fabricação");
                return;
            }

            var janelaEdiçãoFabricação = new JanelaEdiçãoFabricação(novafabricação);
            var resultado = janelaEdiçãoFabricação.Mostrar(this);

            if (resultado == DialogResult.Cancel)
            {
                novafabricação.Descadastrar();
                return;
            }

            SubstituirBase(new BaseFabricação(novafabricação));
        }

        private void listaInventário_AoDuploClique(object sender, EventArgs e)
        {
            AbrirExtrato();
        }

        private void AbrirExtrato()
        {
            SubstituirBase(new BaseExtrato(listaInventário.ObterItemSelecionado()?.Referência, Fechamento));
        }

        private void opçãoExtrato_Click(object sender, EventArgs e)
        {
            AbrirExtrato();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            if (Fechamento == null)
                return;

            var janela = new JanelaImpressãoFiscal();

            DateTime data = Data.HasValue ? Data.Value : DadosGlobais.Instância.HoraDataAtual;

            janela.InserirDocumento("Inventário", "Relatório de inventário", 
                
                new ControladorImpressãoInventário().CriarRelatório(Fechamento));

            janela.ShowDialog(this);
        }

        private void opçãoLimparSeleção_Click(object sender, EventArgs e)
        {
            listaInventário.LimparSeleção();
        }

        private void opçãoSelecionarNegativos_Click(object sender, EventArgs e)
        {
            listaInventário.SelecionarNegativos();
        }

        private void cmbFechamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carregar();
        }
    }
}
