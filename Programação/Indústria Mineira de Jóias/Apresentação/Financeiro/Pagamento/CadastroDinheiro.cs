using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Pagamento
{
    public partial class CadastroDinheiro : Apresenta��o.Financeiro.Pagamento.Cadastro
    {
        public CadastroDinheiro()
        {
            InitializeComponent();
        }

        protected override Entidades.Pagamentos.Pagamento CriarEntidade()
        {
            return new Entidades.Pagamentos.Dinheiro();
        }
    }
}

