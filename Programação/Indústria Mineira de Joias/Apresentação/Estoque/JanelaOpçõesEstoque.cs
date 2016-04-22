using Apresentação.Formulários;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Estoque
{
    public partial class JanelaOpçõesEstoque : JanelaExplicativa
    {
        private Entidades.Configuração.ConfiguraçãoUsuário<bool> configuraçãoReferência;
        private Entidades.Configuração.ConfiguraçãoUsuário<bool> configuraçãoPeso;
        private Entidades.Configuração.ConfiguraçãoUsuário<bool> configuraçãoPesoMédio;
        private Entidades.Configuração.ConfiguraçãoUsuário<int> configuraçãoFornecedorÚnicoCódigoFornecedor;

        public JanelaOpçõesEstoque()
        {
            InitializeComponent();

            if (!DesignMode)
                comboBoxFornecedor.Carregar();

            configuraçãoReferência = new Entidades.Configuração.ConfiguraçãoUsuário<bool>("estoque_opcoes_impressao_incluir_referencia", true);
            configuraçãoPeso =  new Entidades.Configuração.ConfiguraçãoUsuário<bool>("estoque_opcoes_impressao_incluir_peso", true);
            configuraçãoFornecedorÚnicoCódigoFornecedor = new Entidades.Configuração.ConfiguraçãoUsuário<int>("estoque_opcoes_fornecedor_unico", 0);

            configuraçãoPesoMédio = new Entidades.Configuração.ConfiguraçãoUsuário<bool>("estoque_opcoes_peso_medio", false);
            chkReferência.Checked = configuraçãoReferência.Valor;
            chkPesoMédio.Checked = configuraçãoPesoMédio.Valor;
            chkPeso.Checked = configuraçãoPeso.Valor;
            
            if (configuraçãoFornecedorÚnicoCódigoFornecedor.Valor == 0)
            {
                chkFiltrarFornecedor.Checked = false;
                comboBoxFornecedor.Enabled = false;
            }  else
            {
                chkFiltrarFornecedor.Checked = true;
                comboBoxFornecedor.Enabled = true;

                comboBoxFornecedor.Selecionar(configuraçãoFornecedorÚnicoCódigoFornecedor.Valor);
            }
        }

        public bool IncluirReferência
        { get { return chkReferência.Checked;  } }

        public bool IncluirPeso
        { get { return chkPeso.Checked;  }  }

        public bool UsarPesoMédio
        { get { return chkPesoMédio.Checked;  } }

        public Entidades.Fornecedor FornecedorÚnico
        {
            get
            {
                if (!chkFiltrarFornecedor.Checked)
                    return null;
                else
                    return comboBoxFornecedor.Seleção;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            configuraçãoPesoMédio.Valor = chkPesoMédio.Checked;
            configuraçãoPeso.Valor = IncluirPeso;
            configuraçãoReferência.Valor = IncluirReferência;
            configuraçãoFornecedorÚnicoCódigoFornecedor.Valor = 
                (FornecedorÚnico == null ? 0 : (int) FornecedorÚnico.Código);

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Hide();
        }

        private void chkFiltrarFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFornecedor.Enabled = chkFiltrarFornecedor.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Hide();
        }
    }
}
