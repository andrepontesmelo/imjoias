using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Administrativo.Fiscal.BaseInferior.Produção;
using Apresentação.Administrativo.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.Inventário;
using Entidades.Configuração;
using Entidades.Fiscal.Exceções;
using Entidades.Fiscal.Produção;
using System;
using System.Collections.Generic;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseInventário : Apresentação.Formulários.BaseInferior
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

        private void Carregar()
        {
            títuloBaseInferior1.Título = string.Format("Inventário {0}",
                !Data.HasValue ? "atual" : "em " + Data.Value.ToShortDateString() + " " + Data.Value.ToShortTimeString());

            AguardeDB.Mostrar();
            listaInventário.Carregar(Data);
            AguardeDB.Fechar();
        }
        
        public DateTime? Data
        {
            get
            {
                if (optPassado.Checked)
                    return dataMáxima.Value as DateTime?;

                return null;
            }
        }
        private void dataMáxima_Validated(object sender, System.EventArgs e)
        {
            if (optPassado.Checked)
                Carregar();
        }

        private void optAtual_CheckedChanged(object sender, EventArgs e)
        {
            Carregar();
        }

        private void opçãoProduzir_Click(object sender, EventArgs e)
        {
            List<ItemProduçãoFiscal> itens = listaInventário.ObterItensChecados();
            ProduçãoFiscal novaProdução;

            if (itens.Count == 0)
                return;

            try
            {
                novaProdução = ProduçãoFiscal.Criar(itens);
            } catch (ExceçãoFiscal erro)
            {
                MensagemErro.MostrarMensagem(this, erro, "Erro ao criar produção");
                return;
            }

            SubstituirBase(new BaseProdução(novaProdução));
        }

        private void listaInventário_AoDuploClique(object sender, EventArgs e)
        {
            AbrirExtrato();
        }

        private void AbrirExtrato()
        {
            SubstituirBase(new BaseExtrato(listaInventário.ObterItemSelecionado()?.Referência));
        }

        private void opçãoExtrato_Click(object sender, EventArgs e)
        {
            AbrirExtrato();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            var janela = new JanelaImpressãoFiscal();

            DateTime data = Data.HasValue ? Data.Value : DadosGlobais.Instância.HoraDataAtual;

            janela.InserirDocumento("Inventário", "Relatório de inventário", 
                new ControladorImpressãoInventário().CriarRelatório(data));

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
    }
}
