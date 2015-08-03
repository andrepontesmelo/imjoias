using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.NotaPromissória;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class CadastroNotaPromissória : Apresentação.Financeiro.Pagamento.Cadastro
    {
        public CadastroNotaPromissória()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            //Entidades.Pagamentos.NotaPromissória np = new Entidades.Pagamentos.NotaPromissória();
            //np.Vencimento = dataVencimento.Value;

            //return np;

            return new Entidades.Pagamentos.NotaPromissória();
        }

        public override void PrepararParaAlteração(Entidades.Pagamentos.Pagamento pagamento)
        {
            base.PrepararParaAlteração(pagamento);


            dataVencimento.Value = ((Entidades.Pagamentos.NotaPromissória)pagamento).Vencimento; 

            if (((Entidades.Pagamentos.NotaPromissória)pagamento).ProrrogadoPara.HasValue)
            {
                chkProrrogado.Checked = true;
                dataProrrogação.Value = ((Entidades.Pagamentos.NotaPromissória)pagamento).ProrrogadoPara.Value;
                dataProrrogação.Enabled = true;
            }
            else
            {
                chkProrrogado.Checked = false;
                dataProrrogação.Enabled = false;
            }
            

        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

            if (venda != null)
            {
                dataVencimento.Value = venda.Data.AddDays(venda.DiasSemJuros);
                ((Entidades.Pagamentos.NotaPromissória)Pagamento).Vencimento = dataVencimento.Value;
            }
        }

        protected override void Gravar()
        {
            ((Entidades.Pagamentos.NotaPromissória) Pagamento).Vencimento = dataVencimento.Value;

            if (chkProrrogado.Checked)
                ((Entidades.Pagamentos.NotaPromissória)Pagamento).ProrrogadoPara = dataProrrogação.Value;
            else
                ((Entidades.Pagamentos.NotaPromissória)Pagamento).ProrrogadoPara = null;

            base.Gravar();
        }

        private void dataVencimento_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.NotaPromissória) Pagamento).Vencimento = dataVencimento.Value;
            Pagamento.DefinirDesatualizado();
        }

        private void chkProrrogado_CheckedChanged(object sender, EventArgs e)
        {
            dataProrrogação.Enabled = chkProrrogado.Checked;

            if (!chkProrrogado.Checked)
                ((Entidades.Pagamentos.NotaPromissória)Pagamento).ProrrogadoPara = null;
        }

        private void dataProrrogação_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.NotaPromissória) Pagamento).ProrrogadoPara = dataProrrogação.Value;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            JanelaImpressão janela = new JanelaImpressão();
            janela.Título = "Nota Promissória";
            janela.Descrição = "Visualização de impressão para nota promissória";

            Relatório relatório = new Relatório();
            ControleImpressão controle = new ControleImpressão();

            controle.PrepararImpressão(relatório, ((Entidades.Pagamentos.NotaPromissória)Pagamento));

            janela.InserirDocumento(relatório, "Nota Promissória");

            AguardeDB.Fechar();
            janela.Abrir(this);
        }

    }
}

