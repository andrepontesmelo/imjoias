using Apresentação.Formulários;
using Entidades.Configuração;
using System;

namespace Apresentação.Estoque
{
    public partial class JanelaOpçõesEstoque : JanelaExplicativa
    {
        private ConfiguraçãoUsuário<bool> configuraçãoReferência;
        private ConfiguraçãoUsuário<bool> configuraçãoPeso;
        private ConfiguraçãoUsuário<bool> configuraçãoPesoMédio;
        private ConfiguraçãoUsuário<ulong> configuraçãoFornecedorÚnicoCódigoFornecedor;
        private ConfiguraçãoUsuário<bool> configuraçãoAgrupado;

        public JanelaOpçõesEstoque()
        {
            InitializeComponent();

            if (!DesignMode)
                comboBoxFornecedor.Carregar();

            configuraçãoReferência = new ConfiguraçãoUsuário<bool>("estoque_opcoes_impressao_incluir_referencia", true);
            configuraçãoPeso =  new ConfiguraçãoUsuário<bool>("estoque_opcoes_impressao_incluir_peso", true);
            configuraçãoFornecedorÚnicoCódigoFornecedor = new ConfiguraçãoUsuário<ulong>("estoque_opcoes_fornecedor_unico", 0);
            configuraçãoAgrupado = new ConfiguraçãoUsuário<bool>("estoque_opcoes_agrupado", false);
            configuraçãoPesoMédio = new ConfiguraçãoUsuário<bool>("estoque_opcoes_peso_medio", false);
            chkAgruparReferências.Checked = configuraçãoAgrupado.Valor;
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

        public bool AgruparReferências => chkAgruparReferências.Checked;

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
            configuraçãoAgrupado.Valor = chkAgruparReferências.Checked;
            configuraçãoPesoMédio.Valor = chkPesoMédio.Checked;
            configuraçãoPeso.Valor = IncluirPeso;
            configuraçãoReferência.Valor = IncluirReferência;
            configuraçãoFornecedorÚnicoCódigoFornecedor.Valor = 
                (FornecedorÚnico == null ? 0 : FornecedorÚnico.Código);

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
