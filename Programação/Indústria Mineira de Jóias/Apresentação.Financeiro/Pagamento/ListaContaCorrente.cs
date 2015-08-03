using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class ListaContaCorrente : Apresenta��o.Financeiro.Pagamento.ListaPagamento
    {
        public ListaContaCorrente()
        {
            InitializeComponent();
            this.MostrarToolStrip = false;
            colVencimento.Text = "Venc.";
            colVencimento.Width = 50;
        }

        protected override bool DevoAdicionar(Entidades.Pagamentos.Pagamento p)
        {
            return (p.Pendente);
        }
    }
}

