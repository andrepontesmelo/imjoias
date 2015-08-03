using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.Impress�o.Relat�rios.NotaPromiss�ria;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class CadastroNotaPromiss�ria : Apresenta��o.Financeiro.Pagamento.Cadastro
    {
        public CadastroNotaPromiss�ria()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            //Entidades.Pagamentos.NotaPromiss�ria np = new Entidades.Pagamentos.NotaPromiss�ria();
            //np.Vencimento = dataVencimento.Value;

            //return np;

            return new Entidades.Pagamentos.NotaPromiss�ria();
        }

        public override void PrepararParaAltera��o(Entidades.Pagamentos.Pagamento pagamento)
        {
            base.PrepararParaAltera��o(pagamento);


            dataVencimento.Value = ((Entidades.Pagamentos.NotaPromiss�ria)pagamento).Vencimento; 

            if (((Entidades.Pagamentos.NotaPromiss�ria)pagamento).ProrrogadoPara.HasValue)
            {
                chkProrrogado.Checked = true;
                dataProrroga��o.Value = ((Entidades.Pagamentos.NotaPromiss�ria)pagamento).ProrrogadoPara.Value;
                dataProrroga��o.Enabled = true;
            }
            else
            {
                chkProrrogado.Checked = false;
                dataProrroga��o.Enabled = false;
            }
            

        }

        public override void PrepararParaCadastro(Entidades.Relacionamento.Venda.IDadosVenda venda, Entidades.Pessoa.Pessoa pessoa)
        {
            base.PrepararParaCadastro(venda, pessoa);

            if (venda != null)
            {
                dataVencimento.Value = venda.Data.AddDays(venda.DiasSemJuros);
                ((Entidades.Pagamentos.NotaPromiss�ria)Pagamento).Vencimento = dataVencimento.Value;
            }
        }

        protected override void Gravar()
        {
            ((Entidades.Pagamentos.NotaPromiss�ria) Pagamento).Vencimento = dataVencimento.Value;

            if (chkProrrogado.Checked)
                ((Entidades.Pagamentos.NotaPromiss�ria)Pagamento).ProrrogadoPara = dataProrroga��o.Value;
            else
                ((Entidades.Pagamentos.NotaPromiss�ria)Pagamento).ProrrogadoPara = null;

            base.Gravar();
        }

        private void dataVencimento_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.NotaPromiss�ria) Pagamento).Vencimento = dataVencimento.Value;
            Pagamento.DefinirDesatualizado();
        }

        private void chkProrrogado_CheckedChanged(object sender, EventArgs e)
        {
            dataProrroga��o.Enabled = chkProrrogado.Checked;

            if (!chkProrrogado.Checked)
                ((Entidades.Pagamentos.NotaPromiss�ria)Pagamento).ProrrogadoPara = null;
        }

        private void dataProrroga��o_Validated(object sender, EventArgs e)
        {
            ((Entidades.Pagamentos.NotaPromiss�ria) Pagamento).ProrrogadoPara = dataProrroga��o.Value;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            JanelaImpress�o janela = new JanelaImpress�o();
            janela.T�tulo = "Nota Promiss�ria";
            janela.Descri��o = "Visualiza��o de impress�o para nota promiss�ria";

            Relat�rio relat�rio = new Relat�rio();
            ControleImpress�o controle = new ControleImpress�o();

            controle.PrepararImpress�o(relat�rio, ((Entidades.Pagamentos.NotaPromiss�ria)Pagamento));

            janela.InserirDocumento(relat�rio, "Nota Promiss�ria");

            AguardeDB.Fechar();
            janela.Abrir(this);
        }

    }
}

