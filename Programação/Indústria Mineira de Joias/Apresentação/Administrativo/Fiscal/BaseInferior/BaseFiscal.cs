using Apresentação.Administrativo.Fiscal.BaseInferior;
using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Administrativo.Fiscal.BaseInferior.Inventário;
using Apresentação.Administrativo.Fiscal.BaseInferior.fabricação;
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

        private void opçãoEsquemas_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseEsquemas());
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

            } catch (Exception)
            {
                AguardeDB.Fechar();
                MessageBox.Show("Erro ao preencher entrada de transição.\nA transição já deve existir no banco de dados.");
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
    }
}
