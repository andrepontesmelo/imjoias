using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class CadastroCr�dito : Apresenta��o.Financeiro.Pagamento.Cadastro
    {
        public CadastroCr�dito()
        {
            InitializeComponent();
        }
        //protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        //{
        //    return new Entidades.Cr�dito();
        //}

        //public override void PrepararParaAltera��o(Entidades.Pagamentos.Pagamento pagamento)
        //{
        //    base.PrepararParaAltera��o(pagamento);
        //    txtValor.Double = Math.Abs(pagamento.Valor);
        //    //txtIdentifica��o.Text = ((Entidades.Pagamentos.Cr�dito)pagamento).Identifica��o;
        //}


        ////private void txtIdentifica��o_Validated(object sender, EventArgs e)
        ////{
        ////    if (txtIdentifica��o.Text.Trim().Length > 0)
        ////        ((Entidades.Pagamentos.Cr�dito)Pagamento).Identifica��o = txtIdentifica��o.Text.Trim();
        ////    else
        ////        ((Entidades.Pagamentos.Cr�dito)Pagamento).Identifica��o = null;
        ////}

        //protected override double ObterValor()
        //{
        //    //return -base.ObterValor();
        //    return base.ObterValor();
        //}
    }
}

