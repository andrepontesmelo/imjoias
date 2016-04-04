using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    public partial class JanelaEscolhaFórmula : Apresentação.Formulários.JanelaExplicativa
    {
        public JanelaEscolhaFórmula()
        {
            InitializeComponent();
        }

        public FórmulaAcerto Fórmula
        {
            get
            {
                if (opçãoPadrão.Checked)
                    return FórmulaAcerto.Padrão;
                else
                    return FórmulaAcerto.IgualAVenda;
            }

            set
            { 
                // Alterar interface
                opçãoPadrão.Checked = (value == FórmulaAcerto.Padrão);
                opçãoIgualVenda.Checked = (value == FórmulaAcerto.IgualAVenda);
            }
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
