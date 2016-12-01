using Apresentação.Administrativo.Fiscal.BaseInferior;
using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Administrativo.Fiscal.BaseInferior.fabricação;
using Apresentação.Administrativo.Fiscal.BaseInferior.Inventário;
using Apresentação.Fiscal.BaseInferior.Documentos;
using Apresentação.Fiscal.Janela;
using Apresentação.Formulários;
using Apresentação.IntegraçãoSistemaAntigo;
using Entidades.Fiscal.Importação.Legado;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseFiscal : Formulários.BaseInferior
    {
        public BaseFiscal()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();
            listaFechamento.Carregar();
        }

        private void opçãoImportação_Click(object sender, EventArgs e)
        {
            new JanelaImportação().Show();
        }

        private void opçãoEntradas_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseEntradas());
        }

        private void opçãoSaídas_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseSaídas());
        }

        private void opçãoMáquinasECF_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseMaquinasFiscais());
        }

        private void opçãoInventário_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseInventário());
        }

        private void opçãoFabricações_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseFabricações());
        }

        private void opçãoImportar_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            try
            {
                new ImportaçãoSistemaLegado().CriarEntradaTransição();
                AguardeDB.Fechar();
                MessageBox.Show("Entrada de transição preenchida.\nInventário atual idêntico ao 'estoque anterior' do sistema legado.");

            } catch (Exception erro)
            {
                AguardeDB.Fechar();
                MessageBox.Show("Erro ao preencher entrada de transição.\nA transição já deve existir no banco de dados.\n\n" + erro.Message);
            }
        }

        private void opçãoImportarEstoqueAnteriorSistemaLegado_Click(object sender, EventArgs e)
        {
            new ProcessoIntegração().TransporEstoqueAnterior();
        }

        private void opçãoImportarPreçosMatériasPrimas_Click(object sender, EventArgs e)
        {
            new ProcessoIntegração().TransporPreçosMatériasPrimas();
        }

        private void listaFechamento_AoAbrirEsquema(object sender, EventArgs e)
        {

            AbrirEsquemaFechamento();
        }

        private void AbrirEsquemaFechamento()
        {
            var seleção = listaFechamento.Seleção;

            if (seleção == null)
                return;

            BaseEsquemas novaBase = new BaseEsquemas();
            novaBase.Carregar(seleção);

            SubstituirBase(novaBase);
        }

        private void listaFechamento_AoDuploClique(object sender, EventArgs e)
        {
            AbrirEsquemaFechamento();
        }
    }
}
