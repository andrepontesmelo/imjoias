using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class CadastroCrédito : Apresentação.Financeiro.Pagamento.Cadastro
    {
        public CadastroCrédito()
        {
            InitializeComponent();
        }
        //protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        //{
        //    return new Entidades.Crédito();
        //}

        //public override void PrepararParaAlteração(Entidades.Pagamentos.Pagamento pagamento)
        //{
        //    base.PrepararParaAlteração(pagamento);
        //    txtValor.Double = Math.Abs(pagamento.Valor);
        //    //txtIdentificação.Text = ((Entidades.Pagamentos.Crédito)pagamento).Identificação;
        //}


        ////private void txtIdentificação_Validated(object sender, EventArgs e)
        ////{
        ////    if (txtIdentificação.Text.Trim().Length > 0)
        ////        ((Entidades.Pagamentos.Crédito)Pagamento).Identificação = txtIdentificação.Text.Trim();
        ////    else
        ////        ((Entidades.Pagamentos.Crédito)Pagamento).Identificação = null;
        ////}

        //protected override double ObterValor()
        //{
        //    //return -base.ObterValor();
        //    return base.ObterValor();
        //}
    }
}

