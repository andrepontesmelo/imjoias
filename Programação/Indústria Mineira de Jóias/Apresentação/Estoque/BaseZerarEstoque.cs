using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Estoque;

namespace Apresentação.Estoque
{
    public partial class BaseZerarEstoque : BaseInferior
    {
        public BaseZerarEstoque()
        {
            InitializeComponent();
        }

        private void opçãoZerarEstoqueAgora_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtObservações.Text))
            {
                MessageBox.Show(this, "Entre com alguma descrição",
                    "Sem descrição", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            ZeragemEstoque entidade = new ZeragemEstoque();
            entidade.Observações = txtObservações.Text;
            entidade.Cadastrar();

            listaZeragemEstoque1.Carregar();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            listaZeragemEstoque1.Carregar();

            base.AoExibirDaPrimeiraVez();
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            List<ZeragemEstoque> lstEntidade = listaZeragemEstoque1.Seleção;

            if (lstEntidade.Count == 0)
            {
                MessageBox.Show(this,
                    "Favor selecionar algum registro",
                    "Sem seleção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                
                return;
            }

            StringBuilder msg = new StringBuilder("Excluir o(s) seguinte(s) ");

            msg.Append(lstEntidade.Count.ToString());
            msg.Append(" registro(s) ?\n\n");

            foreach (ZeragemEstoque z in lstEntidade)
            {
                msg.Append(" * ");
                msg.Append(z.Data.ToLongDateString());
                msg.Append(" ");
                msg.Append(z.Data.ToLongTimeString());
                msg.Append(" ");
                msg.Append(z.Observações);
                msg.AppendLine();
            }

            DialogResult resultado = MessageBox.Show(this,
                msg.ToString(), "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                foreach (ZeragemEstoque z in lstEntidade)
                {
                    z.Descadastrar();
                    listaZeragemEstoque1.Carregar();
                }
            }
        }
    }
}
