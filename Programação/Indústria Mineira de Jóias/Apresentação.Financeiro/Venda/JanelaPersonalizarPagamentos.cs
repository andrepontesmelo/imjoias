using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Venda
{
    public partial class JanelaPersonalizarPagamentos : JanelaExplicativa
    {
        public JanelaPersonalizarPagamentos(Entidades.Relacionamento.Venda.Venda venda)
        {
            InitializeComponent();

            listaPagamento.SomenteLeitura = true;
            listaPagamento.Venda = venda;
        }

        private void botãoLiberarRecurso1_LiberarRecurso(object sender, EventArgs e)
        {
            listaPagamento.SomenteLeitura = false;
        }
    }
}